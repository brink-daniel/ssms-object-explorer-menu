using SSMSObjectExplorerMenu.enums;
using System;

namespace SSMSObjectExplorerMenu.objects
{
    public class UserDefinedArgument
    {
        public const short NAME_MAX_LENGTH = 128;

        public string Name { get; set; }

        public UserDefinedArgumentType Type { get; set; }

        public override bool Equals(object other)
        {
            var otherAsCustomArg = other as UserDefinedArgument;

            if (otherAsCustomArg is null) return false;

            return StringComparer.OrdinalIgnoreCase.Equals(Name, otherAsCustomArg.Name) && Type == otherAsCustomArg.Type;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 13;
                hashCode = hashCode * 41 + (Name?.GetHashCode() ?? 0);
                hashCode = hashCode * 41 + Type.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(UserDefinedArgument left, UserDefinedArgument right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(UserDefinedArgument left, UserDefinedArgument right) => !(left == right); 
    }
}
