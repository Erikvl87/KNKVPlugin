using System.IO;
using System.Reflection;
using KNKVPlugin;
using KNKVPlugin.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class UnitTests
	{
		/// <summary>
		/// Test if the url is valid
		/// </summary>
		[TestMethod]
		public void TestRequestUrl()
		{
			const string expectedRequestUrl = "http://www.knkv.nl/kcp/abc/json/";
			var request = new Request("abc");
			var actualRequestUrl = request.ServiceUrl;
			Assert.AreEqual(expectedRequestUrl, actualRequestUrl);
		}



		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void TestPositions()
		{
			var jsonResponse = GetEmbeddedResource("UnitTests.ExampleResponses.standings.json");
			var positions = PositionsConverter.Convert(jsonResponse);

			// Expecting 29 poule result objects
			Assert.AreEqual(29, positions.Result.Count);
		}



		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void TestProgram()
		{
			var jsonResponse = GetEmbeddedResource("UnitTests.ExampleResponses.program.json");
			var program = ProgramConverter.Convert(jsonResponse);

			// Expecting 14 teams
			Assert.AreEqual(14, program.Result.Matches.Count);

			// Expecting results from only 1 week
			Assert.AreEqual(1, program.Result.Weeks.Count);
		}



		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void TestResults()
		{
			var jsonResponse = GetEmbeddedResource("UnitTests.ExampleResponses.results.json");
			var results = ResultsConverter.Convert(jsonResponse);

			// Expecting 1 match result
			Assert.AreEqual(1, results.Result.Matches.Count);
		}



		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void TestTeams()
		{
			var jsonResponse = GetEmbeddedResource("UnitTests.ExampleResponses.teams.json");
			var teams = TeamsConverter.Convert(jsonResponse);
			
			// The raw response should be exactly the same as the input
			Assert.AreEqual(jsonResponse, teams.RawResponse);

			// Expecting 14 teams
			Assert.AreEqual(14, teams.Result.List.Count);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="resourceName"></param>
		/// <returns></returns>
		private static string GetEmbeddedResource( string resourceName )
		{
			var assembly = Assembly.GetExecutingAssembly();
			using (var stream = assembly.GetManifestResourceStream(resourceName))
			{
				using (var reader = new StreamReader(stream))
				{
					return reader.ReadToEnd();
				}
			}
		}
	}
}
