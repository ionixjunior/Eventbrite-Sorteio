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

		/**
		 * Workaround para bug https://bugzilla.xamarin.com/show_bug.cgi?id=33954
		 */
		public void CallOnAppearing()
		{
			this.OnAppearing ();
		}

		public async void LoginEventbrite(object sender, EventArgs args)
		{
			await Navigation.PushModalAsync (
				new NavigationPage(
					new OAuthView(this)
				)
			);
		}
	}
}

