using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EBSorteio.View
{
	public partial class AwardView : ContentPage
	{
		public AwardView ()
		{
			InitializeComponent ();
		}

		public void CloseModal(object sender, EventArgs args)
		{
			Navigation.PopModalAsync ();
		}
	}
}

