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
            this.labelVersion = new System.Windows.Forms.Label();
            this.listViewCustomArgs = new System.Windows.Forms.ListView();
            this.ArgumentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArgumentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddCustomArg = new System.Windows.Forms.Button();
            this.buttonRemoveCustomArg = new System.Windows.Forms.Button();
            this.labelCustomArgs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(455, 440);
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
            this.buttonOK.Location = new System.Drawing.Point(374, 440);
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
            "Server/DatabasesFolder",
            "Server/Database",
            "Server/Database/Table",
            "Server/Database/UserTablesFolder",
            "Server/Database/View",
            "Server/Database/StoredProcedure",
            "Server/Database/StoredProceduresFolder",
            "Server/JobServer",
            "Server/JobServer/JobsFolder",
            "Server/JobServer/Job"});
            this.comboContext.Location = new System.Drawing.Point(88, 38);
            this.comboContext.Name = "comboContext";
            this.comboContext.Size = new System.Drawing.Size(442, 21);
            this.comboContext.TabIndex = 1;
            // 
            // checkExecute
            // 
            this.checkExecute.AutoSize = true;
            this.checkExecute.Location = new System.Drawing.Point(88, 65);
            this.checkExecute.Name = "checkExecute";
            this.checkExecute.Size = new System.Drawing.Size(65, 17);
            this.checkExecute.TabIndex = 2;
            this.checkExecute.Text = "Execute";
            this.checkExecute.UseVisualStyleBackColor = true;
            this.checkExecute.CheckedChanged += new System.EventHandler(this.checkExecute_CheckedChanged);
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
            this.checkConfirm.CheckedChanged += new System.EventHandler(this.checkConfirm_CheckedChanged);
            // 
            // textPath
            // 
            this.textPath.AcceptsReturn = true;
            this.textPath.AcceptsTab = true;
            this.textPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPath.Location = new System.Drawing.Point(88, 245);
            this.textPath.Multiline = true;
            this.textPath.Name = "textPath";
            this.textPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textPath.Size = new System.Drawing.Size(442, 189);
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
            this.radioPath.Location = new System.Drawing.Point(146, 222);
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
            this.radioScript.Location = new System.Drawing.Point(88, 222);
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
            this.buttonOpen.Location = new System.Drawing.Point(505, 219);
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
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(12, 445);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(31, 13);
            this.labelVersion.TabIndex = 13;
            this.labelVersion.Text = "0.0.0";
            // 
            // listViewCustomArgs
            // 
            this.listViewCustomArgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ArgumentName,
            this.ArgumentType});
            this.listViewCustomArgs.HideSelection = false;
            this.listViewCustomArgs.Location = new System.Drawing.Point(88, 135);
            this.listViewCustomArgs.Name = "listViewCustomArgs";
            this.listViewCustomArgs.Size = new System.Drawing.Size(275, 75);
            this.listViewCustomArgs.TabIndex = 15;
            this.listViewCustomArgs.UseCompatibleStateImageBehavior = false;
            this.listViewCustomArgs.View = System.Windows.Forms.View.Details;
            // 
            // ArgumentName
            // 
            this.ArgumentName.Text = "Argument name";
            this.ArgumentName.Width = 160;
            // 
            // ArgumentType
            // 
            this.ArgumentType.Text = "Argument type";
            this.ArgumentType.Width = 106;
            // 
            // buttonAddCustomArg
            // 
            this.buttonAddCustomArg.Location = new System.Drawing.Point(374, 135);
            this.buttonAddCustomArg.Name = "buttonAddCustomArg";
            this.buttonAddCustomArg.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCustomArg.TabIndex = 16;
            this.buttonAddCustomArg.Text = "Add";
            this.buttonAddCustomArg.UseVisualStyleBackColor = true;
            this.buttonAddCustomArg.Click += new System.EventHandler(this.buttonAddCustomArg_Click);
            // 
            // buttonRemoveCustomArg
            // 
            this.buttonRemoveCustomArg.Location = new System.Drawing.Point(374, 164);
            this.buttonRemoveCustomArg.Name = "buttonRemoveCustomArg";
            this.buttonRemoveCustomArg.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveCustomArg.TabIndex = 18;
            this.buttonRemoveCustomArg.Text = "Remove";
            this.buttonRemoveCustomArg.UseVisualStyleBackColor = true;
            this.buttonRemoveCustomArg.Click += new System.EventHandler(this.buttonRemoveCustomArg_Click);
            // 
            // labelCustomArgs
            // 
            this.labelCustomArgs.AutoSize = true;
            this.labelCustomArgs.Location = new System.Drawing.Point(91, 117);
            this.labelCustomArgs.Name = "labelCustomArgs";
            this.labelCustomArgs.Size = new System.Drawing.Size(151, 13);
            this.labelCustomArgs.TabIndex = 19;
            this.labelCustomArgs.Text = "List of user-defined arguments:";
            // 
            // AddMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 475);
            this.Controls.Add(this.labelCustomArgs);
            this.Controls.Add(this.buttonRemoveCustomArg);
            this.Controls.Add(this.buttonAddCustomArg);
            this.Controls.Add(this.listViewCustomArgs);
            this.Controls.Add(this.labelVersion);
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
            this.Text = "SSMS Object Explorer Menu | New menu item";
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
		private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.ListView listViewCustomArgs;
        private System.Windows.Forms.ColumnHeader ArgumentName;
        private System.Windows.Forms.ColumnHeader ArgumentType;
        private System.Windows.Forms.Button buttonAddCustomArg;
        private System.Windows.Forms.Button buttonRemoveCustomArg;
        private System.Windows.Forms.Label labelCustomArgs;
    }
}