namespace SSMSObjectExplorerMenu
{
	partial class AddMenuItem
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMenuItem));
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.textName = new System.Windows.Forms.TextBox();
			this.comboContext = new System.Windows.Forms.ComboBox();
			this.checkExecute = new System.Windows.Forms.CheckBox();
			this.checkConfirm = new System.Windows.Forms.CheckBox();
			this.textPath = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(410, 239);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Enabled = false;
			this.buttonOK.Location = new System.Drawing.Point(329, 239);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// textName
			// 
			this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textName.Location = new System.Drawing.Point(88, 12);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(397, 20);
			this.textName.TabIndex = 0;
			this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
			// 
			// comboContext
			// 
			this.comboContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboContext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboContext.FormattingEnabled = true;
			this.comboContext.Items.AddRange(new object[] {
            "All",
            "Server",
            "Server_DatabasesFolder",
            "Server_Database",
            "Server_Database_Table",
            "Server_Database_UserTablesFolder",
            "Server_Database_StoredProcedure",
            "Server_Database_StoredProceduresFolder",
            "Server_JobServer",
            "Server_JobServer_JobsFolder",
            "Server_JobServer_Job"});
			this.comboContext.Location = new System.Drawing.Point(88, 38);
			this.comboContext.Name = "comboContext";
			this.comboContext.Size = new System.Drawing.Size(397, 21);
			this.comboContext.TabIndex = 1;
			// 
			// checkExecute
			// 
			this.checkExecute.AutoSize = true;
			this.checkExecute.Checked = true;
			this.checkExecute.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkExecute.Location = new System.Drawing.Point(88, 65);
			this.checkExecute.Name = "checkExecute";
			this.checkExecute.Size = new System.Drawing.Size(65, 17);
			this.checkExecute.TabIndex = 2;
			this.checkExecute.Text = "Execute";
			this.checkExecute.UseVisualStyleBackColor = true;
			// 
			// checkConfirm
			// 
			this.checkConfirm.AutoSize = true;
			this.checkConfirm.Location = new System.Drawing.Point(88, 88);
			this.checkConfirm.Name = "checkConfirm";
			this.checkConfirm.Size = new System.Drawing.Size(135, 17);
			this.checkConfirm.TabIndex = 3;
			this.checkConfirm.Text = "Confirm before execute";
			this.checkConfirm.UseVisualStyleBackColor = true;
			// 
			// textPath
			// 
			this.textPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textPath.Location = new System.Drawing.Point(88, 111);
			this.textPath.Multiline = true;
			this.textPath.Name = "textPath";
			this.textPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textPath.Size = new System.Drawing.Size(397, 122);
			this.textPath.TabIndex = 4;
			this.textPath.Text = resources.GetString("textPath.Text");
			this.textPath.WordWrap = false;
			this.textPath.TextChanged += new System.EventHandler(this.textPath_TextChanged);
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(12, 15);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(35, 13);
			this.labelName.TabIndex = 7;
			this.labelName.Text = "Name";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Context";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Path / Script";
			// 
			// AddMenuItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(497, 274);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.textPath);
			this.Controls.Add(this.checkConfirm);
			this.Controls.Add(this.checkExecute);
			this.Controls.Add(this.comboContext);
			this.Controls.Add(this.textName);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddMenuItem";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SSMS Object Explorer Menu | Add menu item";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.ComboBox comboContext;
		private System.Windows.Forms.CheckBox checkExecute;
		private System.Windows.Forms.CheckBox checkConfirm;
		private System.Windows.Forms.TextBox textPath;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}