using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.ComponentModel;

namespace SQLMedic
{
	public class OptionsDialogPage : DialogPage
	{
		private const string enabled = "Enabled";
		private const string path = "Path";
		private const string name = "Name";
		private const string context = "Context";
		private const string execute = "Execute";

		private const string enabled_desc = "Show/hide the menu item.";
		private const string path_desc = "Location of script file to execute OR tsql statements to execute.";
		private const string name_desc = "Text displayed on menu item.";
		private const string context_desc = "Set the tree node level where to display menu item.";
		private const string execute_desc = "Automatically run the selected script or tsql statements.";

		private const string script1 = "Script 01";
		private const string script2 = "Script 02";
		private const string script3 = "Script 03";
		private const string script4 = "Script 04";
		private const string script5 = "Script 05";
		private const string script6 = "Script 06";
		private const string script7 = "Script 07";
		private const string script8 = "Script 08";
		private const string script9 = "Script 09";
		private const string script10 = "Script 10";
		private const string script11 = "Script 11";
		private const string script12 = "Script 12";
		private const string script13 = "Script 13";
		private const string script14 = "Script 14";
		private const string script15 = "Script 15";
		private const string script16 = "Script 16";
		private const string script17 = "Script 17";
		private const string script18 = "Script 18";
		private const string script19 = "Script 19";
		private const string script20 = "Script 20";

