using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace TableViewSample
{
	public class MainTableController : UITableViewController
	{
		// Allow us to set the style of the TableView
		public MainTableController(UITableViewStyle style) : base(style)
		{
		}
		
		public override void ViewDidLoad ()
		{
			TableView.DataSource = new MainTableDataSource();
			TableView.Delegate = new MainTableDelegate(this);
			
			base.ViewDidLoad ();
		}
	}
}
