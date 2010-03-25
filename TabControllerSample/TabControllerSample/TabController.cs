using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace TabControllerSample
{
	public class TabControllerContainer : UITabBarController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			FirstViewController controller1 = new FirstViewController();
			SecondViewController controller2 = new SecondViewController();
			ThirdViewController controller3 = new ThirdViewController();
			
			SetViewControllers(new UIViewController[] {controller1,controller2,controller3},true); 
			SelectedViewController = controller1;
			
			// Wrong way round
			//SetToolbarItems(new UIBarButtonItem[]{item1,item2,item3},true);
		}
	}
	
	public class FirstViewController : UIViewController
	{
		
		public FirstViewController()
		{			
			// Tab bar item 
			UITabBarItem item = new UITabBarItem();
			item.Title = "One";
			///item.Image = UIImage.FromFile("Folder/File.png");	
			TabBarItem = item;
		}
			
		public override void ViewDidLoad ()
		{
			UILabel label = new UILabel();
			label.Text = "1st view";
			label.Frame = Center(100,100);
			label.BackgroundColor = UIColor.LightGray;
			View.AddSubview(label);
			
			base.ViewDidLoad ();
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
	
	public class SecondViewController : UIViewController
	{
		public SecondViewController()
		{			
			// Tab bar item 
			UITabBarItem item = new UITabBarItem();
			item.Title = "Two";
			TabBarItem = item;
			
			UIImageView imageview = new UIImageView();
			imageview.Image = UIImage.FromFile("logo.png");
			imageview.SizeToFit();
			imageview.Alpha = 0.5f;
			View.AddSubview(imageview);
			View.SendSubviewToBack(imageview);
		}
		
		public override void ViewDidLoad ()
		{
			UINavigationItem navItem = new UINavigationItem();
			navItem.Title = "Second view";
			
			// Setting animated to true makes it slide from the right the first time it appears.
			UINavigationBar bar = new UINavigationBar();
			bar.SizeToFit(); // important or it won't display
			bar.SetItems(new UINavigationItem[]{navItem},true);
			View.AddSubview(bar);
			
			UILabel label = new UILabel();
			label.Text = "2nd view";
			label.Frame = new System.Drawing.RectangleF(100,100,100,100);
			View.AddSubview(label);
			
			base.ViewDidLoad ();
		}
	}
	
	public class ThirdViewController : UIViewController
	{
		public ThirdViewController()
		{
			UITabBarItem item = new UITabBarItem();
			item.Title = "Three";
			TabBarItem = item;
		}
		
		public override void ViewDidLoad ()
		{
			UILabel label = new UILabel();
			label.Text = "3rd view";
			label.Frame = new System.Drawing.RectangleF(100,100,100,100);
			View.AddSubview(label);
			
			base.ViewDidLoad ();
		}
	}
}
