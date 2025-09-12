using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MenuItem = SSMSObjectExplorerMenu.objects.MenuItem;

namespace SSMSObjectExplorerMenu
{
	public partial class AddMenuItem : Form
	{		
		public AddMenuItem(NodeInfo nodeInfo)
		{
			InitializeComponent();

			labelVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			comboContext.Text = nodeInfo.UrnPath;
			this.ActiveControl = textName;
			buttonOpen.Visible = false;
		}

		public MenuItem GetMenuItem()
		{
			return new MenuItem(true, comboContext.Text, textName.Text, textPath.Text, checkExecute.Checked, checkConfirm.Checked, listViewUserDefinedParam.GetUserDefinedParams());
		}

		
		private void textName_TextChanged(object sender, EventArgs e)
		{
			ValidateInputs();
		}

		private void textPath_TextChanged(object sender, EventArgs e)
		{
			ValidateInputs();
		}

		private void ValidateInputs()
		{ 
			if (comboContext.Text.Trim().Length > 0
				&& textName.Text.Trim().Length > 0
				&& textPath.Text.Trim().Length > 0)
			{
				buttonOK.Enabled = true;
				return;
			}
			buttonOK.Enabled = false;
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{ 
				textPath.Text = openFileDialog.FileName;
			}
		}

		private void radioScript_CheckedChanged(object sender, EventArgs e)
		{
			updateDisplay();
		}

		private void radioPath_CheckedChanged(object sender, EventArgs e)
		{
			updateDisplay();
		}


		private void updateDisplay()
		{
			textPath.Text = string.Empty;
			buttonOpen.Visible = radioPath.Checked;
		}

		private void checkConfirm_CheckedChanged(object sender, EventArgs e)
		{
			if (checkConfirm.Checked)
			{ 
				checkExecute.Checked = true;
			}
		}

		private void checkExecute_CheckedChanged(object sender, EventArgs e)
		{
			if (!checkExecute.Checked)
			{
				checkConfirm.Checked = false;
			}
		}

        private void buttonAddUserDefinedParam_Click(object sender, EventArgs e)
        {
            var argumentNamesInUse = this.listViewUserDefinedParam.Items.Cast<ListViewItem>().Select(item => item.Text)
				.Concat(Utils.ParametersFromContext);
            var addDialog = new AddUserDefinedParameter(argumentNamesInUse);
            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                var newParam = addDialog.Parameter;
                var newListViewItem = new ListViewItem { Text = newParam.Name, Tag = newParam };
                newListViewItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = Enum.GetName(typeof(UserDefinedParameterType), newParam.Type) });
                listViewUserDefinedParam.Items.Add(newListViewItem);
            }
        }

        private void buttonRemoveUserDefinedParam_Click(object sender, EventArgs e)
        {
            var selectedItems = this.listViewUserDefinedParam.Items.Cast<ListViewItem>().Where(item => item.Selected);
            if (selectedItems.Any() &&
                DialogResult.Yes == MessageBox.Show("Are you sure?", "Deleting parameter", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                foreach (var item in selectedItems)
                {
                    this.listViewUserDefinedParam.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("You must select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
