using System;
using MonoTouch.UIKit;

namespace TableViewSample
{
	public class NavController : UINavigationController
	{
		public override void ViewDidLoad ()
		{
			MainTableController table = new MainTableController(UITableViewStyle.Grouped);			
			SetViewControllers(new UIViewController[] {table},false);
			
			base.ViewDidLoad ();
		}
	}
}
