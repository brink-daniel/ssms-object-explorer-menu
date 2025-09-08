using SSMSObjectExplorerMenu.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;

namespace SSMSObjectExplorerMenu.objects
{

	public class MenuItem
	{
		private string _script = string.Empty; 

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
		[DisplayName("Script")]
		[Description("Inline tsql statements OR path to script file.")]
		[DefaultValue("")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		public string Script 
		{ 
			get => _script; 
			set => _script = value.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine); 
		}

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
		[DefaultValue("All")]
		public string Context { get; set; } = "All";

        [Category("Menu item")]
        [DisplayName("User-defined arguments")]
        [Description("List of user-deifned arguments can be used in the T-SQL script.")]
		[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public BindingList<UserDefinedArgument> UserDefinedArguments { get; private set; } = new BindingList<UserDefinedArgument>();

		public MenuItem()
		{
			
		}

		public MenuItem(bool enabled, string context, string name, string script, bool execute, bool confirm, IEnumerable<UserDefinedArgument> userDefinedArguments = null)
		{
            Enabled = enabled;
			Context = context;
			Name = name;
			Script = script;
			Execute = execute;
			Confirm = confirm;

			if(userDefinedArguments != null)
			{
                foreach(var arg in userDefinedArguments)
				{
                    UserDefinedArguments.Add(arg);
                }
            }

			if (Confirm) {
				Execute = true;
			}
		}
	}
}
