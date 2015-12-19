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
					ViewModel = new UserEventViewModel();
					BindingContext = ViewModel;
			}

			if (ViewModel.Data == null) 
			{
				ViewModel.Load();
			}
		}
	}
}

