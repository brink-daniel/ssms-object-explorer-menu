using Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer;
using System;
using System.Reflection;

namespace SQLMedic
{
	public static class Extensions
	{
		public static string GetStringValue(this Enum value)
		{
			Type type = value.GetType();
			FieldInfo fieldInfo = type.GetField(value.ToString());
			StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
			return attribs.Length > 0 ? attribs[0].StringValue : null;
		}

		public static string GetServerName(this INodeInformation node)
		{
			string[] context = node.NavigationContext.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			foreach (string s in context)
			{
				if (s.StartsWith("Server[@Name='"))
				{
					return s.Replace("Server[@Name='", "").Replace("']", "");
				}
			}

			return string.Empty;
		}

		public static string GetDatabaseName(this INodeInformation node)
		{
			string[] context = node.NavigationContext.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			foreach (string s in context)
			{
				if (s.StartsWith("Database[@Name='"))
				{
					return s.Replace("Database[@Name='", "").Replace("']", "");
				}
			}
			return string.Empty;
		}

		public static string GetTableName(this INodeInformation node)
		{
			string[] context = node.NavigationContext.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			foreach (string s in context)
			{
				if (s.StartsWith("Table[@Name='"))
				{
					string[] t = s.Replace("Table[@Name='", "").Replace("' and @Schema='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

					if (t.Length == 2)
					{
						return t[0];
					}
				}
			}
			return string.Empty;
		}

		public static string GetStoredProcedureName(this INodeInformation node)
		{
			string[] context = node.NavigationContext.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			foreach (string s in context)
			{
				if (s.StartsWith("StoredProcedure[@Name='"))
				{
					string[] t = s.Replace("StoredProcedure[@Name='", "").Replace("' and @Schema='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

					if (t.Length == 2)
					{
						return t[0];
					}
				}
			}
			return string.Empty;
		}

		public static string GetSchema(this INodeInformation node)
		{
			string[] context = node.NavigationContext.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			foreach (string s in context)
			{
				if (s.StartsWith("Table[@Name='"))
				{
					string[] t = s.Replace("Table[@Name='", "").Replace("' and @Schema='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

					if (t.Length == 2)
					{
						return t[1];
					}
				}

				if (s.StartsWith("StoredProcedure[@Name='"))
				{
					string[] t = s.Replace("StoredProcedure[@Name='", "").Replace("' and @Schema='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

					if (t.Length == 2)
					{
						return t[1];
					}
				}
			}
			return string.Empty;
		}
	}
}
