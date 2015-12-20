using System;
using System.Threading.Tasks;
using EBSorteio.Rest;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using EBSorteio.View;
using System.Collections.Generic;

namespace EBSorteio.ViewModel
{
	public class UserEventViewModel : BaseViewModel
	{

        private EventsView view { get; set; }

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

        public UserEventViewModel ( EventsView view )
        {
            this.view = view;
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

