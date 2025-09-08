using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class AddUserDefinedArgument : Form
    {
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

        public AddUserDefinedArgument(IEnumerable<string> argumentNamesInUse)
        {
            InitializeComponent();

            // Can't add arguments already added by the user once or coming from the execution context...
            _argumentNamesInUse = argumentNamesInUse.Concat(Utils.ArgumentsFromContext);

            _argument = new UserDefinedArgument
            {
                Name = string.Empty,
                Type = UserDefinedArgumentType.UniqueIdentifier
            };

            this.Text = "Adding new custom argument...";

            this.textBoxArgumentName.MaxLength = UserDefinedArgument.NAME_MAX_LENGTH;
            this.textBoxArgumentName.DataBindings.Add(nameof(textBoxArgumentName.Text), _argument, nameof(_argument.Name), true, DataSourceUpdateMode.OnPropertyChanged);

            this.comboBoxArgumentType.DataSource = Enum.GetNames(typeof(UserDefinedArgumentType));
            this.comboBoxArgumentType.SelectedIndex = 0;
            this.comboBoxArgumentType.DataBindings.Add(nameof(comboBoxArgumentType.SelectedItem), _argument, nameof(_argument.Type), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_argument.Name))
            {
                MessageBox.Show("You must choose a name for the argument!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_argumentNamesInUse.Any(argumentName => StringComparer.OrdinalIgnoreCase.Equals(argumentName, _argument.Name)))
            {
                MessageBox.Show($"Name '{_argument.Name}' is already in use! Choose a different one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
