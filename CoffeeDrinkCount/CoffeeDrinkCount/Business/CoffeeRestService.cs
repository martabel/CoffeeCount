using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CoffeeDrinkCount.Data;

namespace CoffeeDrinkCount.Business
{
    public class CoffeeRestService : ICoffeeRestService
    {
        HttpClient client;

        public CoffeeRestService()
        {
			var authData = string.Format("{0}:{1}", "user", "password");

			var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task SaveCoffeeListAsync(CoffeeList list)
        {
			var uri = new Uri(string.Format("", ""));

			try
			{
				var json = JsonConvert.SerializeObject(list);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;

				response = await client.PostAsync(uri, content);

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"Coffee List successfully saved.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
			}
        }
    }
}
