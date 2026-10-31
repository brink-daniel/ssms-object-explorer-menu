using Microsoft.VisualStudio.Utilities.UnifiedSettings;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System.Collections.Generic;
using System.Linq;

namespace SSMSObjectExplorerMenu
{
	public class MenuItemSetting
	{
		public string Name { get; set; } = string.Empty;
		public string Xml { get; set; } = string.Empty;
	}

	// Runtime state backed by Unified Settings. This is deliberately not a DialogPage.
	public class MenuSettings
	{
		public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
		public bool ShowIcon { get; set; } = true;
		public string Text { get; set; } = "My Scripts";
		public bool ShowNewButton { get; set; } = true;
		public bool ShowExportButton { get; set; } = true;
		public bool ShowImportButton { get; set; } = true;
		public string MenuItemsXml => (MenuItems ?? new List<MenuItem>()).SerializeObject();

		public void LoadSettingsFromStorage()
		{
			ISettingsWriter settings = UnifiedSettingsService.GetWriter();
			if (settings == null)
				return;

			bool migrationComplete = UnifiedSettingsService.IsMigrationComplete();
			bool migratedLegacySetting = false;

			Text = ReadSetting<string>(settings, UnifiedSettingsService.Text, UnifiedSettingsService.LegacyText, migrationComplete, ref migratedLegacySetting);
			ShowIcon = ReadSetting<bool>(settings, UnifiedSettingsService.ShowIcon, UnifiedSettingsService.LegacyShowIcon, migrationComplete, ref migratedLegacySetting);
			ShowNewButton = ReadSetting<bool>(settings, UnifiedSettingsService.ShowNewButton, UnifiedSettingsService.LegacyShowNewButton, migrationComplete, ref migratedLegacySetting);
			ShowExportButton = ReadSetting<bool>(settings, UnifiedSettingsService.ShowExportButton, UnifiedSettingsService.LegacyShowExportButton, migrationComplete, ref migratedLegacySetting);
			ShowImportButton = ReadSetting<bool>(settings, UnifiedSettingsService.ShowImportButton, UnifiedSettingsService.LegacyShowImportButton, migrationComplete, ref migratedLegacySetting);

			IReadOnlyList<MenuItemSetting> savedMenuItems = null;
			if (TryReadArray<MenuItemSetting>(settings, UnifiedSettingsService.MenuItems, out savedMenuItems) && savedMenuItems.Count > 0)
			{
				MenuItems = DeserializeMenuItems(savedMenuItems, out bool needsNameRefresh, out bool canRewriteArray);
				if (needsNameRefresh && canRewriteArray)
					migratedLegacySetting = true;
			}
			else if (!migrationComplete && TryReadLegacyMenuItems(settings, out string legacyMenuItemsXml))
			{
				try
				{
					MenuItems = legacyMenuItemsXml.DeserializeObject<List<MenuItem>>() ?? new List<MenuItem>();
					migratedLegacySetting = true;
				}
				catch
				{
					MenuItems = new List<MenuItem>();
				}
			}
			else
			{
				// An empty array, including Reset to Default, means the collection is empty.
				MenuItems = new List<MenuItem>();
			}

			if (migratedLegacySetting)
				SaveSettingsToStorage();
			else if (!migrationComplete)
				UnifiedSettingsService.MarkMigrationComplete();
		}

		private static List<MenuItem> DeserializeMenuItems(IEnumerable<MenuItemSetting> serializedItems, out bool needsNameRefresh, out bool canRewriteArray)
		{
			var items = new List<MenuItem>();
			needsNameRefresh = false;
			canRewriteArray = true;
			foreach (MenuItemSetting setting in serializedItems)
			{
				string serializedItem = setting?.Xml;
				if (string.IsNullOrWhiteSpace(serializedItem))
				{
					canRewriteArray = false;
					continue;
				}

				try
				{
					MenuItem item = serializedItem.DeserializeObject<MenuItem>();
					if (item != null)
					{
						if (!string.Equals(setting.Name, item.Name, System.StringComparison.Ordinal))
							needsNameRefresh = true;
						items.Add(item);
					}
					else
					{
						canRewriteArray = false;
					}
				}
				catch
				{
					// Ignore malformed entries while preserving the rest of the collection.
					canRewriteArray = false;
				}
			}
			return items;
		}

		private static bool TryReadLegacyMenuItems(ISettingsWriter settings, out string xml)
		{
			if (TryReadStored(settings, UnifiedSettingsService.PreviousMenuItemsXml, out xml)
				&& !string.IsNullOrWhiteSpace(xml))
				return true;

			return TryReadStored(settings, UnifiedSettingsService.LegacyMenuItemsXml, out xml)
				&& !string.IsNullOrWhiteSpace(xml);
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

		private static bool TryReadArray<T>(ISettingsWriter settings, string moniker, out IReadOnlyList<T> value)
		{
			var result = settings.GetArray<T>(moniker, SettingReadOptions.NoRequirements | SettingReadOptions.NoFallbackToDefault);
			value = result.Value;
			return result.Outcome == SettingRetrievalOutcome.Success;
		}

		public string SaveSettingsToStorage()
		{
			ISettingsWriter settings = UnifiedSettingsService.GetWriter();
			if (settings == null)
				return "Unified Settings service is unavailable.";

			var serializedItems = (MenuItems ?? new List<MenuItem>())
				.Select(item => new MenuItemSetting { Name = item.Name ?? string.Empty, Xml = item.SerializeObject() })
				.ToList();

			var arrayChange = settings.EnqueueArrayChange(UnifiedSettingsService.MenuItems, serializedItems);
			if (arrayChange.Outcome != SettingChangeOutcome.PendingCommit
				&& arrayChange.Outcome != SettingChangeOutcome.PendingCommitWithoutValidation)
				return $"Menu Items were rejected ({arrayChange.Outcome}): {arrayChange.Message}";

			settings.EnqueueChange(UnifiedSettingsService.Text, Text ?? string.Empty);
			settings.EnqueueChange(UnifiedSettingsService.ShowIcon, ShowIcon);
			settings.EnqueueChange(UnifiedSettingsService.ShowNewButton, ShowNewButton);
			settings.EnqueueChange(UnifiedSettingsService.ShowExportButton, ShowExportButton);
			settings.EnqueueChange(UnifiedSettingsService.ShowImportButton, ShowImportButton);
			var commit = settings.RequestCommit("Save SSMS Object Explorer Menu settings");
			if (commit.Outcome == SettingCommitOutcome.PendingApproval)
				return "SSMS is waiting for approval to save the menu items.";
			if (commit.Outcome == SettingCommitOutcome.InternalError)
				return $"SSMS could not save the menu items: {commit.Message}";
			if (commit.Outcome == SettingCommitOutcome.Success || commit.Outcome == SettingCommitOutcome.NoChangesQueued)
				UnifiedSettingsService.MarkMigrationComplete();

			return null;
		}
	}
}
