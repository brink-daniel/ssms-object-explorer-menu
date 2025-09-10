using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class AddUserDefinedParameter : Form
    {
        private IEnumerable<string> _paramNamesInUse;
        private ParameterItem _parameter;

        public UserDefinedParameter Parameter
        {
            get
            {
                if (!TryValidate(out string _) || this.DialogResult != DialogResult.OK)
                {
                    throw new InvalidOperationException("Dialog is invalid state.");
                }
                return new UserDefinedParameter { Name = _parameter.Name, Type = _parameter.Type };
            }
        }

        public AddUserDefinedParameter(IEnumerable<string> paramNamesInUse)
        {
            InitializeComponent();

            _parameter = new ParameterItem { Name = string.Empty, Type = UserDefinedParameterType.UniqueIdentifier };
            _paramNamesInUse = paramNamesInUse;

            this.textBoxParameterName.MaxLength = UserDefinedParameter.NAME_MAX_LENGTH;
            this.textBoxParameterName.DataBindings.Add(nameof(textBoxParameterName.Text), _parameter, nameof(_parameter.Name), true, DataSourceUpdateMode.OnPropertyChanged);

            this.comboBoxParameterType.DataSource = Enum.GetNames(typeof(UserDefinedParameterType));
            this.comboBoxParameterType.SelectedIndex = 0;
            this.comboBoxParameterType.DataBindings.Add(nameof(comboBoxParameterType.SelectedItem), _parameter, nameof(_parameter.Type), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!TryValidate(out string validationErrorMessage))
            {
                MessageBox.Show(validationErrorMessage, "Invalid parameter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool TryValidate(out string validationErrorMessage)
        {
            try
            {
                // Can't add parameters already added by the user once or coming from the execution context...
                UserDefinedParameter.ValidateName(_parameter.Name, _paramNamesInUse);
            }
            catch (ArgumentException ex)
            {
                validationErrorMessage = ex.Message;
                return false;
            }

            validationErrorMessage = null;
            return true;
        }

        class ParameterItem
        {
            public string Name { get; set; }
            public UserDefinedParameterType Type { get; set; }
        }
    }
}
