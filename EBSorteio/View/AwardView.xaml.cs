using System;
using System.Collections.Generic;

using Xamarin.Forms;
using EBSorteio.ViewModel;

namespace EBSorteio.View
{
	public partial class AwardView : ContentPage
	{
		private AwardViewModel ViewModel { get; set; }

		public AwardView ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (ViewModel == null) 
			{
				ViewModel = new AwardViewModel ();
				BindingContext = ViewModel;
			}
		}

		public void CloseModal(object sender, EventArgs args)
		{
			Navigation.PopModalAsync ();
		}
	}
}

