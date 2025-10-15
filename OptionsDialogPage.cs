using Microsoft.VisualStudio.Shell;
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
		public bool ShowIcon { get; set; } = true;

		[DefaultValue("My Scripts")]
		[Category("General options")]
		[DisplayName("Name")]
		[Description("Text to display in the main menu item")]
		public string Text { get; set; } = "My Scripts";

		[DefaultValue(true)]
		[Category("General options")]
		[DisplayName("New")]
		[Description("Display the New menu item button")]
		public bool ShowNewButton { get; set; } = true;

        [DefaultValue(true)]
        [Category("General options")]
        [DisplayName("Options")]
        [Description("Display the Options button")]
        public bool ShowOptionsButton { get; set; } = true;

        [DefaultValue(true)]
        [Category("General options")]
        [DisplayName("Export")]
        [Description("Display the Export button")]
        public bool ShowExportButton { get; set; } = true;

        [DefaultValue(true)]
        [Category("General options")]
        [DisplayName("Import")]
        [Description("Display the Import button")]
        public bool ShowImportButton { get; set; } = true;

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
