# fauna-csharp
This is a sample application that demonstrates basics operations we can perform by using a Fauna client for C#

### Prerequisites
You need to install .NET 5.0 SDK:  
https://dotnet.microsoft.com/download/dotnet/5.0

Supported Java versions:
- .NET 5.0 and higher

You can do all operations on the database from the fauna dashboard:  
https://dashboard.fauna.com/  
Alternatively, you can use a fauna-shell app:  
https://github.com/fauna/fauna-shell

### Prepare the database
* [Sign up for free](https://dashboard.fauna.com/accounts/register) or [log in](https://dashboard.fauna.com/accounts/login) at [dashboard.fauna.com](https://dashboard.fauna.com/accounts/register).
* Click [CREATE DATABASE], name it "shopapp", select a region group (e.g., "Classic"), and click [CREATE]
* Click the [SECURITY] tab at the bottom of the left sidebar, and [NEW KEY].
* Create a Key with the default Role of "Admin" selected, you'll need to add this key to one of the environment variable to start the app
* Fill key values in appsettings.json file (ADMIN_KEY and SERVER_KEY values).
* Open file DataBaseScripts\CreateDatabase.fql and execute each script in Fauna shell in the dashboard or fauna-shell app.

### Running the application locally
1. You'll need to export environment variable before starting the app:
```
export ADMIN_KEY=your_admin_secret_key
```
2. Open command line in `FaunadbShopApplication` and run the `dotnet run` command:
```
cd FaunadbShopApplication
dotnet run
```

### Swagger UI
Swagger UI is automatically started as well, so you can check all
the available endpoints here:  
https://localhost:5001/swagger/index.html
