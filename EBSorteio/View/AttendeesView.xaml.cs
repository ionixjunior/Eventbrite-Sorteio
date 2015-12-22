using System;
using System.Collections.Generic;

using Xamarin.Forms;
using EBSorteio.ViewModel;

namespace EBSorteio.View
{
	public partial class AttendeesView : ContentPage
	{
		private AttendeesViewModel ViewModel { get; set; }
		private string _eventId { get; set; } 

		public AttendeesView ()
		{
			InitializeComponent ();
			//this._eventId = eventId;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (ViewModel == null) 
			{
				ViewModel = new AttendeesViewModel (this);
				BindingContext = ViewModel;
			}

			if (ViewModel.Data == null) 
			{
				//ViewModel.Load ();
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

		public void ShowData()
		{
			StackLayout stackLayoutActivityIndicator = this.FindByName<StackLayout> ("stackLayoutActivityIndicator");
			StackLayout stackLayoutData = this.FindByName<StackLayout> ("stackLayoutData");

			stackLayoutActivityIndicator.IsVisible = false;
			stackLayoutData.IsVisible = true;
		}

		public void ShowActivityIndicator()
		{
			StackLayout stackLayoutActivityIndicator = this.FindByName<StackLayout> ("stackLayoutActivityIndicator");
			StackLayout stackLayoutData = this.FindByName<StackLayout> ("stackLayoutData");

			stackLayoutActivityIndicator.IsVisible = true;
			stackLayoutData.IsVisible = false;
		}
	}
}

