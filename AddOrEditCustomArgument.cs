using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class AddOrEditCustomArgument : Form
    {
        private bool _editing;
        private IEnumerable<string> _argumentNamesInUse;
        private CustomArgument _argument;

        public CustomArgument CustomArgument {
            get
            {
                if(this.DialogResult != DialogResult.OK)
                {
                    throw new InvalidOperationException("Cannot get argument value from dialog without any user inter interaction.");
                }
                return _argument;
            }
            private set { _argument = value; }
        }

        public AddOrEditCustomArgument(IEnumerable<string> argumentNamesInUse, bool edit = false, CustomArgument argumentToEdit = null)
        {
            _argumentNamesInUse = argumentNamesInUse;
            _editing = edit;
            if(_editing && argumentToEdit is null)
            {
                throw new ArgumentException($"{nameof(argumentToEdit)} cannot be null if the dialog is in edit mode.", nameof(argumentToEdit));
            }

            CustomArgument = new CustomArgument
            {
                Name = _editing ? argumentToEdit.Name : string.Empty,
                Type = _editing ? argumentToEdit.Type : CustomArgumentType.UniqueIdentifier
            };

            this.Text = $"{(_editing ? "Editing" : "Adding new")} custom argument...";

            this.textBoxArgumentName.MaxLength = CustomArgument.NAME_MAX_LENGTH;
            this.textBoxArgumentName.DataBindings.Add(nameof(textBoxArgumentName.Text), CustomArgument, nameof(CustomArgument.Name));

            this.comboBoxArgumentType.DataSource = Enum.GetNames(typeof(CustomArgumentType));
            this.comboBoxArgumentType.SelectedIndex = 0;
            this.comboBoxArgumentType.DataBindings.Add(nameof(comboBoxArgumentType.SelectedValue), CustomArgument, nameof(CustomArgument.Type));

            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var argumentNameToAdd = this.textBoxArgumentName.Text;
            if (string.IsNullOrWhiteSpace(argumentNameToAdd))
            {
                MessageBox.Show("You must choose a name for the argument!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_argumentNamesInUse.Any(argumentName => StringComparer.OrdinalIgnoreCase.Equals(argumentName, argumentNameToAdd)))
            {
                MessageBox.Show($"Name '{argumentNameToAdd}' is already in use! Choose a different one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
