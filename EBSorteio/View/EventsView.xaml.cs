using System;
using System.Collections.Generic;

using Xamarin.Forms;
using EBSorteio.ViewModel;

namespace EBSorteio.View
{
	public partial class EventsView : ContentPage
	{
		private UserEventViewModel ViewModel { get; set; }

		public EventsView ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if( ViewModel == null)
			{
                ViewModel = new UserEventViewModel(this);
				BindingContext = ViewModel;
			}

			if (ViewModel.Data == null) 
			{
				ViewModel.Load();
			}
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

