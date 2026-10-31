using Microsoft.VisualStudio.Utilities.UnifiedSettings;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System.Collections.Generic;

namespace SSMSObjectExplorerMenu
{
	// Runtime state backed by Unified Settings. This is deliberately not a DialogPage.
	public class MenuSettings
	{
		public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
		public bool ShowIcon { get; set; } = true;
		public string Text { get; set; } = "My Scripts";
		public bool ShowNewButton { get; set; } = true;
		public bool ShowOptionsButton { get; set; } = true;
		public bool ShowExportButton { get; set; } = true;
		public bool ShowImportButton { get; set; } = true;
		public string MenuItemsXml { get; set; } = string.Empty;

		public void LoadSettingsFromStorage()
		{
			ISettingsWriter settings = UnifiedSettingsService.GetWriter();
			if (settings == null)
				return;

			bool migrationComplete = TryReadStored(settings, UnifiedSettingsService.MigrationMarker, out bool completed) && completed;
			bool migratedLegacySetting = false;

			Text = ReadSetting<string>(settings, UnifiedSettingsService.Text, UnifiedSettingsService.LegacyText, migrationComplete, ref migratedLegacySetting);
			ShowIcon = ReadSetting<bool>(settings, UnifiedSettingsService.ShowIcon, UnifiedSettingsService.LegacyShowIcon, migrationComplete, ref migratedLegacySetting);
			ShowNewButton = ReadSetting<bool>(settings, UnifiedSettingsService.ShowNewButton, UnifiedSettingsService.LegacyShowNewButton, migrationComplete, ref migratedLegacySetting);
			ShowOptionsButton = ReadSetting<bool>(settings, UnifiedSettingsService.ShowOptionsButton, UnifiedSettingsService.LegacyShowOptionsButton, migrationComplete, ref migratedLegacySetting);
			ShowExportButton = ReadSetting<bool>(settings, UnifiedSettingsService.ShowExportButton, UnifiedSettingsService.LegacyShowExportButton, migrationComplete, ref migratedLegacySetting);
			ShowImportButton = ReadSetting<bool>(settings, UnifiedSettingsService.ShowImportButton, UnifiedSettingsService.LegacyShowImportButton, migrationComplete, ref migratedLegacySetting);

			if (TryReadStored(settings, UnifiedSettingsService.MenuItemsXml, out string savedMenuItems))
			{
				MenuItemsXml = savedMenuItems ?? string.Empty;
			}
			else if (!migrationComplete && TryReadStored(settings, UnifiedSettingsService.LegacyMenuItemsXml, out savedMenuItems))
			{
				MenuItemsXml = savedMenuItems ?? string.Empty;
				migratedLegacySetting = true;
			}
			else
			{
				MenuItemsXml = settings.GetValueOrThrow<string>(UnifiedSettingsService.MenuItemsXml) ?? string.Empty;
			}

			if (!string.IsNullOrEmpty(MenuItemsXml))
			{
				try
				{
					MenuItems = MenuItemsXml.DeserializeObject<List<MenuItem>>() ?? new List<MenuItem>();
				}
				catch
				{
					// Keep the in-memory collection if a stored XML value is malformed.
				}
			}
			else if (TryReadStored(settings, UnifiedSettingsService.MenuItemsXml, out savedMenuItems))
			{
				// An explicitly stored empty value means the user cleared the collection.
				MenuItems = new List<MenuItem>();
			}

			if (!migrationComplete && migratedLegacySetting)
				SaveSettingsToStorage();
		}

		private static T ReadSetting<T>(ISettingsWriter settings, string currentMoniker, string legacyMoniker, bool migrationComplete, ref bool migratedLegacySetting)
		{
			if (TryReadStored(settings, currentMoniker, out T value))
				return value;

			if (!migrationComplete && TryReadStored(settings, legacyMoniker, out value))
			{
				migratedLegacySetting = true;
				return value;
			}

			return settings.GetValueOrThrow<T>(currentMoniker);
		}

		private static bool TryReadStored<T>(ISettingsWriter settings, string moniker, out T value)
		{
			var result = settings.GetValue<T>(moniker, SettingReadOptions.NoRequirements | SettingReadOptions.NoFallbackToDefault);
			value = result.Value;
			return result.Outcome == SettingRetrievalOutcome.Success;
		}

		public void SaveSettingsToStorage()
		{
			try
			{
				MenuItemsXml = MenuItems.SerializeObject();
			}
			catch
			{
				// Keep the last valid serialized value if serialization fails.
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
			settings.EnqueueChange(UnifiedSettingsService.MigrationMarker, true);
			settings.RequestCommit("Save SSMS Object Explorer Menu settings");
		}
	}
}
