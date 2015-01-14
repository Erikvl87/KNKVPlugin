using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KNKVPlugin.Model
{
	[JsonObject]
	public class Poule : IEnumerable<Position>
	{
		private class PouleData
		{
			[JsonProperty(PropertyName = "poule_id")]
			public readonly string PouleId;

			[JsonProperty(PropertyName = "poule_name")]
			public readonly string PouleName;

			[JsonProperty(PropertyName = "sport")]
			public readonly Sport Sport;
		}


		[JsonProperty(PropertyName = "poule")]
		private PouleData PouleInfo
		{
			set
			{
				PouleId = value.PouleId;
				PouleName = value.PouleName;
				Sport = value.Sport;
			}
		}

		[JsonProperty(PropertyName = "lines")]
		public readonly List<Position> Positions;

		public IEnumerator<Position> GetEnumerator()
		{
			return Positions.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public string PouleId { get; private set; }
		public string PouleName { get; private set; }
		public Sport Sport { get; private set; }
	}



	



	public class Position
	{
		[JsonProperty(PropertyName = "position")]
		public readonly string Pos;

		[JsonProperty(PropertyName = "team_id")]
		public readonly string TeamId;

		[JsonProperty(PropertyName = "team_name")]
		public readonly string TeamName;

		[JsonProperty(PropertyName = "played")]
		public readonly string Played;

		[JsonProperty(PropertyName = "points")]
		public readonly string Points;

		[JsonProperty(PropertyName = "won")]
		public readonly string Won;

		[JsonProperty(PropertyName = "lost")]
		public readonly string Lost;

		[JsonProperty(PropertyName = "draw")]
		public readonly string Draw;

		[JsonProperty(PropertyName = "sport")]
		public readonly Sport Sport;

		[JsonProperty(PropertyName = "serie")]
		public readonly string Serie;

		[JsonProperty(PropertyName = "goals_for")]
		public readonly string GoalsFor;

		[JsonProperty(PropertyName = "goals_against")]
		public readonly string GoalsAgainst;

		[JsonProperty(PropertyName = "difference")]
		public readonly string GoalsDifference;

		[JsonProperty(PropertyName = "penalties")]
		public readonly string Penalties;
	}
}
