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
                if (!TryValidate(out UserDefinedParameter parameter, out List<string> _) || this.DialogResult != DialogResult.OK)
                {
                    throw new InvalidOperationException("Dialog is in invalid state.");
                }
                return parameter;
            }
        }

        public AddUserDefinedParameter(IEnumerable<string> paramNamesInUse, bool edit = false, UserDefinedParameter parameterToEdit = null)
        {
            if(edit && parameterToEdit is null)
            {
                throw new ArgumentNullException(nameof(parameterToEdit), $"Parameter '{nameof(parameterToEdit)}' must not be null if patameter '{nameof(edit)}' is set to true.");
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
            if (!TryValidate(out UserDefinedParameter _, out List<string> validationErrors))
            {
                var errorMessageBuilder = new StringBuilder();
                validationErrors.ForEach(error => errorMessageBuilder.AppendLine(error));
                MessageBox.Show(errorMessageBuilder.ToString(), "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool TryValidate(out UserDefinedParameter validatedParameter, out List<string> validationErrors)
        {
            var parameter = BuildParameter();
            validationErrors = !parameter.TryValidate(out IEnumerable<string> errors, _paramNamesInUse) ? errors.ToList() : new List<string>();

            bool success = !validationErrors.Any();
            validatedParameter = success ? parameter : null;
            return success;
        }

        private UserDefinedParameter BuildParameter() => new UserDefinedParameter
        {
            Name = _parameter.Name,
            Type = _parameter.Type,
            ValueSetOfCustomList = new BindingList<StringListItem>(
                        _parameter.Type == UserDefinedParameterType.CustomList ?
                            this.listViewCustomList.Items.Cast<ListViewItem>().Select(item => new StringListItem(item.Text)).ToList() :
                            new List<StringListItem>()
                )
        };

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
            // In case of removing list items:
            // This method is called shortly before the listview item is actually removed.
            // So the collection returned by GetSelectedItems() contains also the item to remove.
            // A very minor delay is needed to have the correct state of the listview.
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
