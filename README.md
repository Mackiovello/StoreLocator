# StoreLocator

## Prerequisite

To build, run, and test, you have to have .NET Core 3.0 installed. I'm using .NET Core 3.0.100-preview3-010431.

## Setup

In `appsettings.json`, set `StoresFilePath` to point to the "stores.xml" file

## Run and test

To run, execute this command from the root of the repository:

```
dotnet run -p .\src\StoreLocator\
```

This command creates a Sqlite database from the XML file at `StoresFilePath`, starts the application and exposes it on localhost:5000 and localhost:5001.

To test, execute this command from the root of the repository:

```
dotnet test .\test\StoreLocator.Test\
```
