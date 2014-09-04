using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KNKVPlugin.Model
{
	[JsonObject]
	public class Week : IEnumerable<Match>
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

		public IEnumerator<Match> GetEnumerator()
		{
			return Matches.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
