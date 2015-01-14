using KNKVPlugin.Model;

namespace KNKVPlugin.Converters
{
	public class TeamsConverter : Converter
	{
		public ResponseResult<Teams> Convert(string jsonResponse)
		{
			var teams = DeserializeObject<Teams>(jsonResponse);
			return new ResponseResult<Teams>(jsonResponse, teams);
		}
	}
}
