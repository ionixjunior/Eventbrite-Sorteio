using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace EBSorteio.Common
{
	public class SessionManager
	{
		public static object Get(string key)
		{
			if (Contains (key).Equals (false)) 
			{
				return null;
			}

			return Application.Current.Properties [key];
		}

		public static async Task SetAsync(string key, object value)
		{
			Application.Current.Properties [key] = value;
			await Application.Current.SavePropertiesAsync ();
		}

		public static async Task Clean()
		{
			Application.Current.Properties.Clear ();
			await Application.Current.SavePropertiesAsync ();
		}

		private static bool Contains(string key)
		{
			if (Application.Current.Properties.ContainsKey (key)) 
			{
				return true;
			}

			return false;
		}
	}
}

