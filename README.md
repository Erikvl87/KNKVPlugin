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

// Get overall data
KNKVPlugin.Model.Results results = korfballRequest.GetResults();
KNKVPlugin.Model.Program program = korfballRequest.GetProgram();
KNKVPlugin.Model.Positions positions = korfballRequest.GetPositions();
KNKVPlugin.Model.Teams teams = korfballRequest.GetTeams();

// Get data from a week ago
KNKVPlugin.Model.Results resultsOneWeekAgo = korfballRequest.GetResults(-1);

// Get data for a specific team-id
KNKVPlugin.Model.Program programForTeam = korfballRequest.GetProgram(new[]{ 1234 });
KNKVPlugin.Model.Results resultsForTeam = korfballRequest.GetResults(new[] { 1234 });
KNKVPlugin.Model.Positions positionsForTeam = korfballRequest.GetPositions(new[] { 1234 });

// Get data from 2 weeks ago for a specific team-id
KNKVPlugin.Model.Results resultsTwoweeksAgo = korfballRequest.GetResults(new[] { 1234 }, -2);
```
