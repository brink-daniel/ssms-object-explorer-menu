using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static SSMSObjectExplorerMenu.Constants;

namespace SSMSObjectExplorerMenu
{
    public partial class DefaultValueControl : UserControl
    {
        // These sizes are used to fit to parameter name and parameter type input controls in the AddUserDefinedParameter dialog.
        private static readonly Size _controlSize = new Size(170, 20);

        private Dictionary<UserDefinedParameterType, Control> _defaultValueInputControls = new Dictionary<UserDefinedParameterType, Control>();
        private UserDefinedParameterType _currentType;
        private List<string> _customListAvailableOptions;

        public UserDefinedParameterType CurrentType {
            get => _currentType;
            set
            {
                //// Selecting default value for type 'CustomList' happens in a different control.
                //if (value == UserDefinedParameterType.CustomList)
                //{
                //    throw new ArgumentException("CustomList type is not supported in DefaultValueControl.", nameof(value));
                //}
                _currentType = value;

                // Controls list is expected to have always a single control.
                this.Controls.Clear();
                this.Controls.Add(_defaultValueInputControls[_currentType]);

                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public string ValueAsString => _defaultValueInputControls[_currentType].GetValueByParameterType(_currentType);

        public event EventHandler ValueChanged;

        public DefaultValueControl(UserDefinedParameterType currentType, bool edit, object presetValue = null)
        {
            var customListPresetValue = presetValue as CustomListDefaultValueModel;
            if (edit && currentType == UserDefinedParameterType.CustomList && customListPresetValue == null)
            {
                throw new ArgumentException(
                    $"{typeof(DefaultValueControl)} edit mode: parameter {nameof(presetValue)} must be of type {nameof(CustomListDefaultValueModel)} if {nameof(currentType)} is {UserDefinedParameterType.CustomList}.",
                    nameof(presetValue));
            }

            var stringPresetValue = presetValue as string;
            if (edit && currentType != UserDefinedParameterType.CustomList && stringPresetValue == null)
            {
                throw new ArgumentException(
                    $"{typeof(DefaultValueControl)} edit mode: parameter {nameof(presetValue)} must be of type string if {nameof(currentType)} is not {UserDefinedParameterType.CustomList}.",
                    nameof(presetValue));
            }

            InitializeComponent();
            InitDefaultValueInputControls(currentType, edit, stringPresetValue, customListPresetValue);

            this.Size = _controlSize;
            CurrentType = currentType;
        }

        public void HandleCustomListOptionsChanged(object sender, ObservableListViewChangedEventArgs e)
        {
            if (CurrentType != UserDefinedParameterType.CustomList ||
                !(_defaultValueInputControls[UserDefinedParameterType.CustomList] is ComboBox customListComboBox))
            {
                return;
            }

            var originalSelectedValue = customListComboBox.SelectedValue;
            customListComboBox.DataSource = null;

            _customListAvailableOptions = e.NewItems.Select(item => item.Text).ToList();
            var selectedItemNotFound = e.ChangeType == ObservableListViewChangeType.Clear ||
                ((e.ChangeType == ObservableListViewChangeType.Remove || e.ChangeType == ObservableListViewChangeType.Edit) && !_customListAvailableOptions.Any(i => i == (string)originalSelectedValue));

            customListComboBox.DataSource = _customListAvailableOptions.Select(i => new ComboBoxItem<string> { Displayed = i, Value = i}).ToList();
            customListComboBox.DisplayMember = nameof(ComboBoxItem<string>.Displayed);
            customListComboBox.ValueMember = nameof(ComboBoxItem<string>.Value);
            // Added first item(s) to the list of options or removed the currently selected item - take the first list item by default
            customListComboBox.SelectedValue = (originalSelectedValue == null || selectedItemNotFound) ? _customListAvailableOptions[0] : (string)originalSelectedValue;
        }

        private void InitDefaultValueInputControls(UserDefinedParameterType currentType, bool edit, string stringPresetValue = null, CustomListDefaultValueModel customListPresetValue = null)
        {
            var int_nu = new NumericUpDown { 
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = (edit && currentType == UserDefinedParameterType.Int) ? (int.TryParse(stringPresetValue, out int pv_int) ? pv_int : 0) : 0,
            };
            var nvarchar_tb = new TextBox { Text = (edit && currentType == UserDefinedParameterType.Nvarchar) ? stringPresetValue : string.Empty };
            var bit_cb = new CheckBox { Checked = (edit && currentType == UserDefinedParameterType.Bit) ? stringPresetValue == "1" : false };
            var uniqueidentifier_tb = new TextBox {
                Text = (edit && currentType == UserDefinedParameterType.UniqueIdentifier) ? (Guid.TryParse(stringPresetValue, out Guid pv_guid) ? stringPresetValue : $"{Guid.Empty}") : $"{Guid.Empty}",
            };
            var datetime2_tb = new TextBox { 
                Text = (edit && currentType == UserDefinedParameterType.DateTime2) ?
                    (DateTime.TryParse(stringPresetValue, out DateTime _) ? stringPresetValue : $"{DateTime.Now.ToString(DateTime2_FormatString)}") : $"{DateTime.Now.ToString(DateTime2_FormatString)}",
            };
            var datetimeoffset_tb = new TextBox { 
                Text = (edit && currentType == UserDefinedParameterType.DateTimeOffset) ?
                    (DateTimeOffset.TryParse(stringPresetValue, out DateTimeOffset _) ? stringPresetValue : $"{DateTimeOffset.Now.ToString(DateTimeOffset_FormatString)}") :
                    $"{DateTimeOffset.Now.ToString(DateTimeOffset_FormatString)}",
            };

            _customListAvailableOptions = customListPresetValue?.AvailableOptions?.ToList() ?? new List<string>();
            var editCustomList = edit && currentType == UserDefinedParameterType.CustomList;
            var customList_cb = new ComboBox
            {
                DataSource = _customListAvailableOptions,
                SelectedItem = editCustomList ? customListPresetValue.DefaultValueSelected : null,
            };

            var invokeValueChanged = new EventHandler((s, e) => ValueChanged?.Invoke(this, EventArgs.Empty));
            int_nu.ValueChanged += invokeValueChanged;
            nvarchar_tb.TextChanged += invokeValueChanged;
            bit_cb.CheckedChanged += invokeValueChanged;
            uniqueidentifier_tb.TextChanged += invokeValueChanged;
            datetime2_tb.TextChanged += invokeValueChanged;
            datetimeoffset_tb.TextChanged += invokeValueChanged;
            customList_cb.SelectedValueChanged += invokeValueChanged;

            _defaultValueInputControls.Add(UserDefinedParameterType.Int, int_nu.Align(_controlSize));
            _defaultValueInputControls.Add(UserDefinedParameterType.Nvarchar, nvarchar_tb.Align(_controlSize));
            _defaultValueInputControls.Add(UserDefinedParameterType.Bit, bit_cb.Align(_controlSize));
            _defaultValueInputControls.Add(UserDefinedParameterType.UniqueIdentifier, uniqueidentifier_tb.Align(_controlSize));
            _defaultValueInputControls.Add(UserDefinedParameterType.DateTime2, datetime2_tb.Align(_controlSize));
            _defaultValueInputControls.Add(UserDefinedParameterType.DateTimeOffset, datetimeoffset_tb.Align(_controlSize));
            _defaultValueInputControls.Add(UserDefinedParameterType.CustomList, customList_cb.Align(_controlSize));
        }
    }
}
