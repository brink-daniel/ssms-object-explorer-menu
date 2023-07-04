namespace SQLMedic
{
	public class Option
	{
		public bool Enabled { get; set; }
		public Context Context { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public string Server { get; set; }
		public string Database { get; set; }
		public string Table { get; set; }
		public string StoredProcedure { get; set; }
		public string Schema { get; set; }
		public bool Execute { get; set; }

		public Option(bool enabled, Context context, string name, string path, bool execute)
		{
			Enabled = enabled;
			Context = context;
			Name = name;
			Path = path;
			Execute = execute;
		}
	}
}
