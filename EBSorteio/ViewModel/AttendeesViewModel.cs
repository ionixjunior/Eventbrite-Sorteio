using System;
using System.Threading.Tasks;
using EBSorteio.Rest;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EBSorteio.ViewModel
{
	public class AttendeesViewModel : BaseViewModel
	{
		private AttendeesResponse _attendees;

		public AttendeesResponse Attendees
		{
			get { return _attendees; }
			set 
			{
				if (value != _attendees) 
				{
					_attendees = value;
					base.INotifyPropertyChanged ();
				}
			}
		}

		public async Task Load()
		{
			var url = string.Concat (
				"https://www.eventbriteapi.com/v3/events/20087371870/attendees/?token=", 
				AuthInfo.Token
			);

			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await httpClient.SendAsync(request);
			string result = await response.Content.ReadAsStringAsync();

			Attendees = JsonConvert.DeserializeObject<AttendeesResponse>(result);
		}
	}
}

