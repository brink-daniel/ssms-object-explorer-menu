using SSMSObjectExplorerMenu.enums;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SSMSObjectExplorerMenu
{
    public class MenuItemContextConverter : EnumConverter
    {
        public MenuItemContextConverter() : base(typeof(MenuItemContext))
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is MenuItemContext && destinationType == typeof(string))
            {
                var field = typeof(MenuItemContext).GetField(value.ToString());
                var desc = field?.GetCustomAttribute<DescriptionAttribute>();
                return (desc?.Description) ?? throw new ArgumentException($"Unknown {typeof(MenuItemContext)} value", nameof(value));
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if(value is string val)
            {
                var targetField = typeof(MenuItemContext).GetFields()
                    .SingleOrDefault(f => f.GetCustomAttribute<DescriptionAttribute>()?.Description == val);
                return targetField != null ?
                    Enum.Parse(typeof(MenuItemContext), targetField.Name) :
                    throw new ArgumentException($"Unknown {typeof(MenuItemContext)} value", nameof(value));
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
