using System.ComponentModel;

namespace SSMSObjectExplorerMenu.enums
{
    public enum UserDefinedParameterType : byte
    {
        [Description("uniqueidentifier")]
        UniqueIdentifier,
        [Description("int")]
        Int,
        [Description("nvarchar")]
        Nvarchar,
        [Description("bit")]
        Bit,
        /// <summary>
        /// This is not a SQL Server data type. Represents a list of options defined by the user.
        /// </summary>
        [Description("List of options")]
        CustomList
    }
}
