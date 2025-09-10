using SSMSObjectExplorerMenu.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SSMSObjectExplorerMenu.objects
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class UserDefinedParameter
    {
        public const short NAME_MAX_LENGTH = 64;

        [DisplayName("Name")]
        [Description("Name of the user-defined parameter. Cannot be empty or contain only whitespace characters.")]
        public string Name { get; set; }

        [DisplayName("Data type")]
        [Description("Data type of the user-defined parameter.")]
        public UserDefinedParameterType Type { get; set; }

        public static void ValidateName(string parameterName, IEnumerable<string> reservedNames = null)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException("User-defined parameter name cannot be null or whitespace.");
            }
            if (parameterName.Length > NAME_MAX_LENGTH)
            {
                throw new ArgumentException($"User-defined parameter name cannot be longer than {NAME_MAX_LENGTH} characters.");
            }
            if (reservedNames?.Any(reservedName => StringComparer.OrdinalIgnoreCase.Equals(reservedName, parameterName)) ?? false)
            {
                throw new ArgumentException($"Parameter name '{parameterName}' is reserved or duplicated.");
            }
        }
    }
}
