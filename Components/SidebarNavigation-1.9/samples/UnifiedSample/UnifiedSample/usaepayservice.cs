using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Newtonsoft.Json;
using System.IO;
using RestSharp;
using UnifiedSample;
using System.Text.RegularExpressions;
using System.Text;

namespace Sample
{
	public static class usaepayservice
	{

		static string muser;
		static string mpass;
		static RestClient client = new RestClient("https://api.us.apiconnect.ibmcloud.com");
		private static Random random = new Random((int)DateTime.Now.Ticks);

		private static string RandomString(int Size)
		{
			string input = "abcdefghijklmnopqrstuvwxyz0123456789";

			StringBuilder builder = new StringBuilder();
			char ch;
			for (int i = 0; i < Size; i++)
			{
				ch = input[random.Next(0, input.Length)];
				builder.Append(ch);
			}
			return builder.ToString();
		}


		public static Auth auth(string mname, string mcard, string mexp, string amount, string desc, string code)
		{

			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			var request = new RestRequest("/balduinousibmcom-development/runSale", Method.POST);
			request.AddParameter("name", mname, ParameterType.QueryString); // adds to POST or URL querystring based on Method												 //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
			request.AddParameter("cardNumber", mcard, ParameterType.QueryString);
			request.AddParameter("cardExpiration", mexp, ParameterType.QueryString);
			request.AddParameter("cardCode", code, ParameterType.QueryString);
			request.AddParameter("transAmount", Convert.ToDecimal(mexp), ParameterType.QueryString);
			request.AddParameter("transDescription", desc, ParameterType.QueryString);
			request.AddParameter("transInvoice", RandomString(10), ParameterType.QueryString);
			//Console.WriteLine("name and card and exp is" + mname + ", " + mcard + ", " + mexp);
			Console.WriteLine("Values: \n" +
							 "name: " + mname + "\n" +
							 "cardNumber: " + mcard + "\n" +
							 "cardExpiration: " + mexp + "\n" +
							 "cardCode: " + code + "\n" +
							 "transAmount: " + Convert.ToDecimal(mexp) + "\n" +
							 "transDescription: " + desc + "\n" +
							 "transInvoice: " + RandomString(10) + "\n");

			request.AddHeader("x-ibm-client-id", "d95b7289-f8b2-43e9-a7c4-da48294b64f1");
			request.AddHeader("Content-type", "application/json");
			IRestResponse response = client.Execute(request);
			Console.WriteLine("Response from server: " + Regex.Unescape(response.Content));
			Auth content = JsonConvert.DeserializeObject<Auth>(Regex.Unescape(response.Content)); // raw content as string
			Console.WriteLine("Deserialized Object:" + content.RefNumber + "," + content.Result);
			return content;

		}



	}
}

