using System;
using System.Threading.Tasks;
using EBSorteio.Rest;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using EBSorteio.View;
using System.Linq;

namespace EBSorteio.ViewModel
{
	public class AttendeesViewModel : BaseViewModel
	{
		private AttendeesView view { get; set; }

		private AttendeesResponse _data;

		public AttendeesResponse Data
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

		public AttendeesViewModel(AttendeesView view)
		{
			this.view = view;
		}

		public async Task Load()
		{
			view.ShowActivityIndicator ();

			var url = string.Concat (
				"https://www.eventbriteapi.com/v3/events/19841692035/attendees/?token=", 
				AuthInfo.Token
			);
			try
			{				
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await httpClient.SendAsync(request);
				string result = await response.Content.ReadAsStringAsync();

				AttendeesResponse resultItems = JsonConvert.DeserializeObject<AttendeesResponse>(result);

				resetData();
				if(resultItems == null)
				{					
					return;
				}
				resultItems.Attendees = resultItems.Attendees.Where(x => x.Checked_in == true).ToList();
				resultItems.Attendees = resultItems.Attendees.GroupBy(x => x.Profile.Email).Select(y => y.FirstOrDefault()).ToList();

				Data = resultItems;
			}
			catch(Exception e)
			{
				var err = e.ToString ();
			}
		}
		public void resetData()
		{
			Data = new AttendeesResponse()
			{
				Attendees = new List<Attendee>()
			};

		}
	}
}

