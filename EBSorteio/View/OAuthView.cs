﻿using System;

using Xamarin.Forms;

namespace EBSorteio.View
{
	public class OAuthView : ContentPage
	{
		private string ClientId
		{
			get { return "6BUXMMQE3KGIWAW3JW"; }
		}

		private string AuthorizeUrl
		{
			get { return "https://www.eventbrite.com/oauth/authorize"; }
		}

		private string CallbackUrl
		{
			get { return "https://www.eventbrite.com/ngapi/oauth/authorizing?"; }
		}

		public OAuthView ()
		{
			Title = "Autenticar";
			Content = new StackLayout {
				Children = { this.LoadWebView() }
			};
		}

		public WebView LoadWebView()
		{
			var webView = new WebView ();
			webView.HorizontalOptions = LayoutOptions.FillAndExpand;
			webView.VerticalOptions = LayoutOptions.FillAndExpand;
			webView.Source = string.Format("{0}?response_type=code&client_id={1}", AuthorizeUrl, ClientId);
			webView.Navigating += Navigating;

			return webView;
		}

		private void Navigating(object sender, WebNavigatingEventArgs args)
		{
			if (args.Url.StartsWith (CallbackUrl)) 
			{
				var stringParameters = args.Url.Substring(CallbackUrl.Length);
				var arrayParameters = stringParameters.Split('&');

				foreach (string parameter in arrayParameters) 
				{
					var splitParameter = parameter.Split (new char[] { '=' }, 2);
					var name = splitParameter [0];
					var value = splitParameter [1];

					if (name.Equals ("code")) {
						// solicitar token de acesso com o código
					}
				}
			}
		}
	}
}


