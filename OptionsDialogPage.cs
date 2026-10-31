using Microsoft.VisualStudio.Shell;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System.Collections.Generic;
using System.ComponentModel;

namespace SSMSObjectExplorerMenu
{
	// Kept only to read settings saved by the former Options page. This type is not
	// registered with ProvideOptionPage, so it does not appear in the Options UI.
	public class OptionsDialogPage : DialogPage
	{
		[DefaultValue(default(List<MenuItem>))]
		public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

		[DefaultValue(true)]
		public bool ShowIcon { get; set; } = true;

		[DefaultValue("My Scripts")]
		public string Text { get; set; } = "My Scripts";

		[DefaultValue(true)]
		public bool ShowNewButton { get; set; } = true;

		[DefaultValue(true)]
		public bool ShowOptionsButton { get; set; } = true;

		[DefaultValue(true)]
		public bool ShowExportButton { get; set; } = true;

		[DefaultValue(true)]
		public bool ShowImportButton { get; set; } = true;

		[DefaultValue("")]
		[Browsable(false)]
		public string MenuItemsXml { get; set; } = string.Empty;

		public override void LoadSettingsFromStorage()
		{
			base.LoadSettingsFromStorage();

			MenuItems = MenuItems ?? new List<MenuItem>();
			if (MenuItems.Count == 0 && !string.IsNullOrWhiteSpace(MenuItemsXml))
			{
				try
				{
					MenuItems = MenuItemsXml.DeserializeObject<List<MenuItem>>() ?? new List<MenuItem>();
				}
				catch
				{
					// Leave invalid legacy data untouched; migration will not replace it.
				}
			}
		}
	}
}
