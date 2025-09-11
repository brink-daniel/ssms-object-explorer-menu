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
            this.SuspendLayout();
            // 
            // textBoxParameterName
            // 
            this.textBoxParameterName.Location = new System.Drawing.Point(103, 24);
            this.textBoxParameterName.Name = "textBoxParameterName";
            this.textBoxParameterName.Size = new System.Drawing.Size(170, 20);
            this.textBoxParameterName.TabIndex = 0;
            // 
            // comboBoxParameterType
            // 
            this.comboBoxParameterType.FormattingEnabled = true;
            this.comboBoxParameterType.Location = new System.Drawing.Point(103, 66);
            this.comboBoxParameterType.Name = "comboBoxParameterType";
            this.comboBoxParameterType.Size = new System.Drawing.Size(170, 21);
            this.comboBoxParameterType.TabIndex = 1;
            // 
            // labelParameterName
            // 
            this.labelParameterName.AutoSize = true;
            this.labelParameterName.Location = new System.Drawing.Point(13, 24);
            this.labelParameterName.Name = "labelParameterName";
            this.labelParameterName.Size = new System.Drawing.Size(87, 13);
            this.labelParameterName.TabIndex = 2;
            this.labelParameterName.Text = "Parameter name:";
            // 
            // labelParameterType
            // 
            this.labelParameterType.AutoSize = true;
            this.labelParameterType.Location = new System.Drawing.Point(13, 66);
            this.labelParameterType.Name = "labelParameterType";
            this.labelParameterType.Size = new System.Drawing.Size(81, 13);
            this.labelParameterType.TabIndex = 3;
            this.labelParameterType.Text = "Parameter type:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(103, 126);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(198, 126);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AddUserDefinedParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 164);
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
    }
}