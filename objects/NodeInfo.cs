using System;

namespace SSMSObjectExplorerMenu.objects
{
	public class NodeInfo
	{
		public string Server { get; set; } = string.Empty;

		private string database = string.Empty;
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
		public string Schema { get; set; } = string.Empty;
		public string Table { get; set; } = string.Empty;
		public string StoredProcedure { get; set; } = string.Empty;

		public string Function { get; set; } = string.Empty;
		public string Job { get; set; } = string.Empty;
		public string UrnPath { get; set; } = string.Empty;
		public string NavigationContext { get; set; } = string.Empty;

		public NodeInfo() {

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

			if (Function != string.Empty)
			{
				s += $"Function: {Function}{Environment.NewLine}";
			}

			if (Job != string.Empty)
			{
				s += $"Job: {Job}{Environment.NewLine}";
			}

			return s;
		}

	}
}
