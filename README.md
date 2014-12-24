[![NuGet](http://img.shields.io/nuget/v/KNKVPlugin.svg?style=flat-square)](https://www.nuget.org/packages/KNKVPlugin/)
[![Downloads](http://img.shields.io/nuget/dt/KNKVPlugin.svg?style=flat-square)](https://www.nuget.org/packages/KNKVPlugin/)
KNKVPlugin
==========

A C# .NET Class Library for the KNKV Onsweb.nl XML / JSON webservice: http://www.onswebbond.nl/voor-verenigingen/

This KNKV plugin owes its existance to the http://www.gkvdenhaag.nl website.

## Requirements:
* .NET Framework v4.5
* A subscription for the Onsweb XML Webservice (http://www.onswebbond.nl/voor-verenigingen/bestelformulier-knkv/)

## NuGet:
The KNKVPlugin is available on NuGet: https://www.nuget.org/packages/KNKVPlugin/

## Getting started:
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

## Documentation:
Documentation and examples can be found on the GitHub Wiki at https://github.com/Erikvl87/KNKVPlugin/wiki 
