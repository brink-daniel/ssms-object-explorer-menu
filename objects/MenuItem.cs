using System.ComponentModel;

namespace SSMSObjectExplorerMenu.objects
{

	public class MenuItem
	{
		[Category("Menu item")]
		[DisplayName("Enabled")]
		[Description("Show/hide the menu item.")]
		[DefaultValue(true)]
		public bool Enabled { get; set; } = true;

		[Category("Menu item")]
		[DisplayName("Name")]
		[Description("Text displayed on menu item.")]
		[DefaultValue("")]
		public string Name { get; set; } = string.Empty;

		[Category("Menu item")]
		[DisplayName("Path")]
		[Description("Location of script file to execute OR tsql statements to execute.")]
		[DefaultValue("")]
		public string Path { get; set; } = string.Empty;

		[Category("Menu item")]
		[DisplayName("Execute")]
		[Description("Automatically run the selected script or tsql statements.")]
		[DefaultValue(true)]
		public bool Execute { get; set; } = true;

		[Category("Menu item")]
		[DisplayName("Confirm")]
		[Description("Ask confirmation to continue before executing script or statement.")]
		[DefaultValue(false)]
		public bool Confirm { get; set; } = false;

		[Category("Menu item")]
		[DisplayName("Context")]
		[Description("Tree node level where to display menu item.")]
		[DefaultValue(Context.All)]
		public Context Context { get; set; } = Context.All;


		public MenuItem()
		{
			
		}

		public MenuItem(bool enabled, Context context, string name, string path, bool execute, bool confirm)
		{
			Enabled = enabled;
			Context = context;
			Name = name;
			Path = path;
			Execute = execute;
			Confirm = confirm;
		}
	}
}
