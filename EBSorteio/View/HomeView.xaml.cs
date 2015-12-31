using System;
using System.Collections.Generic;

using Xamarin.Forms;
using EBSorteio.Common;

namespace EBSorteio.View
{
	public partial class HomeView : ContentPage
	{
		public HomeView ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (SessionManager.Get (SessionName.OAuthToken) != null) 
			{
				Xamarin.Forms.Application.Current.MainPage = new NavigationPage (
					new EventsView()
				);
			}
		}

		public async void LoginEventbrite(object sender, EventArgs args)
		{
			await Navigation.PushModalAsync (
				new NavigationPage(
					new OAuthView()
				)
			);
		}
	}
}

