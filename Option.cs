using System.Diagnostics.Contracts;

namespace SQLMedic
{
	public class Option
	{
		public bool Enabled { get; set; }
		public Context Context { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }		
		public NodeInfo NodeInfo { get; set; }
		public bool Execute { get; set; }

		public bool Confirm { get; set; }

		public Option(bool enabled, Context context, string name, string path, bool execute, bool confirm)
		{
			Enabled = enabled;
			Context = context;
			Name = name;
			Path = path;
			Execute = execute;
			NodeInfo = new NodeInfo();
			Confirm = confirm;
		}
	}
}
