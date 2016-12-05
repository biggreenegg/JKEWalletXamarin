using System;
using Newtonsoft.Json;

namespace UnifiedSample
{
	public class AuthResponse
	{
		[JsonProperty("Auth")]
		public Auth Auth { get; set; }
	}
}

