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

		public async Task Load()
		{
			var url = string.Concat (
				"https://www.eventbriteapi.com/v3/events/19841692035/attendees/?token=", 
				AuthInfo.Token
			);

			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await httpClient.SendAsync(request);
			string result = await response.Content.ReadAsStringAsync();

			Data = JsonConvert.DeserializeObject<AttendeesResponse>(result);
		}
	}
}

