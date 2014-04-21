using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using KNKVPlugin.Model;
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
			return GetResults(null, 0);
		}


		/// <summary>
		/// Returns paged results for the current club (the club is determined by the service using the service code)
		/// </summary>
		/// <param name="paging"></param>
		/// <returns></returns>
		public Results GetResults(int paging)
		{
			return GetResults(null, paging);
		}


		/// <summary>
		/// Returns poule results for the given teams
		/// </summary>
		/// <param name="teamIds"></param>
		/// <returns></returns>
		public Results GetResults(int[] teamIds)
		{
			return GetResults(teamIds, 0);
		}


		/// <summary>
		/// Returns paged poule results for the given teams
		/// </summary>
		/// <param name="teamIds"></param>
		/// <param name="paging"></param>
		/// <returns></returns>
		public Results GetResults(int[] teamIds, int paging)
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "result";
			queryString["t_id"] = (teamIds != null) ? String.Join(",", teamIds) : String.Empty;
			queryString["p"] = paging.ToString(CultureInfo.InvariantCulture);
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