		#region Script 1
		[DefaultValue(true)]
		[Category(script1)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script1Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script1)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script1Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script1)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script1Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script1)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script1Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script1)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script1Execute { get; set; } = true;
		#endregion

		#region Script 2
		[DefaultValue(true)]
		[Category(script2)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script2Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script2)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script2Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script2)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script2Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script2)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script2Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script2)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script2Execute { get; set; } = true;
		#endregion

		#region Script 3
		[DefaultValue(true)]
		[Category(script3)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script3Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script3)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script3Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script3)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script3Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script3)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script3Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script3)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script3Execute { get; set; } = true;
		#endregion

		#region Script 4
		[DefaultValue(true)]
		[Category(script4)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script4Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script4)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script4Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script4)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script4Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script4)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script4Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script4)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script4Execute { get; set; } = true;
		#endregion

		#region Script 5
		[DefaultValue(true)]
		[Category(script5)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script5Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script5)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script5Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script5)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script5Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script5)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script5Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script5)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script5Execute { get; set; } = true;
		#endregion

		#region Script 6
		[DefaultValue(true)]
		[Category(script6)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script6Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script6)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script6Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script6)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script6Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script6)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script6Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script6)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script6Execute { get; set; } = true;
		#endregion

		#region Script 7
		[DefaultValue(true)]
		[Category(script7)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script7Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script7)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script7Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script7)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script7Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script7)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script7Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script7)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script7Execute { get; set; } = true;
		#endregion

		#region Script 8
		[DefaultValue(true)]
		[Category(script8)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script8Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script8)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script8Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script8)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script8Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script8)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script8Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script8)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script8Execute { get; set; } = true;
		#endregion

		#region Script 9
		[DefaultValue(true)]
		[Category(script9)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script9Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script9)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script9Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script9)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script9Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script9)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script9Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script9)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script9Execute { get; set; } = true;
		#endregion

		#region Script 10
		[DefaultValue(true)]
		[Category(script10)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script10Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script10)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script10Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script10)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script10Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script10)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script10Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script10)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script10Execute { get; set; } = true;
		#endregion

		#region Script 11
		[DefaultValue(true)]
		[Category(script11)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script11Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script11)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script11Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script11)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script11Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script11)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script11Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script11)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script11Execute { get; set; } = true;
		#endregion

		#region Script 12
		[DefaultValue(true)]
		[Category(script12)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script12Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script12)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script12Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script12)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script12Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script12)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script12Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script12)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script12Execute { get; set; } = true;
		#endregion

		#region Script 13
		[DefaultValue(true)]
		[Category(script13)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script13Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script13)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script13Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script13)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script13Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script13)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script13Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script13)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script13Execute { get; set; } = true;
		#endregion

		#region Script 14
		[DefaultValue(true)]
		[Category(script14)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script14Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script14)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script14Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script14)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script14Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script14)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script14Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script14)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script14Execute { get; set; } = true;
		#endregion

		#region Script 15
		[DefaultValue(true)]
		[Category(script15)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script15Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script15)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script15Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script15)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script15Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script15)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script15Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script15)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script15Execute { get; set; } = true;
		#endregion

		#region Script 16
		[DefaultValue(true)]
		[Category(script16)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script16Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script16)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script16Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script16)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script16Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script16)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script16Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script16)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script16Execute { get; set; } = true;
		#endregion

		#region Script 17
		[DefaultValue(true)]
		[Category(script17)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script17Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script17)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script17Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script17)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script17Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script17)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script17Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script17)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script17Execute { get; set; } = true;
		#endregion

		#region Script 18
		[DefaultValue(true)]
		[Category(script18)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script18Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script18)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script18Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script18)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script18Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script18)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script18Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script18)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script18Execute { get; set; } = true;
		#endregion

		#region Script 19
		[DefaultValue(true)]
		[Category(script19)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script19Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script19)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script19Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script19)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script19Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script19)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script19Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script19)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script19Execute { get; set; } = true;
		#endregion

		#region Script 20
		[DefaultValue(true)]
		[Category(script20)]
		[DisplayName(enabled)]
		[Description(enabled_desc)]
		public bool Script20Enabled { get; set; } = true;

		[DefaultValue("")]
		[Category(script20)]
		[DisplayName(name)]
		[Description(name_desc)]
		public string Script20Name { get; set; } = string.Empty;

		[DefaultValue("")]
		[Category(script20)]
		[DisplayName(path)]
		[Description(path_desc)]
		public string Script20Path { get; set; } = string.Empty;

		[DefaultValue(Context.Server)]
		[Category(script20)]
		[DisplayName(context)]
		[Description(context_desc)]
		public Context Script20Context { get; set; } = Context.Server;

		[DefaultValue(true)]
		[Category(script20)]
		[DisplayName(execute)]
		[Description(execute_desc)]
		public bool Script20Execute { get; set; } = true;
		#endregion



		[DefaultValue(true)]
		[Category("Branding")]
		[DisplayName("Icon")]
		[Description("Display the SQLMedic icon")]
		public bool BrandingIcon { get; set; } = true;

		[DefaultValue("SQLMedic")]
		[Category("Branding")]
		[DisplayName("Name")]
		[Description("Text to display in the main SQLMedic menu item")]
		public string BrandingText { get; set; } = "SQLMedic";

		public List<Option> ToArray()
		{
			List<Option> options = new List<Option>
			{
				new Option(Script1Enabled, Script1Context, Script1Name, Script1Path, Script1Execute),
				new Option(Script2Enabled, Script2Context, Script2Name, Script2Path, Script2Execute),
				new Option(Script3Enabled, Script3Context, Script3Name, Script3Path, Script3Execute),
				new Option(Script4Enabled, Script4Context, Script4Name, Script4Path, Script4Execute),
				new Option(Script5Enabled, Script5Context, Script5Name, Script5Path, Script5Execute),
				new Option(Script6Enabled, Script6Context, Script6Name, Script6Path, Script6Execute),
				new Option(Script7Enabled, Script7Context, Script7Name, Script7Path, Script7Execute),
				new Option(Script8Enabled, Script8Context, Script8Name, Script8Path, Script8Execute),
				new Option(Script9Enabled, Script9Context, Script9Name, Script9Path, Script9Execute),
				new Option(Script10Enabled, Script10Context, Script10Name, Script10Path, Script10Execute),
				new Option(Script11Enabled, Script11Context, Script11Name, Script11Path, Script11Execute),
				new Option(Script12Enabled, Script12Context, Script12Name, Script12Path, Script12Execute),
				new Option(Script13Enabled, Script13Context, Script13Name, Script13Path, Script13Execute),
				new Option(Script14Enabled, Script14Context, Script14Name, Script14Path, Script14Execute),
				new Option(Script15Enabled, Script15Context, Script15Name, Script15Path, Script15Execute),
				new Option(Script16Enabled, Script16Context, Script16Name, Script16Path, Script16Execute),
				new Option(Script17Enabled, Script17Context, Script17Name, Script17Path, Script17Execute),
				new Option(Script18Enabled, Script18Context, Script18Name, Script18Path, Script18Execute),
				new Option(Script19Enabled, Script19Context, Script19Name, Script19Path, Script19Execute),
				new Option(Script20Enabled, Script20Context, Script20Name, Script20Path, Script20Execute),
			};

			return options;
		}
	}
}
