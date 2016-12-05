using System;
using Newtonsoft.Json;

namespace UnifiedSample
{
	public class Auth
	{
		[JsonProperty("AuthCode")]
		public string AuthCode { get; set; }

		[JsonProperty("Result")]
		public string Result {get;set;}

	}
}

