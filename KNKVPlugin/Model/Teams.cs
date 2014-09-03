using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace KNKVPlugin.Model
{
	[JsonObject]
	public class Teams : IEnumerable<Team>
	{
		[JsonProperty(PropertyName = "Senioren")]
		public readonly Category Senioren;

		[JsonProperty(PropertyName = "Junioren")]
		public readonly Category Junioren;

		[JsonProperty(PropertyName = "Aspiranten")]
		public readonly Category Aspiranten;

		[JsonProperty(PropertyName = "Pupillen")]
		public readonly Category Pupillen;

		public IEnumerator<Team> GetEnumerator()
		{
			return List.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public string ClubCode { get; private set; }
		public List<Team> List = new List<Team>();
		
		[OnDeserialized]
		void CreateList(StreamingContext sc)
		{
			List.AddRange(Senioren.Teams);
			List.AddRange(Junioren.Teams);
			List.AddRange(Aspiranten.Teams);
			List.AddRange(Pupillen.Teams);

			var firstTeamElement = List.FirstOrDefault();
			if (firstTeamElement != null)
				ClubCode = firstTeamElement.ClubCode;
		}
	}

	public class Category
	{
		[JsonProperty(PropertyName = "v")]
		public readonly List<Team> Teams;
	}


	public class Team
	{
		[JsonProperty(PropertyName = "season_year")]
		public readonly int SeasonYear;

		[JsonProperty(PropertyName = "season_serie")]
		public readonly string SeasonSerie;

		[JsonProperty(PropertyName = "club_id")]
		public readonly string ClubCode;

		[JsonProperty(PropertyName = "poule_id")]
		public readonly int PouleId;

		[JsonProperty(PropertyName = "sport_id")]
		public readonly string SportId;

		[JsonProperty(PropertyName = "c_team_name_basic")]
		public readonly string TeamNameBasic;

		[JsonProperty(PropertyName = "team_name")]
		public readonly string TeamName;

		[JsonProperty(PropertyName = "class_id")]
		public readonly int ClassId;

		[JsonProperty(PropertyName = "team_id")]
		public readonly int TeamId;

		[JsonProperty(PropertyName = "team_id_group")]
		public readonly string TeamIdGroup;
	}
}
