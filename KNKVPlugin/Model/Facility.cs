using Newtonsoft.Json;

namespace KNKVPlugin.Model
{
	public class Facility
	{
		[JsonProperty(PropertyName = "facility_id")]
		public readonly string Id;

		[JsonProperty(PropertyName = "facility_name")]
		public readonly string Name;

		[JsonProperty(PropertyName = "facility_address")]
		public readonly string Address;

		[JsonProperty(PropertyName = "facility_zipcode")]
		public readonly string Zipcode;

		[JsonProperty(PropertyName = "facility_city")]
		public readonly string City;
	}
}
