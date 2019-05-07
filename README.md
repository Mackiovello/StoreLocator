# StoreLocator

## Prerequisite

To build, run, and test, you have to have .NET Core 3.0 installed. I'm using .NET Core 3.0.100-preview3-010431.

## Setup

1. In `appsettings.json`, set `StoresFilePath` to point to the "stores.xml" file
2. Set the environment variable "STORE_LOCATOR_DB" to a Sqlite connection string, such as "Data Source=storelocator.db"
3. Run this command to create the database: `dotnet ef migrations add initialize; dotnet ef database update`
