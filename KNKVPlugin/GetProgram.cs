using System;
using System.Collections.Generic;
using System.Web;
using KNKVPlugin.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KNKVPlugin
{
	/// <summary>
	/// Returns the program for the teams of the current club (the club is determined by the service using the service code)
	/// </summary>
	public partial class Request
	{
		/// <summary>
		/// Get the program for all teams for this week
		/// </summary>
		/// <returns></returns>
		public Program GetProgram()
		{
			return GetProgram(null, false);
		}



		/// <summary>
		/// Get the program
		/// </summary>
		/// <param name="fullProgram">Indication for returning the full program or only for the current week.</param>
		/// <returns></returns>
		public Program GetProgram(bool fullProgram)
		{
			return GetProgram(null, true);
		}



		/// <summary>
		/// Get the program
		/// </summary>
		/// <param name="teamIds">Select teams to request the program</param>
		/// <returns></returns>
		public Program GetProgram(int[] teamIds)
		{
			return GetProgram(teamIds, false);
		}



		/// <summary>
		/// Returns the poule program for the given teams
		/// </summary>
		/// <param name="teamIds">Select teams to request the program</param>
		/// <param name="fullProgram">Indication for returning the full program or only for the current week.</param>
		/// <returns></returns>
		public Program GetProgram(int[] teamIds, bool fullProgram)
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "program";
			queryString["t_id"] = (teamIds != null) ? String.Join(",", teamIds) : String.Empty;
			queryString["p"] = "0";
			queryString["full"] = (fullProgram) ? "1" : "0";

			var response = Execute(queryString);

			try
			{
				var jResponse = JObject.Parse(response);

				var weeks = new List<Week>();
				foreach (var row in jResponse)
					weeks.Add(JsonConvert.DeserializeObject<Week>(row.Value.ToString()));

				return new Program(weeks);
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(response, e);
			}
		}
	}
}
