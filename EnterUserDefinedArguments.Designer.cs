namespace SSMSObjectExplorerMenu
{
    partial class EnterUserDefinedArguments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterUserDefinedArguments));
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelArguments = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.dialogPage1 = new Microsoft.VisualStudio.Shell.DialogPage();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter values for the parameters below.";
            // 
            // flowLayoutPanelArguments
            // 
            this.flowLayoutPanelArguments.AutoScroll = true;
            this.flowLayoutPanelArguments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelArguments.Location = new System.Drawing.Point(15, 26);
            this.flowLayoutPanelArguments.Name = "flowLayoutPanelArguments";
            this.flowLayoutPanelArguments.Size = new System.Drawing.Size(300, 150);
            this.flowLayoutPanelArguments.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(159, 182);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(240, 182);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // EnterUserDefinedArguments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(329, 216);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.flowLayoutPanelArguments);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterUserDefinedArguments";
            this.Text = "Enter script arguments...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelArguments;
        private System.Windows.Forms.Button buttonOK;
        private Microsoft.VisualStudio.Shell.DialogPage dialogPage1;
        private System.Windows.Forms.Button buttonCancel;
    }
}