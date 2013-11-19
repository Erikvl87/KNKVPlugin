using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using KNKVPlugin.DataTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KNKVPlugin
{
	public partial class Request
	{
		/// <summary>
		/// Returns all poules positions for the current club (the club is determined by the service using the service code)
		/// </summary>
		/// <returns></returns>
		public Positions GetPositions()
		{
			return GetPositions(null);
		}

		/// <summary>
		/// Returns poule positions for the given teams
		/// </summary>
		/// <param name="teamIds"></param>
		/// <returns></returns>
		public Positions GetPositions(int[] teamIds)
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "standing";
			queryString["t_id"] = (teamIds != null) ? String.Join(",", teamIds) : String.Empty;
			queryString["p"] = "0";
			queryString["full"] = "0";

			var response = Execute(queryString);

			try
			{
				var jResponse = JArray.Parse(response);
				var standings = new Positions { PoulePositions = new List<PoulePosition>() };

				foreach (var row in jResponse)
					standings.PoulePositions.Add(JsonConvert.DeserializeObject<PoulePosition>(row.ToString()));

				return standings;
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(response, e);
			}
		}
	}
}
