using System.Collections.Generic;
using Newtonsoft.Json;

namespace KNKVPlugin.Model
{
	public class Teams
	{
		public Category Senioren { get; set; }
		public Category Junioren { get; set; }
		public Category Aspiranten { get; set; }
		public Category Pupillen { get; set; }
	}

	public class Category
	{
		[JsonProperty(PropertyName = "v")]
		public List<Team> Teams { get; set; }
	}


	public class Team
	{
		[JsonProperty(PropertyName = "season_year")]
		public int SeasonYear { get; set; }

		[JsonProperty(PropertyName = "season_serie")]
		public string SeasonSerie { get; set; }

		[JsonProperty(PropertyName = "club_id")]
		public string ClubCode { get; set; }

		[JsonProperty(PropertyName = "poule_id")]
		public int PouleId { get; set; }

		[JsonProperty(PropertyName = "sport_id")]
		public string SportId { get; set; }

		[JsonProperty(PropertyName = "c_team_name_basic")]
		public string TeamNameBasic { get; set; }

		[JsonProperty(PropertyName = "team_name")]
		public string TeamName { get; set; }

		[JsonProperty(PropertyName = "class_id")]
		public int ClassId { get; set; }

		[JsonProperty(PropertyName = "team_id")]
		public int TeamId { get; set; }

		[JsonProperty(PropertyName = "team_id_group")]
		public string TeamIdGroup { get; set; }
	}
}
