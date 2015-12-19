using System;
using System.Collections.Generic;

using Xamarin.Forms;
using EBSorteio.ViewModel;

namespace EBSorteio.View
{
	public partial class AttendeesView : ContentPage
	{
		private AttendeesViewModel ViewModel { get; set; }

		public AttendeesView ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (ViewModel == null) 
			{
				ViewModel = new AttendeesViewModel ();
				BindingContext = ViewModel;
			}

			if (ViewModel.Data == null) 
			{
				ViewModel.Load ();
			}
		}

		public void OpenAward(object sender, EventArgs args)
		{
			Navigation.PushModalAsync (
				new NavigationPage(
					new AwardView(ViewModel.Data)
				)
			);
		}
	}
}

