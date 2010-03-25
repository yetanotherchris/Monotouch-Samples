using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Linq;

namespace NavigationControllerSample
{
	public class NavigationController : UINavigationController
	{
		HomeViewController _firstController;
		
//		public override void ViewDidLoad ()
//		{
//			_firstController = new HomeViewController();
//			PushViewController(_firstController,true);
//			
//			base.ViewDidLoad ();
//		}
		
		public override void ViewDidLoad ()
		{
			var firstController = new HomeViewController();
			var secondController = new Level2ViewController();
			var thirdController = new Level3ViewController();
							
			var viewControllers = ViewControllers.ToList();
			viewControllers.Add(firstController);
			viewControllers.Add(secondController);
			viewControllers.Add(thirdController);
			ViewControllers = viewControllers.ToArray();
	
			base.ViewDidLoad ();
		}
	}
	
	public class HomeViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			Title = "Home";
			
			// A 'view' aka label control for this view
			UILabel label = new UILabel();
			label.Text = "HomeViewController";
			label.Frame = Center(100,100);
			label.BackgroundColor = UIColor.LightGray;
			View.AddSubview(label);
			
			// 2 toolbar items
			UIBarButtonItem item1 = new UIBarButtonItem();
			item1.Title = "Click me";
			item1.Clicked += delegate(object sender, EventArgs e) {
				Level2ViewController controller = new Level2ViewController();
				NavigationController.PushViewController(controller,true);
			};
			
			UIBarButtonItem item2 = new UIBarButtonItem();
			item2.Title = "View with no back";
			item2.Clicked += delegate(object sender, EventArgs e) {
				ViewWithNoBackController controller = new ViewWithNoBackController();
				NavigationController.PushViewController(controller,true);
			};
			
			ToolbarItems = new UIBarButtonItem[] {item1,item2};
			
			
			base.ViewDidLoad ();
		}
		
		public override void ViewWillAppear (bool animated)
		{
			// Re-show the toolbar here for consistency
			NavigationController.SetToolbarHidden(false,true);
			base.ViewWillAppear (animated);
		}
		
		public RectangleF Center(float width,float height)
		{		
			var rect = new RectangleF((View.Frame.Width / 2) - (width /2),(View.Frame.Height / 2) - (height /2),width,height);
			
			// Prints:
			// Rect: {X=110,Y=180,Width=100,Height=100}
			// Frame: {X=0,Y=20,Width=320,Height=460}
			Console.WriteLine("Rect: {0}",rect);
			Console.WriteLine("Frame: {0}",View.Frame);
			
			return rect;
		}
	}
	
	public class ViewWithNoBackController: UIViewController
	{
		public override void ViewDidLoad ()
		{
			Title = "Settings";
			
			// The label again
			UILabel label = new UILabel();
			label.Text = "ViewWithNoBackController";
			label.Frame = new RectangleF(100,100,100,100);
			View.AddSubview(label);
			
			// Demonstrates hiding the back and toolbars.
			NavigationItem.SetHidesBackButton(true,true);
			NavigationController.SetToolbarHidden(true,true);
			
			base.ViewDidLoad ();
		}
		
		
	}
	
	public class Level2ViewController: UIViewController
	{
		public override void ViewDidLoad ()
		{
			Title = "Level 2";
			
			UILabel label = new UILabel();
			label.Text = "Level2ViewController";
			label.Frame = new System.Drawing.RectangleF(100,100,100,100);
			View.AddSubview(label);
			
			// A new toolbar with items
			UIBarButtonItem item = new UIBarButtonItem();
			item.Title = "Another item";
			item.Clicked += delegate(object sender, EventArgs e) {
				Level3ViewController controller = new Level3ViewController();
				NavigationController.PushViewController(controller,true);
			};
			
			ToolbarItems = new UIBarButtonItem[] {item};
			
			base.ViewDidLoad ();
		}
		
		public override void ViewWillAppear (bool animated)
		{
			// Re-show the toolbar here for consistency
			NavigationController.SetToolbarHidden(false,true);
			base.ViewWillAppear (animated);
		}
	}
	
	public class Level3ViewController: UIViewController
	{
		public override void ViewDidLoad ()
		{
			Title = "Level 3";
			
			// The label again
			UILabel label = new UILabel();
			label.Text = "Level3ViewController";
			label.Frame = new System.Drawing.RectangleF(100,100,100,100);
			View.AddSubview(label);
			
			// Hide the toolbar for this view
			NavigationController.SetToolbarHidden(true,true);
			
			base.ViewDidLoad ();
		}
	}
}
