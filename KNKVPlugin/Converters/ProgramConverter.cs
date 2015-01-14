using System.Collections.Generic;
using KNKVPlugin.Model;
using Newtonsoft.Json;

namespace KNKVPlugin.Converters
{
	public class ProgramConverter : Converter
	{
		public ResponseResult<Program> Convert(string jsonResponse)
		{
			var jResponse = ParseObject(jsonResponse);
			var weeks = new List<Week>();
			foreach (var row in jResponse)
				weeks.Add(JsonConvert.DeserializeObject<Week>(row.Value.ToString()));

			return new ResponseResult<Program>(jsonResponse, new Program(weeks));
		}
	}
}
