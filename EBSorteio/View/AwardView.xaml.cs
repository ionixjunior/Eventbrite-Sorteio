using System;
using System.Collections.Generic;

using Xamarin.Forms;
using EBSorteio.ViewModel;
using EBSorteio.Rest;

namespace EBSorteio.View
{
	public partial class AwardView : ContentPage
	{
		private AwardViewModel ViewModel { get; set; }

		private AttendeesResponse Attendees { get; set; }

		public AwardView (AttendeesResponse Attendees)
		{
			InitializeComponent ();

			this.Attendees = Attendees;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (ViewModel == null) 
			{
				ViewModel = new AwardViewModel (Attendees);
				BindingContext = ViewModel;
			}

			if (ViewModel.Data == null) 
			{
				ViewModel.Load ();
			}
		}

		public void CloseModal(object sender, EventArgs args)
		{
			Navigation.PopModalAsync ();
		}
	}
}

