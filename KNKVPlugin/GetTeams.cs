using System;
using System.Web;
using KNKVPlugin.Converters;
using KNKVPlugin.Model;

namespace KNKVPlugin
{
	public partial class Request
	{
		/// <summary>
		/// Returns all teams for the current club (the club is determined by the service using the service code)
		/// </summary>
		/// <returns></returns>
		public ResponseResult<Teams> GetTeams()
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "teams";
			queryString["t_id"] = "";
			queryString["p"] = "0";
			queryString["full"] = "0";

			var response = Execute(queryString);
			var converter = new TeamsConverter();
			var teams = converter.Convert(response);
			return teams;
		}
	}
}
