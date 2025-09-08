using System.Collections.Generic;

namespace SSMSObjectExplorerMenu
{
    public static class Utils
    {
        public static IEnumerable<string> ParametersFromContext = new string[]
        {
            "{OBJECT}",
            "{SERVER}",
            "{DATABASE}",
            "{TABLE}",
            "{VIEW}",
            "{STORED_PROCEDURE}",
            "{FUNCTION}",
            "{SCHEMA}",
            "{JOB}",
            "{YYYY-MM-DD}",
            "{HH:mm:ss}",
            "{YYYY-MM-DD HH:mm:ss}"
        };
    }
}
