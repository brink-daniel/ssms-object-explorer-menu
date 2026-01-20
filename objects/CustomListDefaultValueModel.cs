using System.Collections.Generic;

namespace SSMSObjectExplorerMenu.objects
{
    internal class CustomListDefaultValueModel
    {
        public string DefaultValueSelected { get; set; }

        public IEnumerable<string> AvailableOptions { get; set; }
    }
}
