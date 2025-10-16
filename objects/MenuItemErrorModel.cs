using System.Collections.Generic;

namespace SSMSObjectExplorerMenu.objects
{
    public class MenuItemErrorModel
    {
        public string MenuItemName { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
