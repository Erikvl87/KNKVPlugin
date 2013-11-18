using Newtonsoft.Json;

namespace KNKVPlugin.DataTypes
{
	public class Match
	{
		[JsonProperty(PropertyName = "program_id")]
		public string ProgramId { get; set; }

		[JsonProperty(PropertyName = "game_id")]
		public string GameId { get; set; }

		[JsonProperty(PropertyName = "year")]
		public string Year { get; set; }

		[JsonProperty(PropertyName = "home_team_name")]
		public string TeamName { get; set; }

		[JsonProperty(PropertyName = "htc_id")]
		public string ClubCode { get; set; }

		[JsonProperty(PropertyName = "away_team_name")]
		public string TeamNameGuests { get; set; }

		[JsonProperty(PropertyName = "atc_id")]
		public string ClubCodeGuests { get; set; }

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

		[JsonProperty(PropertyName = "class_name")]
		public string ClassName { get; set; }

		[JsonProperty(PropertyName = "field")]
		public string Field { get; set; }

		[JsonProperty(PropertyName = "facility_name ")]
		public string FacilityName { get; set; }

		[JsonProperty(PropertyName = "facility_id ")]
		public string FacilityId { get; set; }

		[JsonProperty(PropertyName = "home_score")]
		public string Score { get; set; }

		[JsonProperty(PropertyName = "away_score")]
		public string ScoreGuests { get; set; }
	}
}
