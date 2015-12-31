﻿using System;

using Xamarin.Forms;
using EBSorteio.Common;
using System.Threading.Tasks;
using EBSorteio.ViewModel;

namespace EBSorteio.View
{
	public class OAuthView : ContentPage
	{
		private OAuthViewModel viewModel { get; set; }

		private string ClientId
		{
			get { return "6BUXMMQE3KGIWAW3JW"; }
		}

		private string AuthorizeUrl
		{
			get { return "https://www.eventbrite.com/oauth/authorize"; }
		}

		private string TokenUrl
		{
			get { return "https://www.eventbrite.com/oauth/token"; }
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

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (viewModel == null) 
			{
				viewModel = new OAuthViewModel ();
			}
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

		private async void Navigating(object sender, WebNavigatingEventArgs args)
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
						await SessionManager.SetAsync (SessionName.OAuthCode, value);
						await viewModel.LoadToken ();
					}
				}
			}
		}
	}
}


