using System;
using System.Collections.Generic;

namespace SSMSObjectExplorerMenu
{
    public static class Utils
    {
        public static IEnumerable<string> ParametersFromContext = new string[]
        {
            "OBJECT",
            "SERVER",
            "DATABASE",
            "TABLE",
            "VIEW",
            "STORED_PROCEDURE",
            "FUNCTION",
            "SCHEMA",
            "JOB",
            "YYYY-MM-DD",
            "HHmm:ss",
            "YYYY-MM-DD HH:mm:ss"
        };

        public static DateTime DateTimeTodayUtc
        {
            get
            {
                var utcNow = DateTime.UtcNow;
                return new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, 0, 0, 0);
            }
        }

        public static DateTimeOffset DateTimeOffsetTodayUtc
        {
            get
            {
                var utcNow = DateTimeOffset.UtcNow;
                return new DateTimeOffset(utcNow.Year, utcNow.Month, utcNow.Day, 0, 0, 0, TimeSpan.Zero);
            }
        }
    }
}
