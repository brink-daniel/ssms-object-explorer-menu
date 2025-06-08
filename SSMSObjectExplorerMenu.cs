using EnvDTE;
using EnvDTE80;
using Microsoft.SqlServer.Management.UI.VSIntegration;
using Microsoft.SqlServer.Management.UI.VSIntegration.Editors;
using Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[ProvideAutoLoad("d114938f-591c-46cf-a785-500a82d97410", PackageAutoLoadFlags.BackgroundLoad)] //CommandGuids.ObjectExplorerToolWindowIDString
	[ProvideOptionPage(typeof(OptionsDialogPage), "SQL Server Object Explorer", "SSMS Object Explorer Menu", 0, 0, true)]
	public sealed class SSMSObjectExplorerMenu : AsyncPackage
	{
		private OptionsDialogPage options;
		private TreeView treeView;
		private IObjectExplorerService objectExplorerService;

		public SSMSObjectExplorerMenu()
		{
		}

		protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

			//load settings from options dialog
			(this as IVsPackage).GetAutomationObject("SQL Server Object Explorer.SSMS Object Explorer Menu", out object automationObject);
			if (automationObject == null)
			{
				Error("Automation Object not found");
				return;
			}
			options = (OptionsDialogPage)automationObject;

			//find tree control in the Object Explorer window
			objectExplorerService = GetObjectExplorerService();
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


		private IObjectExplorerService GetObjectExplorerService()
		{
			return (IObjectExplorerService)this.GetService(typeof(IObjectExplorerService)); ;
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

			if (myScriptsMenu.DropDownItems.Count > 0
				&& (
					options.ShowNewButton
					|| options.ShowOptionsButton
					|| options.ShowImportButton
					|| options.ShowExportButton
				))
			{
				myScriptsMenu.DropDownItems.Add(new ToolStripSeparator());
			}


			if (options.ShowNewButton)
			{
				ToolStripMenuItem add = new ToolStripMenuItem("New");
				add.Click += Add_Click;
				add.Tag = nodeInfo;
				myScriptsMenu.DropDownItems.Add(add);
			}

			if (options.ShowImportButton)
			{
				ToolStripMenuItem imp = new ToolStripMenuItem("Import");
				imp.Click += Import_Click;
				imp.Tag = nodeInfo;
				myScriptsMenu.DropDownItems.Add(imp);
			}

			if (options.ShowExportButton)
			{
				ToolStripMenuItem exp = new ToolStripMenuItem("Export");
				exp.Click += Export_Click;
				exp.Tag = nodeInfo;
				myScriptsMenu.DropDownItems.Add(exp);
			}			

			if (options.ShowOptionsButton)
			{
				ToolStripMenuItem opt = new ToolStripMenuItem("Options");
				opt.Click += Options_Click;
				opt.Tag = nodeInfo;
				myScriptsMenu.DropDownItems.Add(opt);
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

			DialogResult d = add.ShowDialog();

			if (d == DialogResult.OK)
			{
				options.MenuItems.Add(add.GetMenuItem());
				options.SaveSettingsToStorage();
			}
		}

		private void Options_Click(object sender, EventArgs e)
		{
			ShowOptionPage(typeof(OptionsDialogPage));
		}

		private void Export_Click(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog
			{
				AddExtension = true,
				Filter = "Xml (*.xml)|*.xml",
				DefaultExt = "xml",
				Title = "Export menu items as XML",
				ValidateNames = true
			};

			if (save.ShowDialog() == DialogResult.OK)
			{
				try
				{
					File.WriteAllText(save.FileName, options.MenuItemsXml);
				}
				catch (Exception ex)
				{
					Error($"Error saving to {save.FileName}: {ex.Message}");
				}
			}
		}

		private void Import_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog
			{
				AddExtension = true,
				CheckFileExists = true,
				DefaultExt = "xml",
				Filter = "Xml (*.xml)|*.xml",
				Multiselect = false,
				Title = "Import menu items from XML"
			};

			if (open.ShowDialog() == DialogResult.OK)
			{
				int count = 0;

				try
				{
					List<objects.MenuItem> menuItems = File.ReadAllText(open.FileName).DeserializeObject<List<objects.MenuItem>>();

					foreach (objects.MenuItem item in menuItems)
					{
						if (options.MenuItems.FindIndex(x => (x.Name == item.Name && x.Context == item.Context)) == -1)
						{
							options.MenuItems.Add(item);
							count += 1;
						}
					}

					options.SaveSettingsToStorage();

					Show($"{count} menu item{ ((count == 1) ? "":"s") } imported", MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					Error($"Error importing menu items from {open.FileName}: {ex.Message}");
				}
			}
		}


		private async void Menu_Click(object sender, EventArgs e)
		{		
			await JoinableTaskFactory.SwitchToMainThreadAsync(DisposalToken);

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

			if (File.Exists(itemInstance.MenuItem.Script))
			{
				try
				{
					script = File.ReadAllText(itemInstance.MenuItem.Script);
					script = $"-- File:\t\t{itemInstance.MenuItem.Script}{Environment.NewLine}" + script;
				}
				catch (Exception ex)
				{
					Error($"Error reading {itemInstance.MenuItem.Script}: {ex.Message}");
					return;
				}
			}
			else
			{
				script = itemInstance.MenuItem.Script;
			}


			script = script
					.Replace("{SERVER}", itemInstance.NodeInfo.Server)
					.Replace("{DATABASE}", itemInstance.NodeInfo.Database)
					.Replace("{TABLE}", itemInstance.NodeInfo.Table)
					.Replace("{VIEW}", itemInstance.NodeInfo.View)
					.Replace("{STORED_PROCEDURE}", itemInstance.NodeInfo.StoredProcedure)
					.Replace("{FUNCTION}", itemInstance.NodeInfo.Function)
					.Replace("{SCHEMA}", itemInstance.NodeInfo.Schema)
					.Replace("{JOB}", itemInstance.NodeInfo.Job)
					.Replace("{YYYY-MM-DD}", DateTime.Now.ToString("yyyy-MM-dd"))
					.Replace("{HH:mm:ss}", DateTime.Now.ToString("HH:mm:ss"))
					.Replace("{YYYY-MM-DD HH:mm:ss}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));




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
						if (MessageBox.Show($"Execute \"{itemInstance.MenuItem.Name}\"?{Environment.NewLine}{Environment.NewLine}{itemInstance.NodeInfo}", "SSMS Object Explorer Menu", MessageBoxButtons.OKCancel) == DialogResult.OK)
						{
							dte.ActiveDocument.DTE.ExecuteCommand("Query.Execute");
						}
					}
					else
					{
						dte.ActiveDocument.DTE.ExecuteCommand("Query.Execute");
					}
				}
			}
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
