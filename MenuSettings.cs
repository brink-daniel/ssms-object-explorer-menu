using Microsoft.VisualStudio.Utilities.UnifiedSettings;
using System.ComponentModel;
using SSMSObjectExplorerMenu.extensions;
using SSMSObjectExplorerMenu.objects;
using System;
using System.Collections.Generic;
using System.Globalization;
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
		public string MenuItemOrder { get; set; } = "As configured";
		public string MenuItemsXml => (MenuItems ?? new List<MenuItem>()).SerializeObject();

		public void LoadSettingsFromStorage(IServiceProvider legacyPageServiceProvider = null)
		{
			ISettingsWriter settings = UnifiedSettingsService.GetWriter();
			if (settings == null)
				return;

			bool migrationComplete = UnifiedSettingsService.IsMigrationComplete();
			bool migratedLegacySetting = false;
			Dictionary<string, object> legacyOptions = null;
			if (!migrationComplete)
				legacyOptions = ReadLegacyOptionsPage(legacyPageServiceProvider);

			Text = ReadSetting(settings, UnifiedSettingsService.Text, UnifiedSettingsService.LegacyText, "Text", "My Scripts", legacyOptions, migrationComplete, ref migratedLegacySetting);
			ShowIcon = ReadSetting(settings, UnifiedSettingsService.ShowIcon, UnifiedSettingsService.LegacyShowIcon, "ShowIcon", true, legacyOptions, migrationComplete, ref migratedLegacySetting);
			ShowNewButton = ReadSetting(settings, UnifiedSettingsService.ShowNewButton, UnifiedSettingsService.LegacyShowNewButton, "ShowNewButton", true, legacyOptions, migrationComplete, ref migratedLegacySetting);
			ShowExportButton = ReadSetting(settings, UnifiedSettingsService.ShowExportButton, UnifiedSettingsService.LegacyShowExportButton, "ShowExportButton", true, legacyOptions, migrationComplete, ref migratedLegacySetting);
			ShowImportButton = ReadSetting(settings, UnifiedSettingsService.ShowImportButton, UnifiedSettingsService.LegacyShowImportButton, "ShowImportButton", true, legacyOptions, migrationComplete, ref migratedLegacySetting);
			MenuItemOrder = ReadSetting(settings, UnifiedSettingsService.MenuItemOrder, null, null, "As configured", null, migrationComplete, ref migratedLegacySetting);

			IReadOnlyList<MenuItemSetting> savedMenuItems = null;
			bool hasSavedMenuItems = TryReadArray<MenuItemSetting>(settings, UnifiedSettingsService.MenuItems, out savedMenuItems);
			if (hasSavedMenuItems && savedMenuItems != null && savedMenuItems.Count > 0)
			{
				MenuItems = DeserializeMenuItems(savedMenuItems, out bool needsNameRefresh, out bool canRewriteArray);
				if (needsNameRefresh && canRewriteArray)
					migratedLegacySetting = true;
			}
			else if (!migrationComplete && (TryReadLegacyMenuItems(settings, out string legacyMenuItemsXml)
				|| TryReadLegacyMenuItems(legacyOptions, out legacyMenuItemsXml)))
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
				// Without legacy data the empty array/default remains empty. After migration,
				// it also preserves an explicit Reset to Default.
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

		private static T ReadSetting<T>(ISettingsWriter settings, string currentMoniker, string legacyMoniker, string legacyPageProperty, T defaultValue, Dictionary<string, object> legacyOptions, bool migrationComplete, ref bool migratedLegacySetting)
		{
			bool hasCurrentValue = TryReadStored(settings, currentMoniker, out T currentValue);
			bool currentIsDefault = !hasCurrentValue || EqualityComparer<T>.Default.Equals(currentValue, defaultValue);

			if (!migrationComplete && currentIsDefault && !string.IsNullOrWhiteSpace(legacyMoniker)
				&& TryReadStored(settings, legacyMoniker, out T unifiedLegacyValue))
			{
				migratedLegacySetting = true;
				return unifiedLegacyValue;
			}

			if (!migrationComplete && currentIsDefault && !string.IsNullOrWhiteSpace(legacyPageProperty) && legacyOptions != null
				&& legacyOptions.TryGetValue(legacyPageProperty, out object registryLegacyValue)
				&& TryConvertLegacyValue(registryLegacyValue, out T convertedLegacyValue))
			{
				migratedLegacySetting = true;
				return convertedLegacyValue;
			}

			return hasCurrentValue ? currentValue : settings.GetValueOrThrow<T>(currentMoniker);
		}

		private static Dictionary<string, object> ReadLegacyOptionsPage(IServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
				return null;

			try
			{
				using (var legacyPage = new OptionsDialogPage())
				{
					legacyPage.Site = new LegacyPageSite(legacyPage, serviceProvider);
					legacyPage.LoadSettingsFromStorage();

					var values = new Dictionary<string, object>
					{
						["Text"] = legacyPage.Text,
						["ShowIcon"] = legacyPage.ShowIcon,
						["ShowNewButton"] = legacyPage.ShowNewButton,
						["ShowExportButton"] = legacyPage.ShowExportButton,
						["ShowImportButton"] = legacyPage.ShowImportButton,
						["MenuItemsXml"] = !string.IsNullOrWhiteSpace(legacyPage.MenuItemsXml)
							? legacyPage.MenuItemsXml
							: (legacyPage.MenuItems ?? new List<MenuItem>()).SerializeObject()
					};
					return values;
				}
			}
			catch
			{
				return null;
			}
		}

		private sealed class LegacyPageSite : ISite
		{
			private readonly IComponent component;
			private readonly IServiceProvider serviceProvider;

			public LegacyPageSite(IComponent component, IServiceProvider serviceProvider)
			{
				this.component = component;
				this.serviceProvider = serviceProvider;
			}

			public IComponent Component => component;
			public IContainer Container => null;
			public bool DesignMode => false;
			public string Name { get; set; }

			public object GetService(System.Type serviceType) => serviceProvider.GetService(serviceType);
		}

		private static bool TryReadLegacyMenuItems(Dictionary<string, object> legacyOptions, out string xml)
		{
			xml = null;
			return legacyOptions != null
				&& legacyOptions.TryGetValue("MenuItemsXml", out object value)
				&& (xml = value as string) != null
				&& !string.IsNullOrWhiteSpace(xml);
		}

		private static bool TryConvertLegacyValue<T>(object legacyValue, out T value)
		{
			try
			{
				if (legacyValue is T typedValue)
				{
					value = typedValue;
					return true;
				}

				value = (T)Convert.ChangeType(legacyValue, typeof(T), CultureInfo.InvariantCulture);
				return true;
			}
			catch
			{
				value = default(T);
				return false;
			}
		}

		private static bool TryReadStored<T>(ISettingsWriter settings, string moniker, out T value)
		{
			try
			{
				var result = settings.GetValue<T>(moniker, SettingReadOptions.NoRequirements | SettingReadOptions.NoFallbackToDefault);
				value = result.Value;
				return result.Outcome == SettingRetrievalOutcome.Success;
			}
			catch
			{
				value = default(T);
				return false;
			}
		}

		private static bool TryReadArray<T>(ISettingsWriter settings, string moniker, out IReadOnlyList<T> value)
		{
			try
			{
				var result = settings.GetArray<T>(moniker, SettingReadOptions.NoRequirements | SettingReadOptions.NoFallbackToDefault);
				value = result.Value;
				return result.Outcome == SettingRetrievalOutcome.Success;
			}
			catch
			{
				value = null;
				return false;
			}
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
			settings.EnqueueChange(UnifiedSettingsService.MenuItemOrder, MenuItemOrder ?? "As configured");
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
