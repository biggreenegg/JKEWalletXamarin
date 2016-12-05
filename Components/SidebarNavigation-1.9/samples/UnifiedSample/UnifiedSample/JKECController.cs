using Foundation;
using System;
using UIKit;
using UnifiedSample;
using Sample;
using System.Collections.Generic;
using SidebarNavigation;

namespace UnifiedSample
{
    public partial class JKECController : UITableViewController
    {
		private IList<string> Accounts = new List<string>();

		private IList<string> Payees = new List<string>();

		private nint payeetype = 0;


		public JKECController (IntPtr handle) : base (handle)
        {
			
        }

		public override void ViewWillAppear(bool animated)
		{

			//Account[] myaccounts = docdb.getaccounttypes();
			Account[] myaccounts = aspdocdb.getaccounttypes();

			for (int j = 0; j < myaccounts.Length; j++)
			{
				if (Accounts.IndexOf(myaccounts[j].accountname) == -1)
					Accounts.Add(myaccounts[j].accountname);
			}

			//String[] payees = docdb.getpayees();
			Check[] payees = aspdocdb.getpayees();

			for (int j = 0; j < payees.Length; j++)
			{
				if (Payees.IndexOf(payees[j].payee) == -1)
					Payees.Add(payees[j].payee);
			}

			this.chooseaccount.Model = new PickerModel(this.Accounts);

			payeeswitcher.SelectedSegment = payeetype;
			choosepayee.Model = new PickerModel(this.Payees);
			payeeswitcher.ValueChanged += (sender, e) =>
			{
				payeetype = (sender as UISegmentedControl).SelectedSegment;
				if (payeetype == 0)
				{
					choosepayee.Hidden = true;
					payeeentered.Hidden = false;

				}
				else {
					choosepayee.Hidden = false;
					payeeentered.Hidden = true;
				}
				// do something with selectedSegmentId
			};

			menubutton.TouchUpInside += (sender, e) =>
			{
				SidebarNavigation.SidebarController mycontroller = (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.SidebarController;
				mycontroller.ToggleMenu();
			};
			savecheck.TouchUpInside += (sender, e) =>
			{

				Check myCheck = new Check();
				myCheck.account = this.chooseaccount.Model.GetTitle(this.chooseaccount, this.chooseaccount.SelectedRowInComponent(0), 0);
				myCheck.amount = (string)this.amountentered.Text;
				DateTime checkdate = Convert.ToDateTime((string)this.dateentered.Text);
				DateTime epoch = new DateTime(1970, 1, 1);
				TimeSpan epochTimeSpan = checkdate - epoch;
				myCheck.date = (int)epochTimeSpan.TotalSeconds;
				myCheck.desc = (string)this.descriptionentered.Text;
				if (payeetype == 0)
					myCheck.payee = (string)this.payeeentered.Text;
				else
					myCheck.payee = (string)this.choosepayee.Model.GetTitle(this.choosepayee, this.choosepayee.SelectedRowInComponent(0), 0);
				myCheck.username = "knizami";
				//var result = docdb.savecheck(myCheck);
				var result = aspdocdb.savecheck(myCheck);
				Console.WriteLine("sending check information with account type: " + myCheck.account);
				if (result)
				{
					Console.WriteLine("Check Saved");
					//SidebarController.ChangeContentView(new AccountsController());
				}
				else {
					Console.WriteLine("Check Not Saved");
				}
			};
		}
    }
}