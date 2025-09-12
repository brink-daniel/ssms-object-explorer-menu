namespace SSMSObjectExplorerMenu.enums
{
    public enum UserDefinedParameterType : byte
    {
        UniqueIdentifier,
        Int,
        Nvarchar,
        Bit,
        /// <summary>
        /// This is not a SQL Server data type. Represents a list of custom values defined by the user.
        /// </summary>
        CustomList
    }
}
