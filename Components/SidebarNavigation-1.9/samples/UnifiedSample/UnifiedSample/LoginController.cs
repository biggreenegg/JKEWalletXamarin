using System;
using System.Drawing;
using UIKit;
using Foundation;
using CoreGraphics;
using UnifiedSample;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.iOS;

namespace Sample
{
	public partial class LoginController : BaseController
	{
		public LoginController() : base(null, null)
		{
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Images/login2.png"));

			var username = new UITextField(new RectangleF(0, 15, 320, 50));
			username.Font = UIFont.SystemFontOfSize(16.0f);
			username.TextAlignment = UITextAlignment.Center;
			username.TextColor = UIColor.Blue;
			username.Placeholder = "Enter your username";
			username.BorderStyle = UITextBorderStyle.RoundedRect;
			username.AutocorrectionType = UITextAutocorrectionType.No;
			username.AutocapitalizationType = UITextAutocapitalizationType.None;
			//username.Center = View.Center;

			var password = new UITextField(new RectangleF(0, 75, 320, 50));
			password.Font = UIFont.SystemFontOfSize(16.0f);
			password.TextAlignment = UITextAlignment.Center;
			password.TextColor = UIColor.Blue;
			password.SecureTextEntry = true;
			password.AutocorrectionType = UITextAutocorrectionType.No;
			password.AutocapitalizationType = UITextAutocapitalizationType.None;
			password.Placeholder = "Enter your password";
			password.BorderStyle = UITextBorderStyle.RoundedRect;
			//password.Center = View.Center;

			var loginButton = new UIButton(UIButtonType.System);
			//loginButton.Center = View.Center;

			loginButton.Frame = new RectangleF(120, 140, 80, 30);
			loginButton.SetTitleColor(UIColor.White, forState: UIControlState.Normal);
			loginButton.SetTitle("Login", UIControlState.Normal);
			loginButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			loginButton.BackgroundColor = UIColor.FromRGB(66, 121, 189);


			var errorView = new UIView
			{

				Frame = new RectangleF(0, 250, (float)this.View.Bounds.Width, 50),
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
				Center = View.Center

			};
			var errorlabel = new UILabel(new RectangleF(75, 0, 200, 25));
			errorlabel.Font = UIFont.SystemFontOfSize(16.0f);
			errorlabel.TextAlignment = UITextAlignment.Center;
			errorlabel.TextColor = UIColor.Red;
			errorView.Add(errorlabel);


			loginButton.TouchUpInside += (sender, e) =>
			{
			Console.WriteLine("sending login information");
			//LoginResponse result = docdb.login(username.Text, password.Text);
			LoginResponse result = aspcloudant.login(username.Text, password.Text);

			if (result.status.Equals("success"))
			{
			Globals.isloggedin = true;
			Globals.loggedinusername = result.username;
			SidebarController.ChangeContentView(new AccountsController());
			}
			else {
				errorlabel.Text = result.errorstring;
			}
			};

			var loginView = new UIView
			{

				Frame = new RectangleF(0, 50, (float)this.View.Bounds.Width, 200),
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
				//Center = View.Center

			};


			loginView.AddSubviews(username, password, loginButton);

			var topView = new UIView
			{
				BackgroundColor = UIColor.FromRGB(66, 121, 189),
				Frame = new RectangleF(0, 25, (float)this.View.Bounds.Width, 25),
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth
			};
			//topView.Add(buttonRect);


			var topmenulabel = new UILabel(new RectangleF(75, 0, (float)topView.Bounds.Width, 25));
			topmenulabel.Font = UIFont.SystemFontOfSize(16.0f);
			topmenulabel.TextAlignment = UITextAlignment.Left;
			topmenulabel.TextColor = UIColor.White;
			topmenulabel.Text = "Login to JKE Wallet";

			topView.AddSubviews(topmenulabel);
			View.AddSubviews(topView, loginView, errorView);
			//View.Add(password);
			//View.Add(loginButton);
			//View.Add(menuButton);

			if (Globals.isloggedin)
			{
				loginView.Hidden = true;
			}
			else {
				loginView.Hidden = false;
			}
		}
	}

}