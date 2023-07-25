namespace SSMSObjectExplorerMenu.objects
{
	public class MenuItemInstance
	{
		public MenuItem MenuItem { get; set; } = new MenuItem();
		public NodeInfo NodeInfo { get; set; } = new NodeInfo();

		public MenuItemInstance() 
		{ 
		
		}

		public MenuItemInstance(MenuItem menuItem, NodeInfo nodeInfo)
		{
			MenuItem = menuItem;
			NodeInfo = nodeInfo;
		}
	}
}
