using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KNKVPlugin.DataTypes
{
	public class Result
	{
		[JsonProperty(PropertyName = "program_id")]
		public string ProgramId { get; set; }

		[JsonProperty(PropertyName = "game_id")]
		public string GameId { get; set; }

		[JsonProperty(PropertyName = "year")]
		public string Year { get; set; }

		[JsonProperty(PropertyName = "home_team_name")]
		public string HomeTeamName { get; set; }

		[JsonProperty(PropertyName = "htc_id")]
		public string ClubCode { get; set; }

		[JsonProperty(PropertyName = "away_team_name")]
		public string AwayTeamName { get; set; }

		[JsonProperty(PropertyName = "home_score")]
		public string HomeScore { get; set; }

		[JsonProperty(PropertyName = "away_score")]
		public string AwayScore { get; set; }

		[JsonProperty(PropertyName = "date")]
		public string Date { get; set; }

		[JsonProperty(PropertyName = "time")]
		public string Time { get; set; }

		[JsonProperty(PropertyName = "match_officials")]
		public string MatchOfficials { get; set; }

		[JsonProperty(PropertyName = "poule_name")]
		public string PouleName { get; set; }

		[JsonProperty(PropertyName = "home_team_id")]
		public string HomeTeamId { get; set; }

		[JsonProperty(PropertyName = "away_team_id")]
		public string AwayTeamId { get; set; }
	}

	public class Week
	{
		[JsonProperty(PropertyName = "week_number")]
		public int WeekNumber { get; set; }

		[JsonProperty(PropertyName = "week_start")]
		public string WeekStart { get; set; }

		[JsonProperty(PropertyName = "week_end")]
		public string WeekEnd { get; set; }

		[JsonProperty(PropertyName = "items")]
		public List<Result> Results { get; set; }
	}


	public class Results
	{
		public List<Week> Weeks { get; set; }
	}
}
