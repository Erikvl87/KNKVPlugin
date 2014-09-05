KNKVPlugin
==========

A C# .NET Class Library for the KNKV Onsweb.nl XML / JSON webservice: http://www.onswebbond.nl/voor-verenigingen/

This KNKV plugin owes its existance to the http://www.gkvdenhaag.nl website.

## Requirements:
* .NET Framework v4.5
* A subscription for the Onsweb XML Webservice (http://www.onswebbond.nl/voor-verenigingen/bestelformulier-knkv/)

## NuGet:
The KNKVPlugin is available on NuGet: https://www.nuget.org/packages/KNKVPlugin/

## Usage:
```csharp
var korfballRequest = new KNKVPlugin.Request("<subscription code>");
var results = korfballRequest.GetResults();
var program = korfballRequest.GetProgram();
var positions = korfballRequest.GetPositions();
var teams = korfballRequest.GetTeams();

// Get data from a week ago
var resultsOneWeekAgo = korfballRequest.GetResults(-1);

// Get data for a specific team-id
var programForTeam = korfballRequest.GetProgram(new[]{ 1234 });
var resultsForTeam = korfballRequest.GetResults(new[] { 1234 });
var positionsForTeam = korfballRequest.GetPositions(new[] { 1234 });

// Get data from 2 weeks ago for a specific team-id
KNKVPlugin.Model.Results resultsTwoweeksAgo = korfballRequest.GetResults(new[] { 1234 }, -2);
```

## Examples:
#### Program
```csharp
var korfballRequest = new KNKVPlugin.Request("<subscription code>");
var program = korfballRequest.GetProgram();

foreach (var game in program)
{
	Console.WriteLine("{0} {1}", game.Date, game.Time);
	Console.WriteLine("{0} - {1}", game.TeamName, game.TeamNameGuests);
	Console.WriteLine("{0}", game.FacilityName);
	Console.WriteLine();
}
```

#### Results
```csharp
var korfballRequest = new KNKVPlugin.Request("<subscription code>");
var program = korfballRequest.GetProgram();

foreach (var game in results)
{
	Console.WriteLine("{0} - {1}: {2}, {3}", game.Score, game.ScoreGuests, game.TeamName, game.TeamNameGuests);
	Console.WriteLine();
}
```

#### Teams
```csharp
var korfballRequest = new KNKVPlugin.Request("<subscription code>");
var teams = korfballRequest.GetTeams();

foreach (var team in teams)
{
	Console.WriteLine("{0}", team.TeamName);
}
```

#### Scores
```csharp
var korfballRequest = new KNKVPlugin.Request("<subscription code>");
var results = korfballRequest.GetResults();

foreach (var result in results)
{
	Console.WriteLine("{0} - {1}: {2} - {3}", result.Score, result.ScoreGuests, result.TeamName, result.TeamNameGuests);
}
```

## Available properties:
* Match
	* ProgramId
	* GameId
	* Year
	* TeamName
	* ClubCode
	* TeamNameGuests
	* ClubCodeGuests
	* Date
	* Time
	* MatchOfficials
	* PouleName
	* HomeTeamId
	* AwayTeamId
	* ClassName
	* Field
	* FacilityName
	* FacilityId
	* Score
	* ScoreGuests
* Positions
	* Pos
	* TeamName
	* Played
	* Points
	* Won
	* Lost
	* Draw
	* Sport
	* Serie
	* GoalsFor
	* GoalsAgainst
	* Penalties
* Teams
	* SeasonYear
	* SeasonSerie
	* ClubCode
	* PouleId
	* SportId
	* TeamNameBasic
	* TeamName
	* ClassId
	* TeamId
	* TeamIdGroup