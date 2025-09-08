using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class AddUserDefinedParameter : Form
    {
        private IEnumerable<string> _paramNamesInUse;
        private UserDefinedParameter _parameter;

        public UserDefinedParameter Parameter {
            get
            {
                if(this.DialogResult != DialogResult.OK)
                {
                    throw new InvalidOperationException("Cannot get parameter from dialog without any user inter interaction.");
                }
                return _parameter;
            }
        }

        public AddUserDefinedParameter(IEnumerable<string> paramNamesInUse)
        {
            InitializeComponent();

            // Can't add parameters already added by the user once or coming from the execution context...
            _paramNamesInUse = paramNamesInUse.Concat(Utils.ParametersFromContext);

            _parameter = new UserDefinedParameter
            {
                Name = string.Empty,
                Type = UserDefinedParameterType.UniqueIdentifier
            };

            this.Text = "Adding new user-defined parameter...";

            this.textBoxParameterName.MaxLength = UserDefinedParameter.NAME_MAX_LENGTH;
            this.textBoxParameterName.DataBindings.Add(nameof(textBoxParameterName.Text), _parameter, nameof(_parameter.Name), true, DataSourceUpdateMode.OnPropertyChanged);

            this.comboBoxParameterType.DataSource = Enum.GetNames(typeof(UserDefinedParameterType));
            this.comboBoxParameterType.SelectedIndex = 0;
            this.comboBoxParameterType.DataBindings.Add(nameof(comboBoxParameterType.SelectedItem), _parameter, nameof(_parameter.Type), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_parameter.Name))
            {
                MessageBox.Show("You must choose a name for the parameter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_paramNamesInUse.Any(paramName => StringComparer.OrdinalIgnoreCase.Equals(paramName, _parameter.Name)))
            {
                MessageBox.Show($"Name '{_parameter.Name}' is already in use! Choose a different one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
