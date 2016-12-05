using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace UnifiedSample
{
	public class TableSource : UITableViewSource
	{

		IList<Check> checks;
		string CellIdentifier = "TableCell";

		public TableSource(IList<Check> items)
		{
			checks = items;
		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return checks.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			Check item = checks[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ 
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier); 
			}

			cell.TextLabel.Text = item.desc + "     $" + item.amount;
			cell.DetailTextLabel.Text = item.account;
			cell.ImageView.Image = UIImage.FromFile("Images/charge.png"); // don't use for Value2
			return cell;
		}
	}
}

