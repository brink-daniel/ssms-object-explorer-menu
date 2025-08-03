using SSMSObjectExplorerMenu.objects;
using System;
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
			return new MenuItem(true, comboContext.Text, textName.Text, textPath.Text, checkExecute.Checked, checkConfirm.Checked);
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
	}
}
