using System.IO;
using System.Reflection;
using KNKVPlugin;
using KNKVPlugin.Converters;
using NUnit.Framework;
namespace UnitTests
{
	[TestFixture]
	public class UnitTests
	{
		/// <summary>
		/// Test if the url is valid
		/// </summary>
		[Test]
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
		[Test]
		public void TestPositions()
		{
			var jsonResponse = GetEmbeddedResource("UnitTests.ExampleResponses.standings.json");
			var converter = new PositionsConverter();
			var positionsResponse = converter.Convert(jsonResponse);

			// Expecting 29 poule result objects
			Assert.AreEqual(29, positionsResponse.Result.Count);
		}



		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void TestProgram()
		{
			var jsonResponse = GetEmbeddedResource("UnitTests.ExampleResponses.program.json");
			var converter = new ProgramConverter();
			var programResponse = converter.Convert(jsonResponse);

			// Expecting 15 matches
			Assert.AreEqual(15, programResponse.Result.Matches.Count);

			// Expecting a program for 1 week
			Assert.AreEqual(1, programResponse.Result.Weeks.Count);
		}



		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void TestResults()
		{
			var jsonResponse = GetEmbeddedResource("UnitTests.ExampleResponses.results.json");
			var converter = new ResultsConverter();
			var resultsResponse = converter.Convert(jsonResponse);

			// Expecting 16 match result
			Assert.AreEqual(16, resultsResponse.Result.Matches.Count);
		}



		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void TestTeams()
		{
			var jsonResponse = GetEmbeddedResource("UnitTests.ExampleResponses.teams.json");
			var converter = new TeamsConverter();
			var teamsResponse = converter.Convert(jsonResponse);
			
			// The raw response should be exactly the same as the input
			Assert.AreEqual(jsonResponse, teamsResponse.RawResponse);

			// Expecting 15 teams
			Assert.AreEqual(15, teamsResponse.Result.List.Count);
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
