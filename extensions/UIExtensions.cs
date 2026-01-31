using SSMSObjectExplorerMenu.controls;
using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.objects;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SSMSObjectExplorerMenu.extensions
{
    internal static class UIExtensions
    {
        public static IEnumerable<UserDefinedParameter> GetUserDefinedParams(this ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                yield return item.Tag as UserDefinedParameter;
            }
        }

        public static UserDefinedArgument ToUserDefinedArgument(this ArgumentControl control)
            => new UserDefinedArgument(control.Parameter.Name, control.Parameter.Type, control.ParameterValueString);

        public static void RemoveRange(this ListView.ListViewItemCollection litViewItems, IEnumerable<ListViewItem> itemsToRemove)
        {
            foreach (var item in itemsToRemove)
            {
                litViewItems.Remove(item);
            }
        }

        public static IEnumerable<ListViewItem> GetSelectedItems(this ListView listView) => listView.Items.Cast<ListViewItem>().Where(item => item.Selected);

        public static string GetValueByParameterType(this Control control, UserDefinedParameterType parameterType)
            => (parameterType == UserDefinedParameterType.Bit) ? (((CheckBox)control).Checked ? "1" : "0") : control.Text;

        public static Control Align(this Control control, Size size, Point? location = null)
        {
            control.Size = size;
            control.Location = location ?? Point.Empty;
            return control;
        }

        public static ComboBox SetDataSource<TValue>(this ComboBox comboBox, ICollection<TValue> optionsList)
        {
            comboBox.DataSource = null;
            comboBox.DataSource = optionsList.Select(i => new ComboBoxItem<TValue> { Displayed = $"{i}", Value = i }).ToArray();
            comboBox.DisplayMember = nameof(ComboBoxItem<TValue>.Displayed);
            comboBox.ValueMember = nameof(ComboBoxItem<TValue>.Value);
            return comboBox;
        }
    }
}
