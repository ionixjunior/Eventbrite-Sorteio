using System;
using System.Threading.Tasks;
using EBSorteio.Rest;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using EBSorteio.View;
using System.Collections.Generic;
using Xamarin.Forms;
using EBSorteio.Exceptions;


namespace EBSorteio.ViewModel
{
	public class UserEventViewModel : BaseViewModel
	{
		private INavigation navigation;
        private EventsView view { get; set; }
		private Command<ItemTappedEventArgs> _itemTappedCommand;
		private EventRepository _eventRepository;

		private List<EventViewModel> _data;

		public List<EventViewModel> Data
		{
			get { return _data; }
			set 
			{
				if (value != _data)
				{
					_data = value;
					base.INotifyPropertyChanged ();
				}
			}
		}

		public const string ItemTappedCommandPropertyName = "ItemTappedCommand";
		public Command<ItemTappedEventArgs> ItemTappedCommand
		{
			get
			{
				return _itemTappedCommand ?? (_itemTappedCommand = new Command<ItemTappedEventArgs>(async (evento) => await ExecuteItemTapped(evento)));
			}
		}


		protected async Task ExecuteItemTapped(ItemTappedEventArgs evento)
		{
			
			//var attendeesPage = new AttendeesView(eventoItem.id);
			//await navigation.PushAsync(attendeesPage);
		}


		public UserEventViewModel ( EventsView view)
        {
            this.view = view;
			this.navigation = view.Navigation;
			this._eventRepository = new EventRepository (new EventBriteService());

			var listDataEvents = view.FindByName<ListView> ("listDataEvents");

			listDataEvents.ItemTapped += (object sender, ItemTappedEventArgs args) =>
			{
				var eventoItem = args.Item as EventViewModel;

				Device.BeginInvokeOnMainThread(async () =>  {
					
					await navigation.PushAsync ( new AttendeesView(), true);
					//await navigation();
					MessagingCenter.Send<string>(eventoItem.id, "EventItem");
				});

			};
        }

		public async Task Load()
		{

            view.ShowActivityIndicator ();

            try
            {
				var result = await _eventRepository.getAllEventsByServiceId("eventBrite");

                resetData();
				if (result == null)
                {
                    return;
                }

				Data = result;

                view.ShowData();
            }
			catch (OAuthException e) 
			{
				await view.DisplayAlert ("Atenção", e.Message, "Ok");
				await view.Navigation.PushModalAsync (new NavigationPage(new OAuthView()));
			}
            catch(Exception e)
            {
				await view.DisplayAlert ("Erro", e.Message, "Ok");
            }
		}

        public void resetData()
        {
			Data = new List<EventViewModel> ();
        }
	}
}

