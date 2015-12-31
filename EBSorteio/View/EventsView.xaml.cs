using System;
using System.Collections.Generic;

using Xamarin.Forms;
using EBSorteio.ViewModel;
using EBSorteio.Common;

namespace EBSorteio.View
{
	public partial class EventsView : ContentPage
	{
		private UserEventViewModel ViewModel { get; set; }

		public EventsView ()
		{
			InitializeComponent ();
		}

		protected override async void OnAppearing ()
		{
			base.OnAppearing ();

			if( ViewModel == null)
			{
				ViewModel = new UserEventViewModel(this);
				BindingContext = ViewModel;
			}

			if (ViewModel.Data == null) 
			{
				await ViewModel.Load();
			}
		}

		public async void Logout(object sender, EventArgs args)
		{
			await SessionManager.Clean ();
			Xamarin.Forms.Application.Current.MainPage = new NavigationPage (
				new HomeView()
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

