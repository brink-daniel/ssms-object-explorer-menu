using System;

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
		public string Job { get; set; }
		public string UrnPath { get; set; }
		public string NavigationContext { get; set; }

		public NodeInfo() {
			Server = string.Empty;
			Database = string.Empty;
			Schema = string.Empty;
			Table = string.Empty;
			StoredProcedure = string.Empty;
			UrnPath = string.Empty;
			NavigationContext = string.Empty;
			Job = string.Empty;
		}

		public override string ToString()
		{
			string s = string.Empty;

			if (Server != string.Empty)
			{
				s += $"Server: {Server}{Environment.NewLine}";
			}

			if (Database != string.Empty)
			{
				s += $"Database: {Database}{Environment.NewLine}";
			}

			if (Schema != string.Empty)
			{
				s += $"Schema: {Schema}{Environment.NewLine}";
			}

			if (Table != string.Empty)
			{
				s += $"Table: {Table}{Environment.NewLine}";
			}

			if (StoredProcedure != string.Empty)
			{
				s += $"StoredProcedure: {StoredProcedure}{Environment.NewLine}";
			}

			if (Job != string.Empty)
			{
				s += $"Job: {Job}{Environment.NewLine}";
			}

			return s;
		}

	}
}
