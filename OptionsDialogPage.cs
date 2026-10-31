using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Utilities.UnifiedSettings;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MessageBox = System.Windows.Forms.MessageBox;
using MessageBoxButtons = System.Windows.Forms.MessageBoxButtons;
using MessageBoxIcon = System.Windows.Forms.MessageBoxIcon;

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
		[Browsable(false)]
		public bool ShowIcon { get; set; } = true;

		[DefaultValue("My Scripts")]
		[Category("General options")]
		[DisplayName("Name")]
		[Description("Text to display in the main menu item")]
		[Browsable(false)]
		public string Text { get; set; } = "My Scripts";

		[DefaultValue(true)]
		[Category("General options")]
		[DisplayName("New")]
		[Description("Display the New menu item button")]
		[Browsable(false)]
		public bool ShowNewButton { get; set; } = true;

        [DefaultValue(true)]
        [Category("General options")]
        [DisplayName("Options")]
        [Description("Display the Options button")]
        [Browsable(false)]
		public bool ShowOptionsButton { get; set; } = true;

        [DefaultValue(true)]
        [Category("General options")]
        [DisplayName("Export")]
        [Description("Display the Export button")]
        [Browsable(false)]
		public bool ShowExportButton { get; set; } = true;

        [DefaultValue(true)]
        [Category("General options")]
        [DisplayName("Import")]
        [Description("Display the Import button")]
        [Browsable(false)]
		public bool ShowImportButton { get; set; } = true;

        [DefaultValue("")]
		[Category("General options")]
		[DisplayName("MenuItemsXml")]
		[Description("Menu items serialized to xml")]
		[Browsable(false)]
		public string MenuItemsXml { get; set; } = string.Empty;

		public override void LoadSettingsFromStorage()
		{
			// Read old DialogPage values only when Unified Settings has no saved menu XML to migrate.
			base.LoadSettingsFromStorage();

			ISettingsWriter settings = UnifiedSettingsService.GetWriter();
			if (settings == null)
				return;

			// Preserve menu configurations while moving existing installations to Unified Settings.
			string savedMenuItems = settings.GetValueOrThrow<string>(UnifiedSettingsService.MenuItemsXml);
			if (string.IsNullOrEmpty(savedMenuItems) && HasLegacySettings())
			{
				if (MenuItems.Count == 0 && !string.IsNullOrEmpty(MenuItemsXml))
				{
					try { MenuItems = MenuItemsXml.DeserializeObject<List<MenuItem>>(); }
					catch { /* Replace malformed legacy XML with the current collection on save. */ }
				}
				SaveSettingsToStorage();
				return;
			}

			Text = settings.GetValueOrThrow<string>(UnifiedSettingsService.Text);
			ShowIcon = settings.GetValueOrThrow<bool>(UnifiedSettingsService.ShowIcon);
			ShowNewButton = settings.GetValueOrThrow<bool>(UnifiedSettingsService.ShowNewButton);
			ShowOptionsButton = settings.GetValueOrThrow<bool>(UnifiedSettingsService.ShowOptionsButton);
			ShowExportButton = settings.GetValueOrThrow<bool>(UnifiedSettingsService.ShowExportButton);
			ShowImportButton = settings.GetValueOrThrow<bool>(UnifiedSettingsService.ShowImportButton);
			MenuItemsXml = savedMenuItems ?? string.Empty;

			if (MenuItemsXml.Length > 0)
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

			ISettingsWriter settings = UnifiedSettingsService.GetWriter();
			if (settings == null)
				return;

			settings.EnqueueChange(UnifiedSettingsService.Text, Text ?? string.Empty);
			settings.EnqueueChange(UnifiedSettingsService.ShowIcon, ShowIcon);
			settings.EnqueueChange(UnifiedSettingsService.ShowNewButton, ShowNewButton);
			settings.EnqueueChange(UnifiedSettingsService.ShowOptionsButton, ShowOptionsButton);
			settings.EnqueueChange(UnifiedSettingsService.ShowExportButton, ShowExportButton);
			settings.EnqueueChange(UnifiedSettingsService.ShowImportButton, ShowImportButton);
			settings.EnqueueChange(UnifiedSettingsService.MenuItemsXml, MenuItemsXml ?? string.Empty);
			settings.RequestCommit("Save SSMS Object Explorer Menu settings");
		}

		private bool HasLegacySettings()
		{
			return !string.IsNullOrEmpty(MenuItemsXml)
				|| MenuItems.Count > 0
				|| !string.Equals(Text, "My Scripts", StringComparison.Ordinal)
				|| !ShowIcon
				|| !ShowNewButton
				|| !ShowOptionsButton
				|| !ShowExportButton
				|| !ShowImportButton;
		}

		protected override void OnApply(PageApplyEventArgs e)
		{
			if(!TryValidate(out List<MenuItemErrorModel> validationErrors))
			{
                ShowValidationErrorDialog(validationErrors);
                e.ApplyBehavior = ApplyKind.CancelNoNavigate;
            }
			else base.OnApply(e); // Calls SaveSettingsToStorage
        }

		private bool TryValidate(out List<MenuItemErrorModel> validationErrors)
		{
			validationErrors = MenuItems.Select(mi => mi.TryValidate(out IEnumerable<MenuItemErrorModel> errors) ? null : errors)
				.Where(e => e != null)
				.SelectMany(e => e)
				.ToList();
            return !validationErrors.Any();
        }

		private void ShowValidationErrorDialog(List<MenuItemErrorModel> validationErrors)
		{
			if(validationErrors.Any())
			{
                var builder = new StringBuilder();

                builder.AppendLine($"One or more validation errors occurred:{Environment.NewLine}");
                foreach (var error in validationErrors.SelectMany(e => e.ErrorMessages, (m, e) => new { m.MenuItemName, ErrorMessage = e}))
                {
                    builder.AppendLine($"Menu item '{error.MenuItemName}': {error.ErrorMessage}");
                }
                MessageBox.Show(builder.ToString(), "SSMS Object Explorer Menu | Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
