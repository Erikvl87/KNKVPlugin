using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace KNKVPlugin
{
	public class ResponseResult<T>
	{
		public string RawResponse { get; internal set; }
		public T Result { get; internal set; }

		public ResponseResult(string rawResponse, T result)
		{
			RawResponse = rawResponse;
			Result = result;
		}
	}



	public partial class Request
	{
		private readonly String _serviceUrl;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="code"></param>
		public Request(string code)
		{
			_serviceUrl = String.Format("http://www.knkv.nl/kcp/{0}/json/", code);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="postCollection"></param>
		/// <returns></returns>
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
				// POST REQUEST
				stream = request.GetRequestStream();
				stream.Write(byteArray, 0, byteArray.Length);
				stream.Close();

				// GET RESPONSE
				response = request.GetResponse();
				stream = response.GetResponseStream();

				// READ RESPONSE
				streamReader = new StreamReader(stream);
				var responseFromServer = streamReader.ReadToEnd();

				// RETURN RESPONSE
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
