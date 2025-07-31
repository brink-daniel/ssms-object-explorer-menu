namespace SSMSObjectExplorerMenu.objects
{
	public class MenuItemInstance
	{
		public MenuItem MenuItem { get; set; } = new MenuItem();
		public NodeInfo NodeInfo { get; set; } = new NodeInfo();
		public string Name { get; set; }

		public MenuItemInstance() 
		{ 
		
		}

		public MenuItemInstance(MenuItem menuItem, NodeInfo nodeInfo, string name)
		{
			MenuItem = menuItem;
			NodeInfo = nodeInfo;
			Name = name;
		}
	}
}
