using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace TableViewSample
{
	public class MainTableDelegate : UITableViewDelegate
	{		
		private MainTableController _controller;
		
		public MainTableDelegate(MainTableController controller)
		{
			_controller = controller;	
		}
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewController nextController = null;
			
			switch (indexPath.Row)
			{
				case 0:
					nextController = new CheckmarkDemoTableController(UITableViewStyle.Grouped);
					break;
				case 1:
					nextController = new StyleDemoTableController(UITableViewStyle.Grouped);
					break;
				case 2:
					nextController = new EditableTableController(UITableViewStyle.Plain);
					break;
				default:
					break;
			}
			
			if (nextController != null)
				_controller.NavigationController.PushViewController(nextController,true);
		}
	}
}
