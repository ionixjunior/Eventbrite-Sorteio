using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using EBSorteio.Common;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EBSorteio.Rest;

namespace EBSorteio.ViewModel
{
	public class OAuthViewModel : BaseViewModel
	{
		public OAuthViewModel ()
		{
		}

		public async Task LoadToken()
		{
			var url = "https://www.eventbrite.com/oauth/token";
			var requestContent = string.Format (
				"code={0}&client_secret={1}&client_id={2}&grant_type=authorization_code", 
				SessionManager.Get(SessionName.OAuthCode), 
				"6KQBFLJYYBBKPOAWW6YZYCIYOSFARK6YOJKBNG62ETAGT4VFM3", 
				"6BUXMMQE3KGIWAW3JW"
			);

			try
			{
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				request.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");

				HttpResponseMessage response = await httpClient.SendAsync(request);
				string result = await response.Content.ReadAsStringAsync();
				var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);
				await SessionManager.SetAsync(SessionName.OAuthToken, tokenResponse.Token);
			}
			catch(Exception e)
			{
				var err = e.ToString ();
			}
		}
	}
}

