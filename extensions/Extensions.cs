using Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer;
using SSMSObjectExplorerMenu.objects;
using System;
using System.IO;
using System.Xml.Serialization;

namespace SSMSObjectExplorerMenu.extensions
{
	public static class Extensions
	{
		public static T DeserializeObject<T>(this string toDeserialize)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			using (StringReader textReader = new StringReader(toDeserialize))
			{
				return (T)xmlSerializer.Deserialize(textReader);
			}
		}

		public static string SerializeObject<T>(this T toSerialize)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

			using (StringWriter textWriter = new StringWriter())
			{
				xmlSerializer.Serialize(textWriter, toSerialize);
				return textWriter.ToString();
			}
		}


		public static NodeInfo GetInfo(this INodeInformation node)
		{
			NodeInfo info = new NodeInfo
			{
				UrnPath = node.UrnPath,
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

                if (s.StartsWith("View[@Name='"))
                {
                    string[] t = s.Replace("View[@Name='", "").Replace("' and @Schema='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    if (t.Length == 2)
                    {
                        info.View = t[0];
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

				if (s.StartsWith("UserDefinedFunction[@Name='"))
				{
					string[] t = s.Replace("UserDefinedFunction[@Name='", "").Replace("' and @Schema='", "|").Replace("']", "").Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

					if (t.Length == 2)
					{
						info.Function = t[0];
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
