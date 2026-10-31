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

        internal const string Text = "ssmsObjectExplorerMenu.text";
        internal const string ShowIcon = "ssmsObjectExplorerMenu.showIcon";
        internal const string ShowNewButton = "ssmsObjectExplorerMenu.showNewButton";
        internal const string ShowOptionsButton = "ssmsObjectExplorerMenu.showOptionsButton";
        internal const string ShowExportButton = "ssmsObjectExplorerMenu.showExportButton";
        internal const string ShowImportButton = "ssmsObjectExplorerMenu.showImportButton";
        internal const string MenuItemsXml = "ssmsObjectExplorerMenu.menuItemsXml";

        private static ISettingsWriter writer;

        internal static void Initialize(IServiceProvider serviceProvider)
        {
            var manager = serviceProvider.GetService(typeof(SVsUnifiedSettingsManager)) as ISettingsManager;
            writer = manager?.GetWriter(SettingsOwner);
        }

        internal static ISettingsWriter GetWriter() => writer;
    }
}
