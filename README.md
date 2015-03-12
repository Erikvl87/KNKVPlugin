[![Build Status](https://travis-ci.org/Erikvl87/KNKVPlugin.svg?branch=master)](https://travis-ci.org/Erikvl87/KNKVPlugin)
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
var resultsResponse = korfballRequest.GetResults();
var programResponse = korfballRequest.GetProgram();
var positionsResponse = korfballRequest.GetPositions();
var teamsResponse = korfballRequest.GetTeams();
```
Please read the documentation on how to work with the returned objects.

## Documentation:
Documentation and examples can be found on the GitHub Wiki at https://github.com/Erikvl87/KNKVPlugin/wiki 
