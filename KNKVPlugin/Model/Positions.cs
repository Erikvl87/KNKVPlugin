using System.Collections.Generic;
using Newtonsoft.Json;

namespace KNKVPlugin.Model
{
	public class Positions
	{
		public List<PoulePosition> PoulePositions;
	}


	public class PoulePosition
	{
		[JsonProperty(PropertyName = "poule")]
		public readonly Poule Poule;

		[JsonProperty(PropertyName = "lines")]
		public readonly List<Position> Positions;
	}


	public class Poule
	{
		[JsonProperty(PropertyName = "poule_name")]
		public readonly string PouleName;

		[JsonProperty(PropertyName = "sport")]
		public readonly string Sport;
	}

	public class Position
	{
		[JsonProperty(PropertyName = "position")]
		public readonly string Pos;

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
		public readonly string Sport;

		[JsonProperty(PropertyName = "serie")]
		public readonly string Serie;

		[JsonProperty(PropertyName = "goals_for")]
		public readonly string GoalsFor;

		[JsonProperty(PropertyName = "goals_against")]
		public readonly string GoalsAgainst;

		[JsonProperty(PropertyName = "penalties")]
		public readonly string Penalties;
	}
}
