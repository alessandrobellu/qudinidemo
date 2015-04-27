using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;

namespace QudiniDemo.Helpers
{
	public class HttpManager
	{
		private HttpClient httpClient;
		public HttpManager()
		{
			httpClient = new HttpClient();
		}

		public HttpManager(string userName, string password)
		{
			httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = CreateBasicHeader(userName, password);
		}

		public async Task<string> GetStringAsync(Uri uri)
		{
			var response = await httpClient.GetAsync(uri);

			if (response != null && response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsStringAsync();
			}
			else
			{
				Debug.WriteLine("Error! Status code: {0}", response.StatusCode);
				return String.Empty;
			}
		}

		public async Task<T> GetObjectAsync<T>(Uri uri)
		{
			try
			{
				var json = await GetStringAsync(uri);
				return JsonConvert.DeserializeObject<T>(json);
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Exception! {0}", ex.Message);
			}

			return default(T);
		}
		
		public HttpCredentialsHeaderValue CreateBasicHeader(string username, string password)
		{
			byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
			return new HttpCredentialsHeaderValue("Basic", Convert.ToBase64String(byteArray));
		}
	}
}
