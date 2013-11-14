using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using KNKVPlugin.DataTypes;
using Newtonsoft.Json;

namespace KNKVPlugin
{
	public class Request
	{
		private readonly WebRequest _request;

		public Request(string code)
		{
			var serviceUrl = String.Format("http://www.knkv.nl/kcp/{0}/json/", code);
			_request = WebRequest.Create(serviceUrl);
			_request.ContentType = "application/x-www-form-urlencoded";
			_request.Method = WebRequestMethods.Http.Post;
		}


		public Teams GetTeams()
		{
			var queryString = HttpUtility.ParseQueryString(String.Empty);
			queryString["file"] = "json";
			queryString["f"] = "get_data";
			queryString["t"] = "teams";
			queryString["t_id"] = "";
			queryString["p"] = "0";
			queryString["full"] = "0";

			var response = Execute(queryString);

			try
			{
				var jObject = JsonConvert.DeserializeObject<Teams>(response);
				return jObject;
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(response);
			}
			
		}


		private string Execute(NameValueCollection postCollection)
		{
			var postData = postCollection.ToString();
			var byteArray = new ASCIIEncoding().GetBytes(postData);
			_request.ContentLength = byteArray.Length;

			Stream stream = null;
			StreamReader streamReader = null;
			WebResponse response = null;

			try
			{
				// POST
				stream = _request.GetRequestStream();
				stream.Write(byteArray, 0, byteArray.Length);
				stream.Close();

				// GET RESPONSE
				response = _request.GetResponse();
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
