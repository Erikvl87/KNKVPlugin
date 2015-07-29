using System;

namespace KNKVPlugin.Exceptions
{
	public class SerializationException : Exception
	{
		public string Json { get; private set; }

		public SerializationException(string message, Exception innerException, string json)
			: base(message, innerException)
		{
			Json = json;
		}
	}
}
