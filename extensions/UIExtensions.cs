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
                yield return new UserDefinedParameter
                {
                    Name = item.Text,
                    Type = (UserDefinedParameterType)item.SubItems.Cast<ListViewItem.ListViewSubItem>().Last().Tag
                };
            }
        }

        public static UserDefinedArgument ToUserDefinedArgument(this ArgumentControl control)
            => new UserDefinedArgument(control.ParameterName, control.ParameterType, control.ParameterValueString);
    }
}
