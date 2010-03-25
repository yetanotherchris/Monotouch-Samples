using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace TableViewSample
{
	public class CheckmarkDemoTableController : UITableViewController
	{
		private List<ItemInfo> _items;
		
		public List<ItemInfo> Items
		{
			get
			{
				if (_items == null)
					_items = ((CheckmarkDemoTableDataSource)TableView.DataSource).Items;
				
				return _items;
			}
		}
		
		public CheckmarkDemoTableController(UITableViewStyle style) : base(style)
		{
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true/false if your app supports:
			// toInterfaceOrientation == UIInterfaceOrientation.LandscapeLeft;
			// toInterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
			// toInterfaceOrientation == UIInterfaceOrientation.Portrait;
			// toInterfaceOrientation == UIInterfaceOrientation.PortraitUpsideDown;
			return true;
		}
		
		public override void ViewDidLoad ()
		{			
			NavigationItem.Title = "Checkmark table demo";
			
			TableView.DataSource = new CheckmarkDemoTableDataSource();
			TableView.Delegate = new CheckmarkDemoTableDelegate(this);
			
			base.ViewDidLoad ();
		}
	}
}
