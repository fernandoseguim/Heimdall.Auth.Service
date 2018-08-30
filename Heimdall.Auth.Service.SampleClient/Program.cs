using IdentityModel.Client;
using IdentityServer4.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Heimdall.Auth.Service.SampleClient
{
	class Program
	{
		public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

		private static async Task MainAsync()
		{

			var secret = new Secret("ScroogeSecretKey".Sha256());
			
			var disco = await DiscoveryClient.GetAsync("http://localhost:21023");
			if (disco.IsError)
			{
				Console.WriteLine(disco.Error);
				return;
			}

			// request token
			var tokenClient = new TokenClient(disco.TokenEndpoint, "Heimdall.TIN", "HeimdallTINSecretKey");
			var tokenResponse = await tokenClient.RequestClientCredentialsAsync("Platform.MovieApi");

			if (tokenResponse.IsError)
			{
				Console.WriteLine(tokenResponse.Error);
				Console.ReadKey();
				return;
			}

			Console.WriteLine(tokenResponse.Json);
			Console.WriteLine("\n\n");

			// call api
			var client = new HttpClient();
			client.SetBearerToken(tokenResponse.AccessToken);

			var response = await client.GetAsync("http://localhost:21025/api/movies");
			if (!response.IsSuccessStatusCode)
			{
				Console.WriteLine(response.StatusCode);
			}
			else
			{
				var content = await response.Content.ReadAsStringAsync();
				Console.WriteLine(JArray.Parse(content));
			}
			Console.ReadKey();
		}
	}
}
