using System;
using System.Web;
using KNKVPlugin.Model;
using Newtonsoft.Json;

namespace KNKVPlugin
{
	public partial class Request
	{
		/// <summary>
		/// Returns all teams for the current club (the club is determined by the service using the service code)
		/// </summary>
		/// <returns></returns>
		public Teams GetTeams()
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "teams";
			queryString["t_id"] = "";
			queryString["p"] = "0";
			queryString["full"] = "0";

			var response = Execute(queryString);

			try
			{
				var teams = JsonConvert.DeserializeObject<Teams>(response);
				return teams;
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(response, e);
			}
		}
	}
}
