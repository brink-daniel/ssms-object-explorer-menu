using EnvDTE;
using EnvDTE80;
using Microsoft.SqlServer.Management.UI.VSIntegration;
using Microsoft.SqlServer.Management.UI.VSIntegration.Editors;
using Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SQLMedic
{
	[ProvideAutoLoad("d114938f-591c-46cf-a785-500a82d97410")] //CommandGuids.ObjectExplorerToolWindowIDString
	[ProvideOptionPage(typeof(OptionsDialogPage), "SQL Server Object Explorer", "SQLMedic", 0, 0, true)]
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
			(this as IVsPackage).GetAutomationObject("SQL Server Object Explorer.SQLMedic", out object automationObject);
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

			//build SQLMedic context menu
			ToolStripMenuItem sqlMedicMenu = new ToolStripMenuItem(options.BrandingText);
			if (options.BrandingIcon)
			{
				sqlMedicMenu.Image = Properties.Resources.plus;
			}

			foreach (var o in options.ToArray())
			{
				if (!o.Enabled || o.Name == string.Empty)
				{
					continue;
				}

				if (o.Context == Context.All || o.Context.GetStringValue() == nodes[0].UrnPath)
				{
					o.NodeInfo = nodeInfo;

					ToolStripMenuItem s = new ToolStripMenuItem(o.Name)
					{
						Tag = o
					};
					s.Click += Menu_Click;

					sqlMedicMenu.DropDownItems.Add(s);
				}
			}

			if (options.BrandingCustomize || sqlMedicMenu.DropDownItems.Count == 0)
			{
				if (sqlMedicMenu.DropDownItems.Count > 0)
				{
					sqlMedicMenu.DropDownItems.Add(new ToolStripSeparator());
				}
				ToolStripMenuItem custom = new ToolStripMenuItem("Customize");
				custom.Click += Customize_Click;
				custom.Tag = nodeInfo;
				sqlMedicMenu.DropDownItems.Add(custom);
			}

			treeView.ContextMenuStrip.Items.Add(sqlMedicMenu);
			treeView.ContextMenuStrip.Items.Add(new ToolStripSeparator());
		}

		private void Customize_Click(object sender, EventArgs e)
		{
			NodeInfo nodeInfo = (NodeInfo)(sender as ToolStripMenuItem).Tag;

			Info($"The context for the current location is: {nodeInfo.UrnPath}{Environment.NewLine}{Environment.NewLine}{nodeInfo}{Environment.NewLine}Configure new menu item via the Options Dialog > SQL Server Object Explorer > SQLMedic.{Environment.NewLine}{Environment.NewLine}Open the Options dialog?", () =>
			{
				DTE2 dte = (DTE2)this.GetService(typeof(DTE));
				dte?.ExecuteCommand("Tools.Options");
			});
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

			Option option = (Option)tool.Tag;

			string script;

			if (File.Exists(option.Path))
			{
				try
				{
					script = File.ReadAllText(option.Path);
					script = $"-- File:\t\t{option.Path}{Environment.NewLine}" + script;
				}
				catch (Exception ex)
				{
					Error($"Error reading {option.Path}: {ex.Message}");
					return;
				}
			}
			else
			{
				script = option.Path;
			}

			script = script
					.Replace("{SERVER}", option.NodeInfo.Server)
					.Replace("{DATABASE}", option.NodeInfo.Database)
					.Replace("{TABLE}", option.NodeInfo.Table)
					.Replace("{STORED_PROCEDURE}", option.NodeInfo.StoredProcedure)
					.Replace("{SCHEMA}", option.NodeInfo.Schema)
					.Replace("{JOB}", option.NodeInfo.Job);

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

				if (option.Execute)
				{
					dte.ActiveDocument.DTE.ExecuteCommand("Query.Execute");
				}
			}
		}

		private void Info(string message, Action action)
		{
			Show(message, MessageBoxIcon.Information, MessageBoxButtons.OKCancel, action);
		}

		private void Error(string message)
		{
			Show(message, MessageBoxIcon.Error);
		}

		private void Show(string message, MessageBoxIcon icon, MessageBoxButtons buttons = MessageBoxButtons.OK, Action action = null)
		{
			if (MessageBox.Show(message, "SQLMedic", buttons, icon) == DialogResult.OK)
			{
				action?.Invoke();
			}
		}
	}
}
