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
}
