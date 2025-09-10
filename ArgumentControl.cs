using SSMSObjectExplorerMenu.enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu
{
    public partial class ArgumentControl : UserControl
    {
        private const int HEIGHT_LABEL = 15;
        private const int HEIGHT_VALUECONTROL = 20;
        private const byte UNIQUEIDENTIFIER_LENGTH = 36;

        private Label _labelParameterName;
        private Control _valueControl;

        public string ParameterName { get; private set; }
        public UserDefinedParameterType ParameterType { get; private set; }
        public string ParameterValueString => _valueControl.Text;

        public Func<bool> Validator { get; private set; }

        public ArgumentControl(string parameterName, UserDefinedParameterType parameterType, int width)
        {
            if(string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException("Parameter name cannot be null or whitespace.", nameof(parameterName));
            }

            if (width < 0)
            {
                throw new ArgumentException("Width cannot be negative.", nameof(width));
            }

            ParameterName = parameterName;
            ParameterType = parameterType;

            InitializeComponent();

            this.Size = new Size(width, HEIGHT_LABEL + HEIGHT_VALUECONTROL);

            switch (parameterType)
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
                default:
                    throw new ArgumentException("Parameter type is not known.", nameof(parameterType));
            }
            this._valueControl.Location = new Point(0, HEIGHT_LABEL);
            this._valueControl.Size = new Size(this.Size.Width, HEIGHT_VALUECONTROL);
            this.Controls.Add(this._valueControl);

            this._labelParameterName = new Label();
            this._labelParameterName.Location = Point.Empty;
            this._labelParameterName.Size = new Size(this.Size.Width, HEIGHT_LABEL);
            this._labelParameterName.Text = $"{parameterName} ({parameterType}):";
            this.Controls.Add(this._labelParameterName);
        }

        private void Init_Uniqueidentifier()
        {
            var guidTextBox = new TextBox();
            guidTextBox.MaxLength = UNIQUEIDENTIFIER_LENGTH;
            guidTextBox.Text = string.Empty;

            _valueControl = guidTextBox;
            Validator = Validate_Uniqueidentifier;
        }

        private void Init_Nvarchar()
        {
            var textBox = new TextBox();
            textBox.Text = string.Empty;

            _valueControl = textBox;
            Validator = Validate_Nvarchar;
        }

        private void Init_Int()
        {
            _valueControl = new NumericUpDown();
            Validator = () => true;
        }

        private bool Validate_Uniqueidentifier() => Guid.TryParse(_valueControl.Text, out _);

        private bool Validate_Nvarchar() => !string.IsNullOrWhiteSpace(_valueControl.Text);
    }
}
