namespace SSMSObjectExplorerMenu
{
    partial class AddUserDefinedParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserDefinedParameter));
            this.textBoxParameterName = new System.Windows.Forms.TextBox();
            this.comboBoxParameterType = new System.Windows.Forms.ComboBox();
            this.labelParameterName = new System.Windows.Forms.Label();
            this.labelParameterType = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listViewCustomList = new System.Windows.Forms.ListView();
            this.buttonAddCustomList = new System.Windows.Forms.Button();
            this.buttonRemoveCustomList = new System.Windows.Forms.Button();
            this.labelCustomList = new System.Windows.Forms.Label();
            this.panelCustomList = new System.Windows.Forms.Panel();
            this.panelCustomList.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxParameterName
            // 
            this.textBoxParameterName.Location = new System.Drawing.Point(103, 14);
            this.textBoxParameterName.Name = "textBoxParameterName";
            this.textBoxParameterName.Size = new System.Drawing.Size(170, 20);
            this.textBoxParameterName.TabIndex = 0;
            // 
            // comboBoxParameterType
            // 
            this.comboBoxParameterType.FormattingEnabled = true;
            this.comboBoxParameterType.Location = new System.Drawing.Point(103, 56);
            this.comboBoxParameterType.Name = "comboBoxParameterType";
            this.comboBoxParameterType.Size = new System.Drawing.Size(170, 21);
            this.comboBoxParameterType.TabIndex = 1;
            this.comboBoxParameterType.SelectedValueChanged += new System.EventHandler(this.comboBoxParameterType_SelectedValueChanged);
            // 
            // labelParameterName
            // 
            this.labelParameterName.AutoSize = true;
            this.labelParameterName.Location = new System.Drawing.Point(13, 14);
            this.labelParameterName.Name = "labelParameterName";
            this.labelParameterName.Size = new System.Drawing.Size(87, 13);
            this.labelParameterName.TabIndex = 2;
            this.labelParameterName.Text = "Parameter name:";
            // 
            // labelParameterType
            // 
            this.labelParameterType.AutoSize = true;
            this.labelParameterType.Location = new System.Drawing.Point(13, 56);
            this.labelParameterType.Name = "labelParameterType";
            this.labelParameterType.Size = new System.Drawing.Size(81, 13);
            this.labelParameterType.TabIndex = 3;
            this.labelParameterType.Text = "Parameter type:";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(117, 203);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(198, 203);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // listViewCustomList
            // 
            this.listViewCustomList.HideSelection = false;
            this.listViewCustomList.LabelEdit = true;
            this.listViewCustomList.Location = new System.Drawing.Point(0, 18);
            this.listViewCustomList.Name = "listViewCustomList";
            this.listViewCustomList.Size = new System.Drawing.Size(228, 79);
            this.listViewCustomList.TabIndex = 6;
            this.listViewCustomList.UseCompatibleStateImageBehavior = false;
            // 
            // buttonAddCustomList
            // 
            this.buttonAddCustomList.Location = new System.Drawing.Point(234, 16);
            this.buttonAddCustomList.Name = "buttonAddCustomList";
            this.buttonAddCustomList.Size = new System.Drawing.Size(23, 23);
            this.buttonAddCustomList.TabIndex = 7;
            this.buttonAddCustomList.Text = "+";
            this.buttonAddCustomList.UseVisualStyleBackColor = true;
            this.buttonAddCustomList.Click += new System.EventHandler(this.buttonAddCustomList_Click);
            // 
            // buttonRemoveCustomList
            // 
            this.buttonRemoveCustomList.Location = new System.Drawing.Point(234, 45);
            this.buttonRemoveCustomList.Name = "buttonRemoveCustomList";
            this.buttonRemoveCustomList.Size = new System.Drawing.Size(23, 23);
            this.buttonRemoveCustomList.TabIndex = 8;
            this.buttonRemoveCustomList.Text = "-";
            this.buttonRemoveCustomList.UseVisualStyleBackColor = true;
            this.buttonRemoveCustomList.Click += new System.EventHandler(this.buttonRemoveCustomList_Click);
            // 
            // labelCustomList
            // 
            this.labelCustomList.AutoSize = true;
            this.labelCustomList.Location = new System.Drawing.Point(3, 2);
            this.labelCustomList.Name = "labelCustomList";
            this.labelCustomList.Size = new System.Drawing.Size(113, 13);
            this.labelCustomList.TabIndex = 9;
            this.labelCustomList.Text = "List of possible values:";
            // 
            // panelCustomList
            // 
            this.panelCustomList.Controls.Add(this.labelCustomList);
            this.panelCustomList.Controls.Add(this.buttonRemoveCustomList);
            this.panelCustomList.Controls.Add(this.buttonAddCustomList);
            this.panelCustomList.Controls.Add(this.listViewCustomList);
            this.panelCustomList.Location = new System.Drawing.Point(16, 95);
            this.panelCustomList.Name = "panelCustomList";
            this.panelCustomList.Size = new System.Drawing.Size(257, 100);
            this.panelCustomList.TabIndex = 10;
            // 
            // AddUserDefinedParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(285, 238);
            this.Controls.Add(this.panelCustomList);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelParameterType);
            this.Controls.Add(this.labelParameterName);
            this.Controls.Add(this.comboBoxParameterType);
            this.Controls.Add(this.textBoxParameterName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserDefinedParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adding new user-defined parameter...";
            this.panelCustomList.ResumeLayout(false);
            this.panelCustomList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxParameterName;
        private System.Windows.Forms.ComboBox comboBoxParameterType;
        private System.Windows.Forms.Label labelParameterName;
        private System.Windows.Forms.Label labelParameterType;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListView listViewCustomList;
        private System.Windows.Forms.Button buttonAddCustomList;
        private System.Windows.Forms.Button buttonRemoveCustomList;
        private System.Windows.Forms.Label labelCustomList;
        private System.Windows.Forms.Panel panelCustomList;
    }
}