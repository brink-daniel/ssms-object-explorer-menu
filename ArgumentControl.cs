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
    public partial class ArgumentControl : UserControl
    {
        /// <summary>
        /// Padding of the control in pixels.
        /// </summary>
        private const int PADDING_TOP_BOTTOM = 2;
        private const byte UNIQUEIDENTIFIER_LENGTH = 36;

        private Label _labelParameterName;
        private Control _valueControl;

        public UserDefinedParameter Parameter { get; private set; }
        public string ParameterValueString => _valueControl.GetValueByParameterType(Parameter.Type);

        public ArgumentControl(UserDefinedParameter parameter, int width)
        {
            if(!parameter.TryValidate(out IEnumerable<string> _))
            {
                throw new ArgumentException("Parameter validation has failed.", nameof(parameter));
            }
            if (width < 0)
            {
                throw new ArgumentException("Width cannot be negative.", nameof(width));
            }

            Parameter = parameter;

            InitializeComponent();

            switch (Parameter.Type)
            {
                case UserDefinedParameterType.UniqueIdentifier:
                    Init_Uniqueidentifier();
                    break;
                case UserDefinedParameterType.Nvarchar:
                    Init_Nvarchar();
                    break;
                case UserDefinedParameterType.Int:
                    Init_Int();
                    break;
                case UserDefinedParameterType.Bit:
                    Init_Bit();
                    break;
                case UserDefinedParameterType.DateTime2:
                    Init_DateTime2();
                    break;
                case UserDefinedParameterType.DateTimeOffset:
                    Init_DateTimeOffset();
                    break;
                case UserDefinedParameterType.CustomList:
                    Init_CustomList();
                    break;
                default:
                    throw new ArgumentException("Parameter type is not known.", nameof(Parameter));
            }
            this._labelParameterName = new Label();

            this.Size = new Size(width, (2 * PADDING_TOP_BOTTOM) + this._labelParameterName.Height + this._valueControl.Height);

            this._labelParameterName.Location = new Point(0, PADDING_TOP_BOTTOM);
            this._labelParameterName.Width = this.Width;
            this._labelParameterName.Text = $"{Parameter.Name} ({Parameter.Type.ToStringDescription()}):";
            this.Controls.Add(this._labelParameterName);

            this._valueControl.Location = new Point(0, this._labelParameterName.Location.Y + this._labelParameterName.Height);
            this._valueControl.Width = this.Size.Width;
            this.Controls.Add(this._valueControl);
        }

        public bool IsValid()
        {
            switch (Parameter.Type)
            {
                case UserDefinedParameterType.UniqueIdentifier:
                    return Guid.TryParse(_valueControl.Text, out _);
                case UserDefinedParameterType.DateTime2:
                    return DateTime.TryParse(_valueControl.Text, out _);
                case UserDefinedParameterType.DateTimeOffset:
                    return DateTimeOffset.TryParse(_valueControl.Text, out _);
                case UserDefinedParameterType.Nvarchar:
                case UserDefinedParameterType.Int:
                case UserDefinedParameterType.Bit:
                case UserDefinedParameterType.CustomList:
                    return true;
                default:
                    throw new NotImplementedException($"Validation for parameter type {Parameter.Type} has not been implemented.");
            }
        }

        private void Init_Uniqueidentifier()
        {
            var guidTextBox = new TextBox();
            guidTextBox.MaxLength = UNIQUEIDENTIFIER_LENGTH;
            guidTextBox.Text = Parameter.DefaultValueAsString;

            _valueControl = guidTextBox;
        }

        private void Init_Nvarchar()
        {
            var textBox = new TextBox();
            textBox.Text = Parameter.DefaultValueAsString;

            _valueControl = textBox;
        }

        private void Init_Int() => _valueControl = new NumericUpDown() { 
            Minimum = int.MinValue,
            Maximum = int.MaxValue,
            Value = int.TryParse(Parameter.DefaultValueAsString, out int defaultValue) ? defaultValue : 0
        };

        private void Init_Bit() => _valueControl = new CheckBox() { Checked = Parameter.DefaultValueAsString == "1" };

        private void Init_DateTime2() => _valueControl = new TextBox() { 
            Text = DateTime.TryParse(Parameter.DefaultValueAsString, out DateTime _)
                ? Parameter.DefaultValueAsString
                : Utils.DateTimeTodayUtc.ToString(DateTime2_FormatString)
        };

        private void Init_DateTimeOffset() => _valueControl = new TextBox() { 
            Text = DateTimeOffset.TryParse(Parameter.DefaultValueAsString, out DateTimeOffset _) 
                ? Parameter.DefaultValueAsString
                : Utils.DateTimeOffsetTodayUtc.ToString(DateTimeOffset_FormatString)
        };

        private void Init_CustomList()
        {
            var comboBox = new ComboBox();
            comboBox.SetDataSource(Parameter.ValueSetOfCustomList.Select(s => s.Value).ToArray());

            string valueToSelect = Parameter.ValueSetOfCustomList.SingleOrDefault(s => s.Value == Parameter.DefaultValueAsString);
            if (valueToSelect != null)
            {
                /// Deferred intialization of ComboBox selected value. See explanation in class <see cref="DefaultValueControl"/> for details.
                comboBox.HandleCreated += (s, e) => {
                    comboBox.BeginInvoke((Action)(() => {
                        comboBox.SelectedValue = valueToSelect;
                    }));
                };
            }

            _valueControl = comboBox;
        }
    }
}
