using Foundation;
using System;
using UIKit;
using UnifiedSample;
using Sample;
using System.Collections.Generic;
using SidebarNavigation;


namespace UnifiedSample
{
	public partial class JKEPController : UITableViewController
	{
		private IList<string> Accounts = new List<string>();

		private IList<string> Payees = new List<string>();

		private nint payeetype = 0;
		LoadingOverlay loadingOverlay;

		public JKEPController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewWillAppear(bool animated)
		{

			//Account[] myaccounts = docdb.getaccounttypes();

			//String[] payees = docdb.getpayees();
			Check[] payees = aspdocdb.getpayees();

			for (int j = 0; j < payees.Length; j++)
			{
				if (Payees.IndexOf(payees[j].payee) == -1)
					Payees.Add(payees[j].payee);
			}

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
			sendpayment.TouchUpInside += (sender, e) =>
			{
				var bounds = UIScreen.MainScreen.Bounds;

				// show the loading overlay on the UI thread using the correct orientation sizing
				loadingOverlay = new LoadingOverlay(bounds);
				View.Add(loadingOverlay);
				string payeename = null;
				if (payeetype == 0)
					payeename = (string)this.payeeentered.Text;
				else
					payeename = (string)this.choosepayee.Model.GetTitle(this.choosepayee, this.choosepayee.SelectedRowInComponent(0), 0);
				//var result = docdb.savecheck(myCheck);
				AuthResponse result = usaepayservice.auth(payeename, this.cardnumber.Text, this.dateentered.Text);
				loadingOverlay.Hide();
				Console.WriteLine("sending charge information");
				UIAlertView alert = new UIAlertView();
				alert.AddButton("OK");
				alert.Title = "Authorization Response";

				if (result != null)
				{
					Console.WriteLine("Processed Payment");
					String authresp = "Auth Code: " + result.Auth.AuthCode + "\n" +
															"Result: " + result.Auth.Result + "\n";
					alert.Message = authresp;
					alert.Show();
					
				}
				else {
					Console.WriteLine("Payment Processing Failed");
					alert.Message = "Payment Processing Failed";
					alert.Show();
				}


			};
		}
	}
	}