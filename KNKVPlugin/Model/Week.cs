using System.Collections.Generic;
using Newtonsoft.Json;

namespace KNKVPlugin.Model
{
	public class Week
	{
		[JsonProperty(PropertyName = "week_number")]
		public int WeekNumber { get; set; }

		[JsonProperty(PropertyName = "week_start")]
		public string WeekStart { get; set; }

		[JsonProperty(PropertyName = "week_end")]
		public string WeekEnd { get; set; }

		[JsonProperty(PropertyName = "items")]
		public List<Match> Matches { get; set; }

		[JsonProperty(PropertyName = "c")]
		public string ClubCode { get; set; }
	}
}
