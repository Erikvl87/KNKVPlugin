using System.Runtime.Serialization;

namespace KNKVPlugin.Model
{
	public enum Sport
	{
		[EnumMember(Value = "KORFBALL-VE-WK")]
		Veld,

		[EnumMember(Value = "KORFBALL-ZA-WK")]
		Zaal
	}
}
