using SSMSObjectExplorerMenu.controls;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class EnterUserDefinedArguments : Form
    {
        private readonly ArgumentControl[] _argumentControls;

        public IEnumerable<UserDefinedArgument> UserDefinedArguments { 
            get
            {
                if(!TryValidate(out IEnumerable<string> _) || this.DialogResult != DialogResult.OK)
                {
                    throw new InvalidOperationException("Dialog is in invalid state.");
                }
                return _argumentControls.Select(ac => ac.ToUserDefinedArgument());
            }
        }

        public EnterUserDefinedArguments(IEnumerable<UserDefinedParameter> parameters)
        {
            InitializeComponent();

            int argumentControlWidth = this.flowLayoutPanelArguments.ClientSize.Width;
            _argumentControls = parameters.Select(p => new ArgumentControl(p, argumentControlWidth)).ToArray();
            this.flowLayoutPanelArguments.Controls.AddRange(_argumentControls);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(!TryValidate(out IEnumerable<string> invalidArguments))
            {
                MessageBox.Show(this, $"The following parameters have invalid values: {string.Join(", ", invalidArguments)}.", "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool TryValidate(out IEnumerable<string> invalidArguments)
        {
            invalidArguments = _argumentControls.Where(ac => !ac.IsValid()).Select(ac => ac.Parameter.Name);
            return !invalidArguments.Any();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // To show placeholder text (e.g. for datetime and datetime2) for all controls when the form is shown
            this.ActiveControl = null;
        }
    }
}
