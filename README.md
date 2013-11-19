KNKVPlugin
==========

A .NET Class Library for the KNKV Onsweb.nl XML / JSON Plugin: http://www.onswebbond.nl/voor-verenigingen/

This class library owes its existance to a new project for http://www.gkvdenhaag.nl (project yet to be released).

## Requirements:
* .NET Framework v4.5
* A subscription for the Onsweb XML Webservice (http://www.onswebbond.nl/voor-verenigingen/bestelformulier-knkv/)

## Usage:
```csharp
korfballRequest = new KNKVPlugin.Request("<subscription code>");

// Get overall data
KNKVPlugin.DataTypes.Results results = korfballRequest.GetResults();
KNKVPlugin.DataTypes.Program program = korfballRequest.GetProgram();
KNKVPlugin.DataTypes.Positions positions = korfballRequest.GetPositions();
KNKVPlugin.DataTypes.Teams teams = korfballRequest.GetTeams();

// Get data from a week ago
KNKVPlugin.DataTypes.Results resultsOneWeekAgo = korfballRequest.GetResults(-1);

// Get data for a specific team-id
KNKVPlugin.DataTypes.Program programForTeam = korfballRequest.GetProgram(new[]{ 1234 });
KNKVPlugin.DataTypes.Results resultsForTeam = korfballRequest.GetResults(new[] { 1234 });
KNKVPlugin.DataTypes.Positions positionsForTeam = korfballRequest.GetPositions(new[] { 1234 });

// Get data from 2 weeks ago for a specific team-id
KNKVPlugin.DataTypes.Results resultsTwoweeksAgo = korfballRequest.GetResults(new[] { 1234 }, -2);
```
