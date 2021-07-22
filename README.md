Sample shop API using Fauna and Java
=============

#### Table of Contents
* [Overview](#overview)
* [Prerequisites](#prerequisites)
* [Set up your Fauna database](#set-up-your-fauna-database)
* [Run the app locally](#run-the-app-locally)

## Overview
This is a sample .NET REST API for an e-commerce application that uses [Fauna](https://docs.fauna.com/) as a database, and Fauna's [C# driver](https://github.com/fauna/faunadb-csharp).

### Prerequisites
You need to install .NET 5.0 SDK:  
https://dotnet.microsoft.com/download/dotnet/5.0

Supported Java versions:
- .NET 5.0 and higher

The next step uses the [Fauna Dashboard](https://dashboard.fauna.com) to set up your database. Alternatively, you could use the [Fauna Shell/CLI tool](https://github.com/fauna/fauna-shell).

## Set up your Fauna database
1. [Sign up for free](https://dashboard.fauna.com/accounts/register) or [log in](https://dashboard.fauna.com/accounts/login) at [dashboard.fauna.com](https://dashboard.fauna.com/accounts/register).
2. Click [CREATE DATABASE], name it "shopapp", select a region group (e.g., "Classic"), and click [CREATE]
3. Click the [SECURITY] tab at the bottom of the left sidebar, and [NEW KEY].
4. Create a Key with the default Role of "Admin" selected, you'll need to add this key to one of the environment variable to start the app
5. Fill key values in appsettings.json file (ADMIN_KEY and SERVER_KEY values).
6. Open file DataBaseScripts\CreateDatabase.fql and execute each script in Fauna shell in the dashboard or fauna-shell app.

## Run the app locally
1. To access your Fauna database, you'll need to export your secret via an environment variable. Get `your-secret-key` from the secret you copied in the [Set up your Fauna database](#set-up-your-fauna-database) section, and run the following in your terminal:
```
export ADMIN_KEY=your_admin_secret_key
```
2. Open command line in `FaunadbShopApplication` and run the `dotnet run` command:
```
cd FaunadbShopApplication
dotnet run
```
3. When you start your server, a Swagger UI should be available at https://localhost:5001/swagger/index.html where you can observe and test the available REST endpoints

