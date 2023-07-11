using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMedic
{
	public class NodeInfo
	{
		public string Server { get; set; }

		private string database;
		public string Database
		{
			get
			{
				if (database == string.Empty) 
				{
					return "master";
				}
				return database;
			}
			set 
			{
				database = value;
			}
		}
		public string Schema { get; set; }
		public string Table { get; set; }
		public string StoredProcedure { get; set; }

		public NodeInfo() {
			Server = string.Empty;
			Database = string.Empty;
			Schema = string.Empty;
			Table = string.Empty;
			StoredProcedure = string.Empty;
		}

	}
}
