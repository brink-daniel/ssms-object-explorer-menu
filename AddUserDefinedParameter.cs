using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class AddUserDefinedParameter : Form
    {
        private IEnumerable<string> _paramNamesInUse;
        private UserDefinedParameter _parameter;

        private DefaultValueControl defaultValueControl;

        public UserDefinedParameter Parameter
        {
            get
            {
                if (!_parameter.TryValidate(out IEnumerable<string> _, _paramNamesInUse) || this.DialogResult != DialogResult.OK)
                {
                    throw new InvalidOperationException("Dialog is in invalid state.");
                }
                return _parameter;
            }
        }

        public AddUserDefinedParameter(IEnumerable<string> paramNamesInUse, bool edit = false, UserDefinedParameter parameterToEdit = null)
        {
            if(edit && parameterToEdit is null)
            {
                throw new ArgumentNullException(nameof(parameterToEdit), $"Parameter '{nameof(parameterToEdit)}' must not be null if patameter '{nameof(edit)}' is set to true.");
            }

            InitializeComponent();

            _parameter = new UserDefinedParameter { 
                Name = edit ? parameterToEdit.Name : string.Empty,
                Type = edit ? parameterToEdit.Type : UserDefinedParameterType.UniqueIdentifier,
                DefaultValueAsString = edit ? parameterToEdit.DefaultValueAsString : null
            };
            _paramNamesInUse = edit ? paramNamesInUse.Except(new[] { parameterToEdit.Name }) : paramNamesInUse;

            this.textBoxParameterName.MaxLength = UserDefinedParameter.NAME_MAX_LENGTH;
            this.textBoxParameterName.DataBindings.Add(nameof(textBoxParameterName.Text), _parameter, nameof(_parameter.Name), true, DataSourceUpdateMode.OnPropertyChanged);

            this.defaultValueControl = new DefaultValueControl(_parameter.Type, edit, _parameter.DefaultValueAsString);
            this.defaultValueControl.Location = new System.Drawing.Point(100, 95); // Adjusting location next to label
            this.defaultValueControl.ValueChanged += (s, e) => _parameter.DefaultValueAsString = defaultValueControl.ValueAsString;
            this.Controls.Add(this.defaultValueControl);

            this.comboBoxParameterType.DataSource = 
                Enum.GetValues(typeof(UserDefinedParameterType))
                    .Cast<UserDefinedParameterType>()
                    .Select(type => new ComboBoxItem<UserDefinedParameterType> { Displayed = type.ToStringDescription(), Value = type }).ToList();
            this.comboBoxParameterType.DisplayMember = nameof(ComboBoxItem<UserDefinedParameterType>.Displayed);
            this.comboBoxParameterType.ValueMember = nameof(ComboBoxItem<UserDefinedParameterType>.Value);
            this.comboBoxParameterType.DataBindings.Add(nameof(comboBoxParameterType.SelectedValue), _parameter, nameof(_parameter.Type), true, DataSourceUpdateMode.OnPropertyChanged);

            this.listViewCustomList.Items.AddRange(edit ?
                parameterToEdit.ValueSetOfCustomList.Select(item => new ListViewItem(item.Value)).ToArray() :
                Array.Empty<ListViewItem>()
            );
            this.Text = edit ? "Edit user-defined parameter..." : this.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!_parameter.TryValidate(out IEnumerable<string> validationErrors, _paramNamesInUse))
            {
                var errorMessageBuilder = new StringBuilder();
                foreach(var error in validationErrors) errorMessageBuilder.AppendLine(error);
                MessageBox.Show(errorMessageBuilder.ToString(), "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void comboBoxParameterType_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedValue = comboBoxParameterType.SelectedValue as UserDefinedParameterType?;
            if(selectedValue != null)
            {
                this.defaultValueControl.CurrentType = selectedValue.Value;
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
