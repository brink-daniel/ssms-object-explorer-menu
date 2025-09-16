using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
                if (!TryValidate(out List<string> _) || this.DialogResult != DialogResult.OK)
                {
                    throw new InvalidOperationException("Dialog is in invalid state.");
                }
                return new UserDefinedParameter
                {
                    Name = _parameter.Name,
                    Type = _parameter.Type,
                    ValueSetOfCustomList = new BindingList<StringListItem>(
                        _parameter.Type == UserDefinedParameterType.CustomList ?
                            this.listViewCustomList.Items.Cast<ListViewItem>().Select(item => new StringListItem(item.Text)).ToList() :
                            new List<StringListItem>()
                    )
                };
            }
        }

        public AddUserDefinedParameter(IEnumerable<string> paramNamesInUse, bool edit = false, UserDefinedParameter parameterToEdit = null)
        {
            if(edit && parameterToEdit is null)
            {
                throw new ArgumentNullException(nameof(parameterToEdit), "Parameter to edit must be provided when edit is true.");
            }

            InitializeComponent();

            _parameter = new ParameterItem { Name = string.Empty, Type = UserDefinedParameterType.UniqueIdentifier };
            _paramNamesInUse = !edit ? paramNamesInUse : paramNamesInUse.Except(new[] { parameterToEdit.Name });

            this.textBoxParameterName.MaxLength = UserDefinedParameter.NAME_MAX_LENGTH;
            this.textBoxParameterName.DataBindings.Add(nameof(textBoxParameterName.Text), _parameter, nameof(_parameter.Name), true, DataSourceUpdateMode.OnPropertyChanged);

            this.comboBoxParameterType.DataSource = 
                Enum.GetValues(typeof(UserDefinedParameterType))
                    .Cast<UserDefinedParameterType>()
                    .Select(type => new ComboBoxItem<UserDefinedParameterType> { Displayed = type.ToStringDescription(), Value = type }).ToList();
            this.comboBoxParameterType.DisplayMember = nameof(ComboBoxItem<UserDefinedParameterType>.Displayed);
            this.comboBoxParameterType.ValueMember = nameof(ComboBoxItem<UserDefinedParameterType>.Value);
            this.comboBoxParameterType.DataBindings.Add(nameof(comboBoxParameterType.SelectedValue), _parameter, nameof(_parameter.Type), true, DataSourceUpdateMode.OnPropertyChanged);

            if(edit)
            {
                _parameter.Name = parameterToEdit.Name;
                _parameter.Type = parameterToEdit.Type;
                this.listViewCustomList.Items.AddRange(parameterToEdit.ValueSetOfCustomList.Select(item => new ListViewItem(item.Value)).ToArray());
                this.Text = "Edit user-defined parameter...";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!TryValidate(out List<string> validationErrors))
            {
                var errorMessageBuilder = new StringBuilder();
                validationErrors.ForEach(error => errorMessageBuilder.AppendLine(error));
                MessageBox.Show(errorMessageBuilder.ToString(), "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool TryValidate(out List<string> validationErros)
        {
            var paramBuiltFromDialog = new UserDefinedParameter
            {
                Name = _parameter.Name,
                Type = _parameter.Type,
                ValueSetOfCustomList = new BindingList<StringListItem>(
                        _parameter.Type == UserDefinedParameterType.CustomList ?
                            this.listViewCustomList.Items.Cast<ListViewItem>().Select(item => new StringListItem(item.Text)).ToList() :
                            new List<StringListItem>()
                )
            };

            validationErros = !paramBuiltFromDialog.TryValidate(out IEnumerable<string> errors, _paramNamesInUse) ? errors.ToList() : new List<string>();
            return !validationErros.Any();
        }

        private void comboBoxParameterType_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedValue = comboBoxParameterType.SelectedValue as UserDefinedParameterType?;
            if(selectedValue != null)
            {
                this.panelCustomList.Enabled = selectedValue == UserDefinedParameterType.CustomList;
            }
        }

        private void buttonAddCustomList_Click(object sender, EventArgs e)
        {
            this.listViewCustomList.Items.Add("New value (double-click to edit)...");
        }

        private void buttonRemoveCustomList_Click(object sender, EventArgs e)
        {
            var selectedItems = this.listViewCustomList.Items.Cast<ListViewItem>().Where(item => item.Selected);
            this.listViewCustomList.Items.RemoveRange(selectedItems);
        }
        private void listViewCustomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() => this.buttonRemoveCustomList.Enabled = this.listViewCustomList.GetSelectedItems().Any()));
        }

        class ParameterItem
        {
            public string Name { get; set; }
            public UserDefinedParameterType Type { get; set; }
            public ISet<string> ValueSetOfCustomList { get; set; }
        }
    }
}
