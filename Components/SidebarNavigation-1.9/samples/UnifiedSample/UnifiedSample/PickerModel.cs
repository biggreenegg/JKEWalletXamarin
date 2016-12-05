using System;
using System.Collections.Generic;
using UIKit;

namespace Sample
{
	public class PickerModel : UIPickerViewModel
	{
		private readonly IList<string> values;

		public event EventHandler<EventArgs> ValueChanged;

		int selectedIndex = 0;

		public PickerModel(IList<string> values)
		{
			this.values = values;
		}

		public override nint GetComponentCount (UIPickerView picker)
		{
			return 1;
		}

		public override nint GetRowsInComponent (UIPickerView picker, nint component)
		{
			return values.Count;
		}



		public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
		{
			var label = new UILabel();

			label.Text = values[(int)row].ToString();
			label.BackgroundColor = UIColor.Clear;
			label.TextAlignment = UITextAlignment.Right;
			label.Font = UIFont.FromName("Helvetica", 12);
			label.TextColor = UIColor.Black;

			return label;
		}

		public override string GetTitle(UIPickerView picker, nint row, nint component)
		{
			return values[(int)row];
		}


		public override void Selected (UIPickerView picker, nint row, nint component)
		{
			selectedIndex = (int)row;
			if (ValueChanged != null)
			{
				ValueChanged(this, new EventArgs());
			}
		}
	}
}

