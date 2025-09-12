using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SSMSObjectExplorerMenu.objects
{
    /// <summary>
    /// This class is a wrapper for using it with <see cref="CollectionEditor"/> in property grid.
    /// <see cref="CollectionEditor"/> calls the default constructor when adding a new item to the collection.
    /// <see cref="string"/> does not have a default parameterless constructor.
    /// </summary>
    public class StringListItem
    {
        public string Value { get; set; } = string.Empty;

        public StringListItem() { }
        public StringListItem(string value) { Value = value; }

        public override string ToString() => Value;

        public static implicit operator string(StringListItem item) => item?.Value;

        public static implicit operator StringListItem(string value) => new StringListItem(value);
    }

    public class StringListItemComparer : IEqualityComparer<StringListItem>
    {
        private StringComparison? _comparison;

        public StringListItemComparer() { }

        public StringListItemComparer(StringComparison comparison) => _comparison = comparison;

        public bool Equals(StringListItem x, StringListItem y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return _comparison.HasValue ? string.Equals(x.Value, y.Value, _comparison.Value) : string.Equals(x.Value, y.Value);
        }

        public int GetHashCode(StringListItem obj)
        {
            if (obj?.Value == null) return 0;

            switch (_comparison)
            {
                case StringComparison.OrdinalIgnoreCase:
                    return obj.Value.ToLowerInvariant().GetHashCode();
                case StringComparison.CurrentCultureIgnoreCase:
                    return obj.Value.ToLower(System.Globalization.CultureInfo.CurrentCulture).GetHashCode();
                case StringComparison.InvariantCultureIgnoreCase:
                    return obj.Value.ToLower(System.Globalization.CultureInfo.InvariantCulture).GetHashCode();
                case StringComparison.Ordinal:
                case StringComparison.CurrentCulture:
                case StringComparison.InvariantCulture:
                default:
                    return obj.Value.GetHashCode();
            }
        }
    }
}
