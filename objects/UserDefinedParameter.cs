using SSMSObjectExplorerMenu.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
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
        [TypeConverter(typeof(UserDefinedArgumentTypeConverter))]
        public UserDefinedParameterType Type { get; set; }

        /// <summary>
        /// Populate if <see cref="Type"/> is <see cref="UserDefinedParameterType.CustomList"/>. Otherwise it's ignored.
        /// </summary>
        [DisplayName("List of options")]
        [Description("List of options. If the parameter's data type is not \"List of options\", it is ignored.")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public BindingList<StringListItem> ValueSetOfCustomList { get; set; } = new BindingList<StringListItem>();

        public bool TryValidate(out IEnumerable<string> validationErrors, IEnumerable<string> reservedNames = null)
        {
            var errors = new List<string>();
            if(!TryValidateName(Name, out IEnumerable<string> nameErrors, reservedNames))
            {
                errors.AddRange(nameErrors);
            }

            if (Type == UserDefinedParameterType.CustomList)
            {
                if (ValueSetOfCustomList is null || ValueSetOfCustomList.Count == 0)
                {
                    errors.Add($"Parameter '{Name}': list of options cannot be empty.");
                }
                if (ValueSetOfCustomList.Any(value => string.IsNullOrWhiteSpace(value)))
                {
                    errors.Add($"Parameter '{Name}': list of options cannot contain empty or whitespace-only elements.");
                }
                if(ValueSetOfCustomList.Distinct(new StringListItemComparer(StringComparison.OrdinalIgnoreCase)).Count() != ValueSetOfCustomList.Count)
                {
                    errors.Add($"Parameter '{Name}': list of options cannot have duplicate elements.");
                }
            }

            validationErrors = errors;
            return !validationErrors.Any();
        }

        public static bool TryValidateName(string parameterName, out IEnumerable<string> validationErrors, IEnumerable<string> reservedNames = null)
        {
            var errors = new List<string>();
            
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                errors.Add("User-defined parameter name cannot be null or whitespace.");
            }
            if (parameterName?.Length > NAME_MAX_LENGTH)
            {
                errors.Add($"User-defined parameter name cannot be longer than {NAME_MAX_LENGTH} characters.");
            }
            if (reservedNames?.Any(reservedName => StringComparer.OrdinalIgnoreCase.Equals(reservedName, parameterName)) ?? false)
            {
                errors.Add($"Parameter name '{parameterName}' is reserved or duplicated.");
            }

            validationErrors = errors;
            return !validationErrors.Any();
        }
    }
}
