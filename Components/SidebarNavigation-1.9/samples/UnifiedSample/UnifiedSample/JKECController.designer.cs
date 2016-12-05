// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UnifiedSample
{
    [Register ("JKECController")]
    partial class JKECController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell account { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell amount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField amountentered { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView chooseaccount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView choosepayee { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell date { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UnifiedSample.dateentered dateentered { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell description { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView descriptionentered { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton menubutton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell payee { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField payeeentered { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl payeeswitcher { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton savecheck { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (account != null) {
                account.Dispose ();
                account = null;
            }

            if (amount != null) {
                amount.Dispose ();
                amount = null;
            }

            if (amountentered != null) {
                amountentered.Dispose ();
                amountentered = null;
            }

            if (chooseaccount != null) {
                chooseaccount.Dispose ();
                chooseaccount = null;
            }

            if (choosepayee != null) {
                choosepayee.Dispose ();
                choosepayee = null;
            }

            if (date != null) {
                date.Dispose ();
                date = null;
            }

            if (dateentered != null) {
                dateentered.Dispose ();
                dateentered = null;
            }

            if (description != null) {
                description.Dispose ();
                description = null;
            }

            if (descriptionentered != null) {
                descriptionentered.Dispose ();
                descriptionentered = null;
            }

            if (menubutton != null) {
                menubutton.Dispose ();
                menubutton = null;
            }

            if (payee != null) {
                payee.Dispose ();
                payee = null;
            }

            if (payeeentered != null) {
                payeeentered.Dispose ();
                payeeentered = null;
            }

            if (payeeswitcher != null) {
                payeeswitcher.Dispose ();
                payeeswitcher = null;
            }

            if (savecheck != null) {
                savecheck.Dispose ();
                savecheck = null;
            }
        }
    }
}