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


		public static NodeInfo GetInfo(this INodeInformation node)
		{
			NodeInfo info = new NodeInfo
			{
				UrnPath = node.UrnPath.Replace("/", "_"),
				NavigationContext = node.NavigationContext
			};

			string[] context = node.NavigationContext.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			foreach (string s in context)
			{
				if (s.StartsWith("Server[@Name='"))
				{
					info.Server = s.Replace("Server[@Name='", "").Replace("']", "");
					continue;
				}

				if (s.StartsWith("Database[@Name='"))
				{
					info.Database = s.Replace("Database[@Name='", "").Replace("']", "");
					continue;
				}

				if (s.StartsWith("Table[@Name='"))
				{
					string[] t = s.Replace("Table[@Name='", "").Replace("' and @Schema='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

					if (t.Length == 2)
					{						
						info.Table = t[0];
						info.Schema = t[1];
					}
					continue;
				}

				if (s.StartsWith("StoredProcedure[@Name='"))
				{
					string[] t = s.Replace("StoredProcedure[@Name='", "").Replace("' and @Schema='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

					if (t.Length == 2)
					{
						info.StoredProcedure = t[0];
						info.Schema = t[1];
					}
					continue;
				}

				if (s.StartsWith("Job[@Name='"))
				{
					string[] t = s.Replace("Job[@Name='", "").Replace("' and @CategoryID='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

					if (t.Length == 2)
					{
						info.Job = t[0];						
					}
					continue;
				}
			}


			return info;
		}



	}
}
