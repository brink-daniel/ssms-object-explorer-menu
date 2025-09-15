using System;
using System.ComponentModel;

namespace SSMSObjectExplorerMenu.enums
{
    [Flags]
    public enum MenuItemContext
    {
        [Description("Server")]
        Server = 1,
        [Description("Server/DatabasesFolder")]
        DatabasesFolder = 2,
        [Description("Server/Database")]
        Database = 4,
        [Description("Server/Database/Table")]
        Table = 8,
        [Description("Server/Database/Table/Column")]
        Column = 16,
        [Description("Server/Database/UserTablesFolder")]
        UserTablesFolder = 32,
        [Description("Server/Database/View")]
        View = 64,
        [Description("Server/Database/StoredProceduresFolder")]
        StoredProceduresFolder = 128,
        [Description("Server/Database/StoredProcedure")]
        StoredProcedure = 256,
        [Description("Server/JobServer")]
        JobServer = 512,
        [Description("Server/JobServer/JobsFolder")]
        JobsFolder = 1024,
        [Description("Server/JobServer/Job")]
        Job = 2048,
        [Description("All")]
        All = Server | DatabasesFolder | Database | Table | Column | UserTablesFolder | View | StoredProceduresFolder | StoredProcedure | JobServer | JobsFolder | Job
    }
}
