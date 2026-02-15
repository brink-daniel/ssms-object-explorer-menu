using SSMSObjectExplorerMenu.objects;

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
			this.buttonAddCustomList = new System.Windows.Forms.Button();
			this.buttonRemoveCustomList = new System.Windows.Forms.Button();
			this.labelCustomList = new System.Windows.Forms.Label();
			this.panelCustomList = new System.Windows.Forms.Panel();
			this.labelDefaultValue = new System.Windows.Forms.Label();
			this.textPlaceHolder = new System.Windows.Forms.TextBox();
			this.panelContainerListView = new System.Windows.Forms.Panel();
			this.panelCustomList.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxParameterName
			// 
			this.textBoxParameterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxParameterName.Location = new System.Drawing.Point(155, 19);
			this.textBoxParameterName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxParameterName.Name = "textBoxParameterName";
			this.textBoxParameterName.Size = new System.Drawing.Size(261, 26);
			this.textBoxParameterName.TabIndex = 0;
			// 
			// comboBoxParameterType
			// 
			this.comboBoxParameterType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxParameterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxParameterType.FormattingEnabled = true;
			this.comboBoxParameterType.Location = new System.Drawing.Point(156, 55);
			this.comboBoxParameterType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.comboBoxParameterType.Name = "comboBoxParameterType";
			this.comboBoxParameterType.Size = new System.Drawing.Size(260, 28);
			this.comboBoxParameterType.TabIndex = 1;
			this.comboBoxParameterType.SelectedValueChanged += new System.EventHandler(this.comboBoxParameterType_SelectedValueChanged);
			// 
			// labelParameterName
			// 
			this.labelParameterName.AutoSize = true;
			this.labelParameterName.Location = new System.Drawing.Point(20, 22);
			this.labelParameterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelParameterName.Name = "labelParameterName";
			this.labelParameterName.Size = new System.Drawing.Size(127, 20);
			this.labelParameterName.TabIndex = 2;
			this.labelParameterName.Text = "Parameter name";
			// 
			// labelParameterType
			// 
			this.labelParameterType.AutoSize = true;
			this.labelParameterType.Location = new System.Drawing.Point(20, 58);
			this.labelParameterType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelParameterType.Name = "labelParameterType";
			this.labelParameterType.Size = new System.Drawing.Size(117, 20);
			this.labelParameterType.TabIndex = 3;
			this.labelParameterType.Text = "Parameter type";
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(183, 353);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(112, 35);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(303, 353);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(112, 35);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonAddCustomList
			// 
			this.buttonAddCustomList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddCustomList.Location = new System.Drawing.Point(361, 25);
			this.buttonAddCustomList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonAddCustomList.Name = "buttonAddCustomList";
			this.buttonAddCustomList.Size = new System.Drawing.Size(34, 35);
			this.buttonAddCustomList.TabIndex = 7;
			this.buttonAddCustomList.Text = "+";
			this.buttonAddCustomList.UseVisualStyleBackColor = true;
			this.buttonAddCustomList.Click += new System.EventHandler(this.buttonAddCustomList_Click);
			// 
			// buttonRemoveCustomList
			// 
			this.buttonRemoveCustomList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemoveCustomList.Enabled = false;
			this.buttonRemoveCustomList.Location = new System.Drawing.Point(361, 69);
			this.buttonRemoveCustomList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonRemoveCustomList.Name = "buttonRemoveCustomList";
			this.buttonRemoveCustomList.Size = new System.Drawing.Size(34, 35);
			this.buttonRemoveCustomList.TabIndex = 8;
			this.buttonRemoveCustomList.Text = "-";
			this.buttonRemoveCustomList.UseVisualStyleBackColor = true;
			this.buttonRemoveCustomList.Click += new System.EventHandler(this.buttonRemoveCustomList_Click);
			// 
			// labelCustomList
			// 
			this.labelCustomList.AutoSize = true;
			this.labelCustomList.Location = new System.Drawing.Point(4, 0);
			this.labelCustomList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelCustomList.Name = "labelCustomList";
			this.labelCustomList.Size = new System.Drawing.Size(108, 20);
			this.labelCustomList.TabIndex = 9;
			this.labelCustomList.Text = "List of options";
			// 
			// panelCustomList
			// 
			this.panelCustomList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelCustomList.Controls.Add(this.panelContainerListView);
			this.panelCustomList.Controls.Add(this.labelCustomList);
			this.panelCustomList.Controls.Add(this.buttonRemoveCustomList);
			this.panelCustomList.Controls.Add(this.buttonAddCustomList);
			this.panelCustomList.Location = new System.Drawing.Point(15, 125);
			this.panelCustomList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panelCustomList.Name = "panelCustomList";
			this.panelCustomList.Size = new System.Drawing.Size(400, 214);
			this.panelCustomList.TabIndex = 10;
			// 
			// labelDefaultValue
			// 
			this.labelDefaultValue.AutoSize = true;
			this.labelDefaultValue.Location = new System.Drawing.Point(20, 94);
			this.labelDefaultValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelDefaultValue.Name = "labelDefaultValue";
			this.labelDefaultValue.Size = new System.Drawing.Size(102, 20);
			this.labelDefaultValue.TabIndex = 11;
			this.labelDefaultValue.Text = "Default value";
			// 
			// textPlaceHolder
			// 
			this.textPlaceHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textPlaceHolder.Location = new System.Drawing.Point(156, 91);
			this.textPlaceHolder.Name = "textPlaceHolder";
			this.textPlaceHolder.Size = new System.Drawing.Size(260, 26);
			this.textPlaceHolder.TabIndex = 12;
			this.textPlaceHolder.Visible = false;
			// 
			// panelContainerListView
			// 
			this.panelContainerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelContainerListView.Location = new System.Drawing.Point(9, 25);
			this.panelContainerListView.Name = "panelContainerListView";
			this.panelContainerListView.Size = new System.Drawing.Size(345, 186);
			this.panelContainerListView.TabIndex = 10;
			// 
			// AddUserDefinedParameter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 402);
			this.Controls.Add(this.textPlaceHolder);
			this.Controls.Add(this.labelDefaultValue);
			this.Controls.Add(this.panelCustomList);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelParameterType);
			this.Controls.Add(this.labelParameterName);
			this.Controls.Add(this.comboBoxParameterType);
			this.Controls.Add(this.textBoxParameterName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddUserDefinedParameter";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add user-defined parameter...";
			this.Resize += new System.EventHandler(this.AddUserDefinedParameter_Resize);
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
        private System.Windows.Forms.Button buttonAddCustomList;
        private System.Windows.Forms.Button buttonRemoveCustomList;
        private System.Windows.Forms.Label labelCustomList;
        private System.Windows.Forms.Panel panelCustomList;
        private System.Windows.Forms.Label labelDefaultValue;
		private System.Windows.Forms.TextBox textPlaceHolder;
		private System.Windows.Forms.Panel panelContainerListView;
	}
}