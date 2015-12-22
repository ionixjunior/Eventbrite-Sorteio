using System;
using System.Threading.Tasks;
using EBSorteio.Rest;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using EBSorteio.View;
using System.Linq;
using Xamarin.Forms;

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
			MessagingCenter.Subscribe<Events>(this, "EventItem", async (sender) => await Load(sender));

		}

		public async Task Load(Events eventItem)
		{
			if (eventItem == null)
				view.SendBackButtonPressed ();
			
			view.ShowActivityIndicator ();

			var url = string.Concat (
				"https://www.eventbriteapi.com/v3/events/",eventItem.id,"/attendees/?token=", 
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

				view.ShowData();
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

