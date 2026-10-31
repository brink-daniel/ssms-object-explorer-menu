using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Utilities.UnifiedSettings;

namespace SSMSObjectExplorerMenu
{
    // This service marker is internal to the VS shell assembly. Services are resolved
    // by GUID, so declaring the marker locally lets the extension request the service.
    [Guid("e3684f31-344e-42ea-9047-b620fdc7ac25")]
    internal interface SVsUnifiedSettingsManager
    {
    }

    internal static class UnifiedSettingsService
    {
        private const string SettingsOwner = "SSMS Object Explorer Menu";

        internal const string Text = "sqlServerObjectExplorer.ssmsObjectExplorerMenu.text";
        internal const string ShowIcon = "sqlServerObjectExplorer.ssmsObjectExplorerMenu.showIcon";
        internal const string ShowNewButton = "sqlServerObjectExplorer.ssmsObjectExplorerMenu.showNewButton";
        internal const string ShowOptionsButton = "sqlServerObjectExplorer.ssmsObjectExplorerMenu.showOptionsButton";
        internal const string ShowExportButton = "sqlServerObjectExplorer.ssmsObjectExplorerMenu.showExportButton";
        internal const string ShowImportButton = "sqlServerObjectExplorer.ssmsObjectExplorerMenu.showImportButton";
        internal const string MenuItemsXml = "sqlServerObjectExplorer.ssmsObjectExplorerMenu.menuItemsXml";
        internal const string MigrationMarker = "ssmsObjectExplorerMenu.categoryMigrationComplete";
        internal const string LegacyPrefix = "ssmsObjectExplorerMenu.";
        internal const string LegacyText = LegacyPrefix + "text";
        internal const string LegacyShowIcon = LegacyPrefix + "showIcon";
        internal const string LegacyShowNewButton = LegacyPrefix + "showNewButton";
        internal const string LegacyShowOptionsButton = LegacyPrefix + "showOptionsButton";
        internal const string LegacyShowExportButton = LegacyPrefix + "showExportButton";
        internal const string LegacyShowImportButton = LegacyPrefix + "showImportButton";
        internal const string LegacyMenuItemsXml = LegacyPrefix + "menuItemsXml";

        private static ISettingsWriter writer;

        internal static void Initialize(IServiceProvider serviceProvider)
        {
            var manager = serviceProvider.GetService(typeof(SVsUnifiedSettingsManager)) as ISettingsManager;
            writer = manager?.GetWriter(SettingsOwner);
        }

        internal static ISettingsWriter GetWriter() => writer;
    }
}
