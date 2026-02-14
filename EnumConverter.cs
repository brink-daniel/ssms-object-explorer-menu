using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SSMSObjectExplorerMenu
{
    public abstract class EnumConverter<T> : EnumConverter where T : Enum
    {
        public EnumConverter() : base(typeof(T))
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is T && destinationType == typeof(string))
            {
                var field = typeof(T).GetField(value.ToString());
                var desc = field?.GetCustomAttribute<DescriptionAttribute>();
                return (desc?.Description) ?? throw new ArgumentException($"Unknown {typeof(T)} value.", nameof(value));
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string val)
            {
                var targetField = typeof(T).GetFields()
                    .SingleOrDefault(f => f.GetCustomAttribute<DescriptionAttribute>()?.Description == val);
                return targetField != null ?
                    Enum.Parse(typeof(T), targetField.Name) :
                    throw new ArgumentException($"Unknown {typeof(T)} value.", nameof(value));
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
