using System.Collections.Generic;
using KNKVPlugin.Model;
using Newtonsoft.Json;

namespace KNKVPlugin.Converters
{
	public class ResultsConverter : Converter
	{
		public ResponseResult<Results> Convert(string jsonResponse)
		{
			var jResponse = ParseObject(jsonResponse);

			var weeks = new List<Week>();
			foreach (var row in jResponse)
				weeks.Add(DeserializeObject<Week>(row.Value.ToString()));

			return new ResponseResult<Results>(jsonResponse, new Results(weeks));
		}
	}
}
