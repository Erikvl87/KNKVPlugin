using System;
using System.Collections.Generic;
using System.Web;
using KNKVPlugin.DataTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KNKVPlugin
{
	public partial class Request
	{
		/// <summary>
		/// Returns results for the current club (the club is determined by the service using the service code)
		/// </summary>
		/// <returns></returns>
		public Results GetResults()
		{
			return GetResults(null);
		}

		/// <summary>
		/// Returns poule results for the given teams
		/// </summary>
		/// <param name="teamIds"></param>
		/// <returns></returns>
		public Results GetResults(int[] teamIds)
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "result";
			queryString["t_id"] = (teamIds != null) ? String.Join(",", teamIds) : String.Empty;
			queryString["p"] = "0";
			queryString["full"] = "0";

			var response = Execute(queryString);
			try
			{
				var jResponse = JObject.Parse(response);
				var results = new Results { Weeks = new List<Week>() };

				foreach (var row in jResponse)
					results.Weeks.Add(JsonConvert.DeserializeObject<Week>(row.Value.ToString()));

				return results;
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(response, e);
			}
		}
	}
}
