namespace SQLMedic
{
	public enum Context
	{
		[StringValue("All")]
		All,

		[StringValue("Server")]
		Server,

		[StringValue("Server/DatabasesFolder")]
		Server_DatabasesFolder,

		[StringValue("Server/Database")]
		Server_Database,

		[StringValue("Server/Database/Table")]
		Server_Database_Table,

		[StringValue("Server/Database/UserTablesFolder")]
		Server_Database_UserTablesFolder,

		[StringValue("Server/Database/StoredProcedure")]
		Server_Database_StoredProcedure,

		[StringValue("Server/Database/StoredProceduresFolder")]
		Server_Database_StoredProceduresFolder,

		[StringValue("Server/JobServer")]
		Server_JobServer
	}
}
