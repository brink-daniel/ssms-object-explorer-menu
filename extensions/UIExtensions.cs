using SSMSObjectExplorerMenu.enums;
using SSMSObjectExplorerMenu.objects;
using System.Collections.Generic;
using System.Linq;
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
    }
}
