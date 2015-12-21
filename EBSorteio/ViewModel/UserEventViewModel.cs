using System;
using System.Threading.Tasks;
using EBSorteio.Rest;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using EBSorteio.View;
using System.Collections.Generic;
using Xamarin.Forms;


namespace EBSorteio.ViewModel
{
	public class UserEventViewModel : BaseViewModel
	{
		private INavigation navigation;
        private EventsView view { get; set; }
		private Command<ItemTappedEventArgs> _itemTappedCommand;
		private UserEventsResponse _data;

		public UserEventsResponse Data
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
			var attendeesPage = new AttendeesView();
			await navigation.PushAsync(attendeesPage);
		}


		public UserEventViewModel ( EventsView view)
        {
            this.view = view;
			this.navigation = view.Navigation;
			var listDataEvents = view.FindByName<ListView> ("listDataEvents");

			listDataEvents.ItemTapped += (object sender, ItemTappedEventArgs args) =>
			{
				Device.BeginInvokeOnMainThread(async () =>  {
					
					await navigation.PushAsync ( new AttendeesView());
				});

			};
        }

		public async Task Load()
		{

            view.ShowActivityIndicator ();

			var url = string.Concat (
				          "https://www.eventbriteapi.com/v3/users/me/events/?token=",
				          AuthInfo.Token
			          );
            try
            {
                HttpClient httpClient = new HttpClient ();
                HttpRequestMessage request = new HttpRequestMessage (HttpMethod.Get, url);
                request.Headers.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));

                HttpResponseMessage response = await httpClient.SendAsync (request);
                string result = await response.Content.ReadAsStringAsync ();

                UserEventsResponse resultItems = JsonConvert.DeserializeObject<UserEventsResponse>(result);

                resetData();
                if (resultItems == null)
                {
                    return;
                }

                Data = resultItems;

                view.ShowData();
            }
            catch(Exception e)
            {
                var err = e.ToString();
            }
		}

        public void resetData()
        {
            Data = new UserEventsResponse()
                {
                    Events = new List<Events>()
                };

        }
	}
}

