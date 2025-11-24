using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public UserDefinedParameterType CurrentType {
            get => _currentType;
            set
            {
                // Selecting default value for type 'CustomList' happens in a different control.
                if (value == UserDefinedParameterType.CustomList)
                {
                    throw new ArgumentException("CustomList type is not supported in DefaultValueControl.", nameof(value));
                }
                _currentType = value;

                // Controls list is expected to have always a single control.
                this.Controls.Clear();
                this.Controls.Add(_defaultValueInputControls[_currentType]);

                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public string ValueAsString => _defaultValueInputControls[_currentType].GetValueByParameterType(_currentType);

        public event EventHandler ValueChanged;

        public DefaultValueControl(UserDefinedParameterType currentType, bool edit, string presetValue = null)
        {
            InitializeComponent();
            InitDefaultValueInputControls(currentType, edit, presetValue);

            this.Size = _controlSize;
            CurrentType = currentType;
        }

        private void InitDefaultValueInputControls(UserDefinedParameterType currentType, bool edit, string presetValue = null)
        {
            if(edit && presetValue == null)
            {
                throw new ArgumentException($"Parameter {nameof(presetValue)} cannot be null if {nameof(edit)} is true.");
            }

            var int_nu = new NumericUpDown { 
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = (edit && currentType == UserDefinedParameterType.Int) ? (int.TryParse(presetValue, out int pv_int) ? pv_int : 0) : 0,
                Size = _controlSize,
                Location = Point.Empty
            };
            var nvarchar_tb = new TextBox {
                Text = (edit && currentType == UserDefinedParameterType.Nvarchar) ? presetValue : string.Empty,
                Size = _controlSize,
                Location = Point.Empty
            };
            var bit_cb = new CheckBox {
                Checked = (edit && currentType == UserDefinedParameterType.Bit) ? presetValue == "1" : false,
                Size = _controlSize,
                Location = Point.Empty
            };
            var uniqueidentifier_tb = new TextBox {
                Text = (edit && currentType == UserDefinedParameterType.UniqueIdentifier) ? (Guid.TryParse(presetValue, out Guid pv_guid) ? presetValue : $"{Guid.Empty}") : $"{Guid.Empty}",
                Size = _controlSize,
                Location = Point.Empty
            };
            var datetime2_tb = new TextBox { 
                Text = (edit && currentType == UserDefinedParameterType.DateTime2) ?
                    (DateTime.TryParse(presetValue, out DateTime _) ? presetValue : $"{DateTime.Now.ToString(DateTime2_FormatString)}") : $"{DateTime.Now.ToString(DateTime2_FormatString)}",
                Size = _controlSize,
                Location = Point.Empty
            };
            var datetimeoffset_tb = new TextBox { 
                Text = Text = (edit && currentType == UserDefinedParameterType.DateTimeOffset) ?
                    (DateTimeOffset.TryParse(presetValue, out DateTimeOffset _) ? presetValue : $"{DateTimeOffset.Now.ToString(DateTimeOffset_FormatString)}") :
                    $"{DateTimeOffset.Now.ToString(DateTimeOffset_FormatString)}",
                Size = _controlSize,
                Location = Point.Empty
            };

            var invokeValueChanged = new EventHandler((s, e) => ValueChanged?.Invoke(this, EventArgs.Empty));
            int_nu.ValueChanged += invokeValueChanged;
            nvarchar_tb.TextChanged += invokeValueChanged;
            bit_cb.CheckedChanged += invokeValueChanged;
            uniqueidentifier_tb.TextChanged += invokeValueChanged;
            datetime2_tb.TextChanged += invokeValueChanged;
            datetimeoffset_tb.TextChanged += invokeValueChanged;

            _defaultValueInputControls.Add(UserDefinedParameterType.Int, int_nu);
            _defaultValueInputControls.Add(UserDefinedParameterType.Nvarchar, nvarchar_tb);
            _defaultValueInputControls.Add(UserDefinedParameterType.Bit, bit_cb);
            _defaultValueInputControls.Add(UserDefinedParameterType.UniqueIdentifier, uniqueidentifier_tb);
            _defaultValueInputControls.Add(UserDefinedParameterType.DateTime2, datetime2_tb);
            _defaultValueInputControls.Add(UserDefinedParameterType.DateTimeOffset, datetimeoffset_tb);
        }
    }
}
