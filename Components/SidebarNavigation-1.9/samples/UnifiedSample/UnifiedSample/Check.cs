using System;
namespace UnifiedSample
{
	public class Check
	{
		public string amount { get; set; }
		public string account { get; set; }
		public string desc { get; set; }
		public string payee { get; set; }
		public int date { get; set; }
		public string username { get; set; }

		public static DateTime FromUnixTime(long unixTime)
		{
			DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddSeconds(unixTime);
		}



	}
}

