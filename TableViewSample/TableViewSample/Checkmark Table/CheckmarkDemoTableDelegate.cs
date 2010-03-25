using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace TableViewSample
{
	public class CheckmarkDemoTableDelegate : UITableViewDelegate
	{		
		private CheckmarkDemoTableController _controller;
		private NSIndexPath _previousRow;
		
		public CheckmarkDemoTableDelegate(CheckmarkDemoTableController controller)
		{
			_controller = controller;
			_previousRow = NSIndexPath.FromRowSection(Settings.SelectedIndex,0);
		}
		
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			// Uncheck the previous row
			if (_previousRow != null)
				tableView.CellAt(_previousRow).Accessory = UITableViewCellAccessory.None;
			
			// Do something with the row
			var row = indexPath.Row;
			Settings.SelectedIndex = row;
			tableView.CellAt(indexPath).Accessory = UITableViewCellAccessory.Checkmark;
			
			Console.WriteLine("{0} selected",_controller.Items[row]);
			
			_previousRow = indexPath;
			
			// This is what the Settings does under Settings>Mail>Show on an iPhone
			tableView.DeselectRow(indexPath,false);
		}
	}
}
