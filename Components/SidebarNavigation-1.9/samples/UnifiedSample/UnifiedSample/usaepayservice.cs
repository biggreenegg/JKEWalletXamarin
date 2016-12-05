using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Newtonsoft.Json;
using System.IO;
using RestSharp;
using UnifiedSample;
using System.Text.RegularExpressions;


namespace Sample
{
	public static class usaepayservice
	{

		static string muser;
		static string mpass;
		static RestClient client = new RestClient("https://jkecpo.azure-api.net/usaepay");


		public static AuthResponse auth(string mname, string mcard, string mexp)
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/verifycard", Method.GET);
			Console.WriteLine("name and card and exp is" + mname + ", " + mcard + ", " + mexp);
			request.AddParameter("name", mname); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("ccnum", mcard);
			request.AddParameter("exp", mexp);
			request.AddHeader("Ocp-Apim-Subscription-Key", "d388a00045394488b7396e1aefc71d63");
			request.AddHeader("Ocp-Apim-Trace", "true");

			IRestResponse response = client.Execute(request);
			Console.WriteLine("Response from server: " + Regex.Unescape(response.Content));
			AuthResponse myresponse = new AuthResponse();
			Auth myauth = new Auth();
			myauth.AuthCode = "2323";
			myauth.Result = "Approved";
			myresponse.Auth = myauth;
			Console.WriteLine("Serialized Object: " + JsonConvert.SerializeObject(myresponse));
			var user = JsonConvert.DeserializeObject<AuthResponse>(response.Content);
			Auth content = JsonConvert.DeserializeObject<Auth>(Regex.Unescape(response.Content)); // raw content as string
			Console.WriteLine("Deserialized Object:" + user.Auth.Result + "," + user.Auth.AuthCode);
			return user;

		}



	}
}

