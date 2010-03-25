using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace TableViewSample
{
	public class EditableTableController : UITableViewController
	{
		private UIBarButtonItem _buttonEdit;
		private UIBarButtonItem _buttonDone;
		
		public EditableTableController(UITableViewStyle style) : base(style)
		{
		}
		
		public override void ViewDidLoad ()
		{
			NavigationItem.Title = "Editable table demo";
			
			// Add Edit and Done buttons
			_buttonEdit = new UIBarButtonItem(UIBarButtonSystemItem.Edit);
			_buttonDone = new UIBarButtonItem(UIBarButtonSystemItem.Done);
			_buttonEdit.Clicked += Handle_buttonEditClicked;
			_buttonDone.Clicked += Handle_buttonDoneClicked;
			
			NavigationItem.RightBarButtonItem = _buttonEdit;
			
			TableView.DataSource = new EditableTableDataSource();
			
			base.ViewDidLoad ();
		}
		
		private void Handle_buttonDoneClicked (object sender, EventArgs e)
		{
			Editing = false;
			NavigationItem.RightBarButtonItem = _buttonEdit;
		}

		private void Handle_buttonEditClicked (object sender, EventArgs e)
		{
			Editing = true;
			NavigationItem.RightBarButtonItem = _buttonDone;
		}
	}
}
