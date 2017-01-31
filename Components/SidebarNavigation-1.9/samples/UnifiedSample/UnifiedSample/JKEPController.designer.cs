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
    [Register ("JKEPController")]
    partial class JKEPController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell amount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UnifiedSample.amountcharge amountcharged { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UnifiedSample.cardnumber cardnumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView choosepayee { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UnifiedSample.codeentered codeentered { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell date { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UnifiedSample.dateentered dateentered { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton menubutton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField payeeentered { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl payeeswitcher { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton sendpayment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UnifiedSample.transdesc transdesc { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (amount != null) {
                amount.Dispose ();
                amount = null;
            }

            if (amountcharged != null) {
                amountcharged.Dispose ();
                amountcharged = null;
            }

            if (cardnumber != null) {
                cardnumber.Dispose ();
                cardnumber = null;
            }

            if (choosepayee != null) {
                choosepayee.Dispose ();
                choosepayee = null;
            }

            if (codeentered != null) {
                codeentered.Dispose ();
                codeentered = null;
            }

            if (date != null) {
                date.Dispose ();
                date = null;
            }

            if (dateentered != null) {
                dateentered.Dispose ();
                dateentered = null;
            }

            if (menubutton != null) {
                menubutton.Dispose ();
                menubutton = null;
            }

            if (payeeentered != null) {
                payeeentered.Dispose ();
                payeeentered = null;
            }

            if (payeeswitcher != null) {
                payeeswitcher.Dispose ();
                payeeswitcher = null;
            }

            if (sendpayment != null) {
                sendpayment.Dispose ();
                sendpayment = null;
            }

            if (transdesc != null) {
                transdesc.Dispose ();
                transdesc = null;
            }
        }
    }
}