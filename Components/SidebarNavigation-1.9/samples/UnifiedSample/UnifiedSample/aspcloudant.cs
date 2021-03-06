﻿using System;
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
	public static class aspcloudant
	{

		static string muser;
		static string mpass;
		static RestClient client = new RestClient("https://bluemixdotnetinterconnect.mybluemix.net");


		public static LoginResponse login(string muserid, string mpassword)
		{
			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/login", Method.POST);
			Console.WriteLine("userid and password is" + muserid + ", " + mpassword);
			request.AddParameter("username", muserid); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("password", mpassword);
			IRestResponse response = client.Execute(request);
			LoginResponse content = JsonConvert.DeserializeObject<LoginResponse>(Regex.Unescape(response.Content)); // raw content as string
			Console.WriteLine("The response from server was: " + content.status);
			return content;
		}

		public static AccountsResponse getaccounts()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/accounts", Method.POST);
			request.AddParameter("username", Globals.loggedinusername); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("password", Globals.password);
			IRestResponse response = client.Execute(request);
			AccountsResponse content = JsonConvert.DeserializeObject<AccountsResponse>(response.Content); // raw content as string
			Console.WriteLine("The total accounts from server was: " + content.totalaccounts);
			return content;

		}


		public static AccountsResponse getaccounttypes()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/accounttypes", Method.POST);
			request.AddParameter("username", Globals.loggedinusername); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("password", Globals.password);
			IRestResponse response = client.Execute(request);
			AccountsResponse content = JsonConvert.DeserializeObject<AccountsResponse>(response.Content); // raw content as string
			Console.WriteLine("The total account types from server was: " + content.totalaccounts);
			return content;

		}


		public static ChecksResponse getpayees()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/payees", Method.POST);
			request.AddParameter("username", Globals.loggedinusername); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("password", Globals.password);
			IRestResponse response = client.Execute(request);
			Console.WriteLine("The payees response was: " + response.Content);
			ChecksResponse content = JsonConvert.DeserializeObject<ChecksResponse>(response.Content); // raw content as string
			Console.WriteLine("The total payees from server was: " + content.totalchecks);
			return content;

		}


		public static CloudantCreateResponse savecheck(Check thisCheck)
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/savecheck", Method.POST);
			Console.WriteLine("payee and desc is" + thisCheck.payee + ", " + thisCheck.desc);
			//request.AddParameter("payee", thisCheck.payee); // adds to POST or URL querystring based on Method
													 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			//request.AddParameter("amount", thisCheck.amount);
			//request.AddParameter("name", thisCheck.name);
			//request.AddParameter("desc", thisCheck.desc);
			//request.AddParameter("date", thisCheck.date);
			//request.AddParameter("username", Globals.loggedinusername, ParameterType.QueryString);
			//request.AddParameter("password", Globals.password, ParameterType.QueryString);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(new { username = Globals.loggedinusername, password = Globals.password, check = thisCheck });
			//request.AddHeader("Content-type", "application/json");

			IRestResponse response = client.Execute(request);
			CloudantCreateResponse content = JsonConvert.DeserializeObject<CloudantCreateResponse>(response.Content); // raw content as string
			Console.WriteLine("The response from server was: " + content);
			return content;
		}

		public static ChecksResponse getchecks()
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/checks", Method.POST);
			request.AddParameter("username", Globals.loggedinusername); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("password", Globals.password);
			IRestResponse response = client.Execute(request);
			ChecksResponse docs = JsonConvert.DeserializeObject<ChecksResponse>(response.Content); // raw content as string
			Console.WriteLine("The total checks from server was: " + docs.totalchecks);
			return docs;
		}


	}
}

