using Microsoft.Internal.VisualStudio.Shell;
using SSMSObjectExplorerMenu.enums;
using System;

namespace SSMSObjectExplorerMenu.objects
{
    public class UserDefinedArgument : UserDefinedParameter
    {
        private string _valueStr;

        public string ValueAsString {
            get => _valueStr;
            private set
            {
                ValidateValue(value);
                _valueStr = value;
            }
        }

        public UserDefinedArgument(string name, UserDefinedParameterType type, string value)
        {
            Name = name;
            Type = type;
            ValueAsString = value;
        }

        private static void ValidateValue(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null.");
            }
        }
    }
}
