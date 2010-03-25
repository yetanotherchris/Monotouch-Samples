using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace TableViewSample
{
	public class MainTableDataSource : UITableViewDataSource
	{
		private List<string> _items;
		private string _cellId;
		
		public MainTableDataSource()
		{
			_cellId = "cellid";
			_items = new List<string>()
			{
				"Checked items demo",
				"Various styles demo",
				"Editable tables demo"
			};
		}
		
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Items";
		}
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return _items.Count;
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var row = indexPath.Row;
			UITableViewCell cell = tableView.DequeueReusableCell(_cellId); 
			
			if (cell == null )
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, _cellId);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			}
			
			cell.TextLabel.Text = _items[indexPath.Row];
			    
			return cell; 
		}
	}
}
