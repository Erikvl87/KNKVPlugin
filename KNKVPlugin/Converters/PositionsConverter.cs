using System.Collections.Generic;
using KNKVPlugin.Model;
using Newtonsoft.Json;

namespace KNKVPlugin.Converters
{
	public class PositionsConverter : Converter
	{
		public ResponseResult<List<Poule>> Convert(string jsonResponse)
		{
			var jResponse = ParseArray(jsonResponse);
			var standings = new List<Poule>();

			foreach (var row in jResponse)
				standings.Add(JsonConvert.DeserializeObject<Poule>(row.ToString()));

			return new ResponseResult<List<Poule>>(jsonResponse, standings);
			
		}
	}
}
