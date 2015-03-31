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

		[JsonProperty(PropertyName = "Senioren Dames")]
		public readonly Category SeniorenDames;

		[JsonProperty(PropertyName = "Junioren")]
		public readonly Category Junioren;

		[JsonProperty(PropertyName = "Junioren Dames")]
		public readonly Category JuniorenDames;

		[JsonProperty(PropertyName = "Aspiranten")]
		public readonly Category Aspiranten;

		[JsonProperty(PropertyName = "Aspiranten Dames")]
		public readonly Category AspirantenDames;

		[JsonProperty(PropertyName = "Pupillen")]
		public readonly Category Pupillen;

		[JsonProperty(PropertyName = "Pupillen Dames")]
		public readonly Category PupillenDames;

		[JsonProperty(PropertyName = "Welpen")]
		public readonly Category Welpen;

		[JsonProperty(PropertyName = "Welpen Dames")]
		public readonly Category WelpenDames;

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
			if (Senioren != null)
				List.AddRange(Senioren.Teams);

			if (SeniorenDames != null)
				List.AddRange(SeniorenDames.Teams);

			if (Junioren != null)
				List.AddRange(Junioren.Teams);

			if (JuniorenDames != null)
				List.AddRange(JuniorenDames.Teams);

			if (Aspiranten != null)
			List.AddRange(Aspiranten.Teams);

			if (AspirantenDames != null)
				List.AddRange(AspirantenDames.Teams);

			if (Pupillen != null)
				List.AddRange(Pupillen.Teams);

			if (PupillenDames != null)
				List.AddRange(PupillenDames.Teams);

			if (Welpen != null)
				List.AddRange(Welpen.Teams);

			if (WelpenDames != null)
				List.AddRange(WelpenDames.Teams);

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
		public class Poule
		{
			[JsonProperty(PropertyName = "id")]
			public readonly int Id;

			[JsonProperty(PropertyName = "name")]
			public readonly string Name;

			[JsonProperty(PropertyName = "sport")]
			public readonly Sport Sport;
		}

		[JsonProperty(PropertyName = "season_year")]
		public readonly int SeasonYear;

		[JsonProperty(PropertyName = "season_serie")]
		public readonly string SeasonSerie;

		[JsonProperty(PropertyName = "club_id")]
		public readonly string ClubCode;

		[JsonProperty(PropertyName = "poule_id")]
		public readonly int PouleId;

		[JsonProperty(PropertyName = "poules")]
		public readonly List<Poule> Poules;

		[JsonProperty(PropertyName = "sport_id")]
		public readonly Sport Sport;

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
