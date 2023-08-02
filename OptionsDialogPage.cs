using Microsoft.VisualStudio.Shell;
using SSMSObjectExplorerMenu.objects;
using System.Collections.Generic;
using System.ComponentModel;

namespace SSMSObjectExplorerMenu
{
	public class OptionsDialogPage : DialogPage
	{
		[DefaultValue(default(List<MenuItem>))]
		[Category("General options")]
		[DisplayName("Menu items")]
		[Description("Collection of menu items")]
		public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();


		[DefaultValue(true)]
		[Category("General options")]
		[DisplayName("Icon")]
		[Description("Display icon")]
		public bool ShowIcon { get; set; } = true;

		[DefaultValue("My Scripts")]
		[Category("General options")]
		[DisplayName("Name")]
		[Description("Text to display in the main menu item")]
		public string Text { get; set; } = "My Scripts";

		[DefaultValue(true)]
		[Category("General options")]
		[DisplayName("Add")]
		[Description("Display the Add button")]
		public bool ShowAddButton { get; set; } = true;



		[DefaultValue("")]
		[Category("General options")]
		[DisplayName("MenuItemsXml")]
		[Description("Menu items serialized to xml")]
		[Browsable(false)]
		public string MenuItemsXml { get; set; } = string.Empty;


		public override void LoadSettingsFromStorage()
		{
			base.LoadSettingsFromStorage();

			if (MenuItems.Count == 0 && MenuItemsXml.Length > 0)
			{
				try
				{
					MenuItems = MenuItemsXml.DeserializeObject<List<MenuItem>>();
				}
				catch
				{
					//do nothing if failed
					//bad xml will be overriden on save
				}
			}
		}

		public override void SaveSettingsToStorage()
		{
			try
			{
				MenuItemsXml = MenuItems.SerializeObject();
			}
			catch 
			{ 
				//sanity check
				//do nothing if failed
				//bad configs will be lost
			}

			base.SaveSettingsToStorage();
		}

	}
}
