using System;
using System.Collections.Generic;
using System.Web;
using KNKVPlugin.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KNKVPlugin
{
	public partial class Request
	{
		/// <summary>
		/// Returns the program for the teams of the current club (the club is determined by the service using the service code)
		/// </summary>
		/// <returns></returns>
		public Program GetProgram()
		{
			return GetProgram(null);
		}

		/// <summary>
		/// Returns the poule program for the given teams
		/// </summary>
		/// <returns></returns>
		public Program GetProgram(int[] teamIds)
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "program";
			queryString["t_id"] = (teamIds != null) ? String.Join(",", teamIds) : String.Empty;
			queryString["p"] = "0";
			queryString["full"] = "0";

			var response = Execute(queryString);

			try
			{
				var jResponse = JObject.Parse(response);
				var program = new Program { Weeks = new List<Week>() };

				foreach (var row in jResponse)
					program.Weeks.Add(JsonConvert.DeserializeObject<Week>(row.Value.ToString()));

				return program;
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(response, e);
			}
		}
	}
}
