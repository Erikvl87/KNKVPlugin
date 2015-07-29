using System;
using KNKVPlugin.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace KNKVPlugin.Converters
{
	public class Converter
	{
		public Converter()
		{
			JsonConvert.DefaultSettings = (() =>
			{
				var settings = new JsonSerializerSettings();
				settings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
				return settings;
			});
		}



		protected static JArray ParseArray(string json)
		{
			try
			{
				var jResponse = JArray.Parse(json);
				return jResponse;
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(json, e);
			}
		}



		protected static JObject ParseObject(string json)
		{
			try
			{
				var jResponse = JObject.Parse(json);
				return jResponse;
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(json, e);
			}
		}



		protected static T DeserializeObject<T>(string json)
		{
			try
			{
				var deserializedObject = JsonConvert.DeserializeObject<T>(json);
				return deserializedObject;
			}
			catch (JsonReaderException e)
			{
				// No valid JSON was recieved. Throw the ugly html error that the service is returning.
				throw new ApplicationException(json, e);
			}
			catch (JsonSerializationException e)
			{
				// The jSON contains unexpected data.
				throw new SerializationException("Unexpected JSON data received.", e, json);

			}
		}
	}
}
