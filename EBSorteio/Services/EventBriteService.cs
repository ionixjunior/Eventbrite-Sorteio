using System;
using System.Net.Http;
using EBSorteio.Rest;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace EBSorteio
{
	public class EventBriteService
	{
		
		public EventBriteService (){ }

		public async Task<List<Events>> getAllEvents()
		{
			var url = string.Concat ("https://www.eventbriteapi.com/v3/users/me/events/?token=", AuthInfo.Token);
			try
			{
				HttpClient httpClient = new HttpClient ();
				HttpRequestMessage request = new HttpRequestMessage (HttpMethod.Get, url);
				request.Headers.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));

				HttpResponseMessage response = await httpClient.SendAsync (request);
				string result = await response.Content.ReadAsStringAsync ();

				UserEventsResponse resultItems = JsonConvert.DeserializeObject<UserEventsResponse>(result);

				return resultItems.Events;
			}
			catch(Exception e)
			{
				var err = e.ToString();
				return null;
			}
		}
		public async Task<AttendeesResponse> getAllCheckedAttendeesByEventId(string eventId)
		{
			var url = string.Concat (
				"https://www.eventbriteapi.com/v3/events/",eventId,"/attendees/?token=", 
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


				resultItems.Attendees = resultItems.Attendees.Where(x => x.Checked_in == true).ToList();
				resultItems.Attendees = resultItems.Attendees.GroupBy(x => x.Profile.Email).Select(y => y.FirstOrDefault()).ToList();

				return resultItems;
			}
			catch(Exception e)
			{
				var err = e.ToString ();
			}
			return null;
		}

	}
}

