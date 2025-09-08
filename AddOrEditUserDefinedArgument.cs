using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class AddOrEditUserDefinedArgument : Form
    {
        private bool _editing;
        private IEnumerable<string> _argumentNamesInUse;
        private UserDefinedArgument _argument;

        public UserDefinedArgument Argument {
            get
            {
                if(this.DialogResult != DialogResult.OK)
                {
                    throw new InvalidOperationException("Cannot get argument value from dialog without any user inter interaction.");
                }
                return _argument;
            }
        }

        public AddOrEditUserDefinedArgument(IEnumerable<string> argumentNamesInUse, bool edit = false, UserDefinedArgument argumentToEdit = null)
        {
            InitializeComponent();

            // Can't add arguments already added by the user once or coming from the execution context...
            _argumentNamesInUse = argumentNamesInUse.Concat(Utils.ArgumentsFromContext);
            _editing = edit;
            if(_editing && argumentToEdit is null)
            {
                throw new ArgumentException($"{nameof(argumentToEdit)} cannot be null if the dialog is in edit mode.", nameof(argumentToEdit));
            }

            _argument = new UserDefinedArgument
            {
                Name = _editing ? argumentToEdit.Name : string.Empty,
                Type = _editing ? argumentToEdit.Type : UserDefinedArgumentType.UniqueIdentifier
            };

            this.Text = $"{(_editing ? "Editing" : "Adding new")} custom argument...";

            this.textBoxArgumentName.MaxLength = UserDefinedArgument.NAME_MAX_LENGTH;
            this.textBoxArgumentName.DataBindings.Add(nameof(textBoxArgumentName.Text), _argument, nameof(_argument.Name));

            this.comboBoxArgumentType.DataSource = Enum.GetNames(typeof(UserDefinedArgumentType));
            this.comboBoxArgumentType.SelectedIndex = 0;
            this.comboBoxArgumentType.ValueMember = ".";
            this.comboBoxArgumentType.DataBindings.Add(nameof(comboBoxArgumentType.SelectedValue), _argument, nameof(_argument.Type));
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
