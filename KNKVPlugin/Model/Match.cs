using Newtonsoft.Json;

namespace KNKVPlugin.Model
{
	public class Match
	{
		[JsonProperty(PropertyName = "program_id")]
		public readonly string ProgramId;

		[JsonProperty(PropertyName = "game_id")]
		public readonly string GameId;

		[JsonProperty(PropertyName = "year")]
		public readonly string Year;

		[JsonProperty(PropertyName = "home_team_name")]
		public readonly string TeamName;

		[JsonProperty(PropertyName = "htc_id")]
		public readonly string ClubCode;

		[JsonProperty(PropertyName = "away_team_name")]
		public readonly string TeamNameGuests;

		[JsonProperty(PropertyName = "atc_id")]
		public readonly string ClubCodeGuests;

		[JsonProperty(PropertyName = "date")]
		public readonly string Date;

		[JsonProperty(PropertyName = "time")]
		public readonly string Time;

		[JsonProperty(PropertyName = "match_officials")]
		public readonly string MatchOfficials;

		[JsonProperty(PropertyName = "poule_id")]
		public readonly string PouleId;

		[JsonProperty(PropertyName = "poule_name")]
		public readonly string PouleName;

		[JsonProperty(PropertyName = "home_team_id")]
		public readonly string HomeTeamId;

		[JsonProperty(PropertyName = "away_team_id")]
		public readonly string AwayTeamId;

		[JsonProperty(PropertyName = "class_name")]
		public readonly string ClassName;

		[JsonProperty(PropertyName = "field")]
		public readonly string Field;

		[JsonProperty(PropertyName = "facility")]
		public Facility Facility { get; set; }

		[JsonProperty(PropertyName = "home_score")]
		public readonly string Score;

		[JsonProperty(PropertyName = "away_score")]
		public readonly string ScoreGuests;
	}
}
