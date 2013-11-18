using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using KNKVPlugin.DataTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KNKVPlugin
{
	public class Request
	{
		private readonly String _serviceUrl;

		public Request(string code)
		{
			_serviceUrl = String.Format("http://www.knkv.nl/kcp/{0}/json/", code);
			_serviceUrl = "http://www.erikvl87.nl/tests/standings.php";
		}


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


		public Results GetResults()
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "result";
			queryString["t_id"] = "";
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


		public Positions GetPositions()
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "standing";
			queryString["t_id"] = "";
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


		public Program GetPrograms()
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["t"] = "program";
			queryString["t_id"] = "";
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


		private string Execute(NameValueCollection postCollection)
		{
			var request = WebRequest.Create(_serviceUrl);
			request.ContentType = "application/x-www-form-urlencoded";
			request.Method = WebRequestMethods.Http.Post;

			postCollection["file"] = "json";
			postCollection["f"] = "get_data";
			var postData = postCollection.ToString();

			var byteArray = new ASCIIEncoding().GetBytes(postData);
			request.ContentLength = byteArray.Length;

			Stream stream = null;
			StreamReader streamReader = null;
			WebResponse response = null;

			try
			{
				// POST
				stream = request.GetRequestStream();
				stream.Write(byteArray, 0, byteArray.Length);
				stream.Close();

				// GET RESPONSE
				response = request.GetResponse();
				stream = response.GetResponseStream();

				// READ RESPONSE
				streamReader = new StreamReader(stream);
				var responseFromServer = streamReader.ReadToEnd();
				return responseFromServer;

			}
			finally
			{
				if (streamReader != null)
					streamReader.Close();

				if (stream != null)
					stream.Close();

				if (response != null)
					response.Close();
			}
		}
	}
}
