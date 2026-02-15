using System.ComponentModel;

namespace SSMSObjectExplorerMenu.enums
{
    public enum UserDefinedParameterType : byte
    {
		[Description("nvarchar")]
		Nvarchar,
		[Description("int")]
        Int,        
        [Description("bit")]
        Bit,
        [Description("datetime2")]
        DateTime2,
        [Description("datetimeoffset")]
        DateTimeOffset,
		[Description("uniqueidentifier")]
		UniqueIdentifier,
		/// <summary>
		/// This is not a SQL Server data type. Represents a list of options defined by the user.
		/// </summary>
		[Description("list of options")]
        CustomList
    }
}
