using System.Collections.Generic;
using Newtonsoft.Json;

namespace KNKVPlugin.DataTypes
{
	public class Poule
	{
		[JsonProperty(PropertyName = "poule_name")]
		public string PouleName { get; set; }

		[JsonProperty(PropertyName = "sport")]
		public string Sport { get; set; }
	}

	public class Position
	{
		[JsonProperty(PropertyName = "position")]
		public string Pos { get; set; }

		[JsonProperty(PropertyName = "team_name")]
		public string TeamName { get; set; }

		[JsonProperty(PropertyName = "played")]
		public string Played { get; set; }

		[JsonProperty(PropertyName = "points")]
		public string Points { get; set; }

		[JsonProperty(PropertyName = "won")]
		public string Won { get; set; }

		[JsonProperty(PropertyName = "lost")]
		public string Lost { get; set; }

		[JsonProperty(PropertyName = "draw")]
		public string Draw { get; set; }

		[JsonProperty(PropertyName = "sport")]
		public string Sport { get; set; }

		[JsonProperty(PropertyName = "serie")]
		public string Serie { get; set; }

		[JsonProperty(PropertyName = "goals_for")]
		public string GoalsFor { get; set; }

		[JsonProperty(PropertyName = "goals_against")]
		public string GoalsAgainst { get; set; }

		[JsonProperty(PropertyName = "penalties")]
		public string Penalties { get; set; }
	}

	public class Standing
	{
		[JsonProperty(PropertyName = "poule")]
		public Poule Poule { get; set; }

		[JsonProperty(PropertyName = "lines")]
		public List<Position> Positions { get; set; }
	}

	public class Standings
	{
		public List<Standing> Lists { get; set; } 
	}
}
