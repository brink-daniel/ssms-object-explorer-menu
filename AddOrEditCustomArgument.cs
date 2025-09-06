using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class AddOrEditCustomArgument : Form
    {
        private bool _editing;

        public CustomArgument CustomArgument { get; private set; }

        public AddOrEditCustomArgument(bool edit = false, CustomArgument argumentToEdit = null)
        {
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
            if(string.IsNullOrWhiteSpace(this.textBoxArgumentName.Text))
            {
                MessageBox.Show("You have to provide a name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
