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
			this.radioPath = new System.Windows.Forms.RadioButton();
			this.radioScript = new System.Windows.Forms.RadioButton();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(455, 228);
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
			this.buttonOK.Location = new System.Drawing.Point(374, 228);
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
			this.textName.Size = new System.Drawing.Size(442, 20);
			this.textName.TabIndex = 0;
			this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
			// 
			// comboContext
			// 
			this.comboContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			this.comboContext.Size = new System.Drawing.Size(442, 21);
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
			this.textPath.AcceptsReturn = true;
			this.textPath.AcceptsTab = true;
			this.textPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textPath.Location = new System.Drawing.Point(88, 134);
			this.textPath.Multiline = true;
			this.textPath.Name = "textPath";
			this.textPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textPath.Size = new System.Drawing.Size(442, 88);
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
			// radioPath
			// 
			this.radioPath.AutoSize = true;
			this.radioPath.Location = new System.Drawing.Point(146, 111);
			this.radioPath.Name = "radioPath";
			this.radioPath.Size = new System.Drawing.Size(47, 17);
			this.radioPath.TabIndex = 10;
			this.radioPath.Text = "Path";
			this.radioPath.UseVisualStyleBackColor = true;
			this.radioPath.CheckedChanged += new System.EventHandler(this.radioPath_CheckedChanged);
			// 
			// radioScript
			// 
			this.radioScript.AutoSize = true;
			this.radioScript.Checked = true;
			this.radioScript.Location = new System.Drawing.Point(88, 111);
			this.radioScript.Name = "radioScript";
			this.radioScript.Size = new System.Drawing.Size(52, 17);
			this.radioScript.TabIndex = 11;
			this.radioScript.TabStop = true;
			this.radioScript.Text = "Script";
			this.radioScript.UseVisualStyleBackColor = true;
			this.radioScript.CheckedChanged += new System.EventHandler(this.radioScript_CheckedChanged);
			// 
			// buttonOpen
			// 
			this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpen.Location = new System.Drawing.Point(505, 108);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(25, 23);
			this.buttonOpen.TabIndex = 12;
			this.buttonOpen.Text = "...";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "sql";
			this.openFileDialog.FileName = "openFileDialog";
			this.openFileDialog.Filter = "SQL Server files (*.sql)|*.sql";
			// 
			// AddMenuItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 263);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.radioScript);
			this.Controls.Add(this.radioPath);
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
		private System.Windows.Forms.RadioButton radioPath;
		private System.Windows.Forms.RadioButton radioScript;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}