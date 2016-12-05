using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Newtonsoft.Json;
using System.IO;
using RestSharp;
using UnifiedSample;

namespace Sample
{
	public static class docdb
	{

		static string muser;
		static string mpass;
		static RestClient client = new RestClient("http://jkehybridapp.azurewebsites.net");


		public static LoginResponse login(string muserid, string mpassword)
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/login", Method.POST);
			Console.WriteLine("userid and password is" + muserid + ", " + mpassword);
			request.AddParameter("username", muserid); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("password", mpassword);
			IRestResponse response = client.Execute(request);
			LoginResponse content = JsonConvert.DeserializeObject<LoginResponse>(response.Content); // raw content as string
			Console.WriteLine("The response from server was: " + content.status);

			return content;

		}

		public static Account[] getaccounts()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/getaccounts", Method.GET);
			IRestResponse response = client.Execute(request);
			Account[] content = JsonConvert.DeserializeObject<Account[]>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.Length);
			return content;

		}


		public static Account[] getaccounttypes()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/getaccounttypes", Method.GET);
			IRestResponse response = client.Execute(request);
			Account[] content = JsonConvert.DeserializeObject<Account[]>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.Length);
			return content;

		}


		public static String[] getpayees()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/getpayees", Method.GET);
			IRestResponse response = client.Execute(request);
			String[] content = JsonConvert.DeserializeObject<String[]>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.Length);
			return content;

		}


		public static Boolean savecheck(Check thisCheck)
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/savecheck", Method.POST);
			Console.WriteLine("payee and desc is" + thisCheck.payee + ", " + thisCheck.desc);
			request.AddParameter("payee", thisCheck.payee); // adds to POST or URL querystring based on Method
													 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("amount", thisCheck.amount);
			request.AddParameter("account", thisCheck.account);
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
			var request = new RestRequest("/getchecks", Method.GET);
			IRestResponse response = client.Execute(request);
			Check[] content = JsonConvert.DeserializeObject<Check[]>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.Length);
			return content;
		}

		/*
			switch (req)
			{
				case "calendar":
					request = new RestRequest("/calendar", Method.POST);
					Console.WriteLine("userid and password is" + muserid + ", " + mpassword);
					request.AddParameter("userid", muserid); // adds to POST or URL querystring based on Method
					//request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
					request.AddParameter("password", mpassword);
					break;
					
				case "balances":
					request = new RestRequest("/balances", Method.POST);
					Console.WriteLine("getting balances" + muserid + ", " + mpassword);
					//request.AddParameter("userid", muserid); // adds to POST or URL querystring based on Method
					//request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
					//request.AddParameter("password", mpassword);
					break;
				case "savecheck":
					request = new RestRequest("/savecheck", Method.POST);
					Console.WriteLine("saving check" + muserid + ", " + mpassword);
				//request.AddParameter("userid", muserid); // adds to POST or URL querystring based on Method
				//request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
				//request.AddParameter("password", mpassword);



				default:
			}

			
			// easily add HTTP Headers
			request.AddHeader("header", "value");

			// add files to upload (works with compatible verbs)
			request.AddFile(path);


			

			// execute the request
			IRestResponse response = client.Execute(request);
			var content = response.Content; // raw content as string
			Console.WriteLine("The response from server was: " + content);
			/*
			// or automatically deserialize result
			// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
			RestResponse<Person> response2 = client.Execute<Person>(request);
			var name = response2.Data.Name;

			// easy async support
			client.ExecuteAsync(request, response =>
			{
				Console.WriteLine(response.Content);
			});


			// async with deserialization
			var asyncHandle = client.ExecuteAsync<Person>(request, response =>
			{
				Console.WriteLine(response.Data.Name);
			});

			// abort the request on demand
			asyncHandle.Abort();
			
			return true;

		}
	*/

	}
}

