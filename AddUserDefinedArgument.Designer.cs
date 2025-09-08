namespace SSMSObjectExplorerMenu
{
    partial class AddUserDefinedArgument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserDefinedArgument));
            this.textBoxArgumentName = new System.Windows.Forms.TextBox();
            this.comboBoxArgumentType = new System.Windows.Forms.ComboBox();
            this.labelArgumentName = new System.Windows.Forms.Label();
            this.labelArgumentType = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxArgumentName
            // 
            this.textBoxArgumentName.Location = new System.Drawing.Point(103, 24);
            this.textBoxArgumentName.Name = "textBoxArgumentName";
            this.textBoxArgumentName.Size = new System.Drawing.Size(170, 20);
            this.textBoxArgumentName.TabIndex = 0;
            // 
            // comboBoxArgumentType
            // 
            this.comboBoxArgumentType.FormattingEnabled = true;
            this.comboBoxArgumentType.Location = new System.Drawing.Point(103, 66);
            this.comboBoxArgumentType.Name = "comboBoxArgumentType";
            this.comboBoxArgumentType.Size = new System.Drawing.Size(170, 21);
            this.comboBoxArgumentType.TabIndex = 1;
            // 
            // labelArgumentName
            // 
            this.labelArgumentName.AutoSize = true;
            this.labelArgumentName.Location = new System.Drawing.Point(13, 24);
            this.labelArgumentName.Name = "labelArgumentName";
            this.labelArgumentName.Size = new System.Drawing.Size(84, 13);
            this.labelArgumentName.TabIndex = 2;
            this.labelArgumentName.Text = "Argument name:";
            // 
            // labelArgumentType
            // 
            this.labelArgumentType.AutoSize = true;
            this.labelArgumentType.Location = new System.Drawing.Point(13, 66);
            this.labelArgumentType.Name = "labelArgumentType";
            this.labelArgumentType.Size = new System.Drawing.Size(78, 13);
            this.labelArgumentType.TabIndex = 3;
            this.labelArgumentType.Text = "Argument type:";
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
            // AddOrEditCustomArgument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 164);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelArgumentType);
            this.Controls.Add(this.labelArgumentName);
            this.Controls.Add(this.comboBoxArgumentType);
            this.Controls.Add(this.textBoxArgumentName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddOrEditCustomArgument";
            this.Text = "AddOrEditCustomArgument";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxArgumentName;
        private System.Windows.Forms.ComboBox comboBoxArgumentType;
        private System.Windows.Forms.Label labelArgumentName;
        private System.Windows.Forms.Label labelArgumentType;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}