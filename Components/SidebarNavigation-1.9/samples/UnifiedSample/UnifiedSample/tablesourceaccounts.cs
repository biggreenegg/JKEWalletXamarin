using System;
using Foundation;
using UIKit;

namespace UnifiedSample
{
	public class TableSourceAccounts : UITableViewSource
	{

		Account[] accounts;
		string CellIdentifier = "TableCell";

		public TableSourceAccounts(Account[] items)
		{
			accounts = items;
		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return accounts.Length;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			Account item = accounts[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ 
				cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier); 
			}

			cell.TextLabel.Text = item.accountname;
			cell.DetailTextLabel.Text = item.balance.ToString("C");
			return cell;
		}
	}
}

