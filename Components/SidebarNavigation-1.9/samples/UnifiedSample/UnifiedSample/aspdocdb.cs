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
	public static class aspdocdb
	{

		static string muser;
		static string mpass;
		static RestClient client = new RestClient("http://docdb0953.azurewebsites.net");


		public static LoginResponse login(string muserid, string mpassword)
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/values/login", Method.POST);
			Console.WriteLine("userid and password is" + muserid + ", " + mpassword);
			request.AddParameter("username", muserid); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("password", mpassword);
			IRestResponse response = client.Execute(request);
			LoginResponse content = JsonConvert.DeserializeObject<LoginResponse>(Regex.Unescape(response.Content)); // raw content as string
			Console.WriteLine("The response from server was: " + content.status);
			return content;

		}

		public static Account[] getaccounts()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/values/accounts", Method.POST);
			IRestResponse response = client.Execute(request);
			Account[] content = JsonConvert.DeserializeObject<Account[]>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.Length);
			return content;

		}


		public static Account[] getaccounttypes()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/values/accounttypes", Method.POST);
			IRestResponse response = client.Execute(request);
			Account[] content = JsonConvert.DeserializeObject<Account[]>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.Length);
			return content;

		}


		public static Check[] getpayees()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/values/payees", Method.POST);
			IRestResponse response = client.Execute(request);
			Check[] content = JsonConvert.DeserializeObject<Check[]>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.Length);
			return content;

		}


		public static Boolean savecheck(Check thisCheck)
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/values/savecheck", Method.POST);
			Console.WriteLine("payee and desc is" + thisCheck.payee + ", " + thisCheck.desc);
			request.AddParameter("payee", thisCheck.payee); // adds to POST or URL querystring based on Method
													 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("amount", thisCheck.amount);
			request.AddParameter("account", thisCheck.name);
			request.AddParameter("desc", thisCheck.desc);
			request.AddParameter("date", thisCheck.date);
			request.AddParameter("username", thisCheck.username);

			IRestResponse response = client.Execute(request);
			var content = response.Content; // raw content as string
			Console.WriteLine("The response from server was: " + content);
			return true;
		}

		public static Check[] getchecks()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/values/checks", Method.POST);
			IRestResponse response = client.Execute(request);
			Check[] content = JsonConvert.DeserializeObject<Check[]>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.Length);
			return content;
		}


	}
}

