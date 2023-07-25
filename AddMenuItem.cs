﻿using SSMSObjectExplorerMenu.objects;
using System;
using System.Windows.Forms;
using MenuItem = SSMSObjectExplorerMenu.objects.MenuItem;

namespace SSMSObjectExplorerMenu
{
	public partial class AddMenuItem : Form
	{		
		public AddMenuItem(NodeInfo nodeInfo)
		{
			InitializeComponent();

			comboContext.SelectedItem = ToContext(nodeInfo.UrnPath).ToString();

			this.ActiveControl = textName;
		}

		public MenuItem GetMenuItem()
		{
			return new MenuItem(true, ToContext(comboContext.SelectedItem.ToString()), textName.Text, textPath.Text, checkExecute.Checked, checkConfirm.Checked);
		}

		private static Context ToContext(string value)
		{
			Context context;
			if (Enum.TryParse(value, out context))
			{
				return context;
			}
			return Context.All;
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
			if (textName.Text.Trim().Length > 0
				&& textPath.Text.Trim().Length > 0)
			{
				buttonOK.Enabled = true;
				return;
			}
			buttonOK.Enabled = false;
		}
	}
}