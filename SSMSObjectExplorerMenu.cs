using EnvDTE;
using EnvDTE80;
using Microsoft.SqlServer.Management.UI.VSIntegration;
using Microsoft.SqlServer.Management.UI.VSIntegration.Editors;
using Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SSMSObjectExplorerMenu.objects;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
	[ProvideAutoLoad("d114938f-591c-46cf-a785-500a82d97410")] //CommandGuids.ObjectExplorerToolWindowIDString
	[ProvideOptionPage(typeof(OptionsDialogPage), "SQL Server Object Explorer", "SSMS Object Explorer Menu", 0, 0, true)]
	public sealed class SSMSObjectExplorerMenu : Package
	{
		private OptionsDialogPage options;
		private TreeView treeView;
		private IObjectExplorerService objectExplorerService;

		public SSMSObjectExplorerMenu()
		{
		}

		protected override void Initialize()
		{
			base.Initialize();

			//load settings from options dialog
			(this as IVsPackage).GetAutomationObject("SQL Server Object Explorer.SSMS Object Explorer Menu", out object automationObject);
			if (automationObject == null)
			{
				Error("Automation Object not found");
				return;
			}
			options = (OptionsDialogPage)automationObject;

			//find tree control in the Object Explorer window
			objectExplorerService = (IObjectExplorerService)this.GetService(typeof(IObjectExplorerService));
			if (objectExplorerService == null)
			{
				Error("Object Explorer Service not found");
				return;
			}
			var treeProperty = objectExplorerService.GetType().GetProperty("Tree", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase);
			if (treeProperty == null)
			{
				Error("Tree property not found");
				return;
			}
			treeView = (TreeView)treeProperty.GetValue(objectExplorerService, null);
			if (treeView == null)
			{
				Error("TreeView control not found");
				return;
			}
			treeView.ContextMenuStripChanged += TreeView_ContextMenuStripChanged;
		}
		
		private void TreeView_ContextMenuStripChanged(object sender, EventArgs e)
		{
			//sanity check objects
			if (treeView == null || options == null || objectExplorerService == null)
			{
				return;
			}

			if (treeView.SelectedNode == null || treeView.ContextMenuStrip == null)
			{
				return;
			}

			if (treeView.ContextMenuStrip.Items == null)
			{
				return;
			}

			//get the selected tree node
			objectExplorerService.GetSelectedNodes(out int arraySize, out INodeInformation[] nodes);
			if (arraySize == 0 || nodes.Length == 0)
			{
				return;
			}

			//get meta data from tree node
			NodeInfo nodeInfo = nodes[0].GetInfo();

			//build context menu
			ToolStripMenuItem myScriptsMenu = new ToolStripMenuItem(options.Text);
			if (options.ShowIcon)
			{
				myScriptsMenu.Image = Properties.Resources.plus;
			}

			if (options.MenuItems != null)
			{
				foreach (var menuItem in options.MenuItems)
				{
					if (!menuItem.Enabled || menuItem.Name == string.Empty)
					{
						continue;
					}

					if (menuItem.Context == "All" || menuItem.Context == nodes[0].UrnPath)
					{
						MenuItemInstance instance = new MenuItemInstance(menuItem, nodeInfo);

						ToolStripMenuItem s = new ToolStripMenuItem(menuItem.Name)
						{
							Tag = instance
						};
						s.Click += Menu_Click;

						myScriptsMenu.DropDownItems.Add(s);
					}
				}
			}

			if (myScriptsMenu.DropDownItems.Count > 0 && options.ShowAddButton)
			{
				myScriptsMenu.DropDownItems.Add(new ToolStripSeparator());
			}


			if (options.ShowAddButton)
			{
				ToolStripMenuItem add = new ToolStripMenuItem("Add menu item");
				add.Click += Add_Click;
				add.Tag = nodeInfo;
				myScriptsMenu.DropDownItems.Add(add);
			}

			if (myScriptsMenu.DropDownItems.Count == 0)
			{
				return;
			}

			treeView.ContextMenuStrip.Items.Add(myScriptsMenu);
			treeView.ContextMenuStrip.Items.Add(new ToolStripSeparator());
		}

		private void Add_Click(object sender, EventArgs e)
		{
			NodeInfo nodeInfo = (NodeInfo)(sender as ToolStripMenuItem).Tag;

			AddMenuItem add = new AddMenuItem(nodeInfo);
			if (add.ShowDialog() == DialogResult.OK)
			{
				options.MenuItems.Add(add.GetMenuItem());
				options.SaveSettingsToStorage();
			}
		}
				

		private void Menu_Click(object sender, EventArgs e)
		{
			if (treeView == null || sender == null)
			{
				return;
			}

			if (treeView.SelectedNode == null)
			{
				return;
			}

			ToolStripMenuItem tool = (sender as ToolStripMenuItem);

			if (tool.Tag == null)
			{
				return;
			}

			MenuItemInstance itemInstance = (MenuItemInstance)tool.Tag;

			string script;

			if (File.Exists(itemInstance.MenuItem.Path))
			{
				try
				{
					script = File.ReadAllText(itemInstance.MenuItem.Path);
					script = $"-- File:\t\t{itemInstance.MenuItem.Path}{Environment.NewLine}" + script;
				}
				catch (Exception ex)
				{
					Error($"Error reading {itemInstance.MenuItem.Path}: {ex.Message}");
					return;
				}
			}
			else
			{
				script = itemInstance.MenuItem.Path;
			}


			script = script
					.Replace("{SERVER}", itemInstance.NodeInfo.Server)
					.Replace("{DATABASE}", itemInstance.NodeInfo.Database)
					.Replace("{TABLE}", itemInstance.NodeInfo.Table)
					.Replace("{STORED_PROCEDURE}", itemInstance.NodeInfo.StoredProcedure)
					.Replace("{FUNCTION}", itemInstance.NodeInfo.Function)
					.Replace("{SCHEMA}", itemInstance.NodeInfo.Schema)
					.Replace("{JOB}", itemInstance.NodeInfo.Job);

			DTE2 dte = (DTE2)this.GetService(typeof(DTE));
			if (dte == null)
			{
				return;
			}

			IScriptFactory scriptFactory = ServiceCache.ScriptFactory;
			if (scriptFactory == null)
			{
				return;
			}

			scriptFactory.CreateNewBlankScript(ScriptType.Sql);

			if (dte.ActiveDocument != null)
			{
				TextSelection ts = (TextSelection)dte.ActiveDocument.Selection;
				ts.Insert(script, (int)vsInsertFlags.vsInsertFlagsInsertAtStart);

				if (itemInstance.MenuItem.Execute)
				{
					if (itemInstance.MenuItem.Confirm)
					{
						Warning($"Execute \"{itemInstance.MenuItem.Name}\"?{Environment.NewLine}{Environment.NewLine}{itemInstance.NodeInfo}", () =>
						{
							dte.ActiveDocument.DTE.ExecuteCommand("Query.Execute");
						});
					}
					else
					{
						dte.ActiveDocument.DTE.ExecuteCommand("Query.Execute");
					}
				}
			}
		}

		private void Warning(string message, Action action)
		{
			Show(message, MessageBoxIcon.Warning, MessageBoxButtons.OKCancel, action);
		}

		private void Error(string message)
		{
			Show(message, MessageBoxIcon.Error);
		}

		private void Show(string message, MessageBoxIcon icon, MessageBoxButtons buttons = MessageBoxButtons.OK, Action action = null)
		{
			if (MessageBox.Show(message, "SSMS Object Explorer Menu", buttons, icon) == DialogResult.OK)
			{
				action?.Invoke();
			}
		}
	}
}
