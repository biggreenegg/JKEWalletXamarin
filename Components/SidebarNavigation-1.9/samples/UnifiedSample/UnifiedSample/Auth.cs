using System;
using Newtonsoft.Json;

namespace UnifiedSample
{
	public class Auth
	{
		[JsonProperty("RefNumber")]
		public string RefNumber { get; set; }

		[JsonProperty("Result")]
		public string Result {get;set;}

	}
}

