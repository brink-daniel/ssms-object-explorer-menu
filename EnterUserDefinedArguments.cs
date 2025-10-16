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
        /// <summary>
        /// Space for the vertical scrollbar and some padding.
        /// </summary>
        private const int FLOWLAYOUTPANEL_PADDING = 25;

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

            int argumentControlWidth = this.flowLayoutPanelArguments.ClientSize.Width - FLOWLAYOUTPANEL_PADDING;
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
    }
}
