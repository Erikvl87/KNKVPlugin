using System;
using System.Collections.Generic;
using System.Web;
using KNKVPlugin.Converters;
using KNKVPlugin.Model;

namespace KNKVPlugin
{
	public partial class Request
	{
		/// <summary>
		/// Returns all poules positions for the current club (the club is determined by the service using the service code)
		/// </summary>
		/// <returns></returns>
		public ResponseResult<List<Poule>> GetPositions()
		{
			return GetPositions(null);
		}

		/// <summary>
		/// Returns poule positions for the given teams
		/// </summary>
		/// <param name="teamIds"></param>
		/// <returns></returns>
		public ResponseResult<List<Poule>> GetPositions(int[] teamIds)
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "standing";
			queryString["t_id"] = (teamIds != null) ? String.Join(",", teamIds) : String.Empty;
			queryString["p"] = "0";
			queryString["full"] = "0";

			var response = Execute(queryString);
			var converter = new PositionsConverter();
			var positions = converter.Convert(response);
			return positions;
		}
	}
}
