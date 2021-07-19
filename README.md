# fauna-csharp
This is a sample application that demonstrates basics operations we can do perform in FQL
by using a Fauna client for C#

#Prepare database
- Create empty Fauna database
- Create new server and admin key and fill key values in appsettings.json file (ADMIN_KEY and SERVER_KEY values). 
- Open file DataBaseScripts\CreateDatabase.fql and execute each script in Fauna concole.

### Running the application locally
1. Open MS Visual Studio and press F5 button
2. Open command line in FaunadbShopApplication and run command "dotnet run".
   After that open browser and type link https://localhost:5001/swagger/index.html

### Rest services
- /api/User/ - creat new user and authentificate existing user
- /api/User/authenticate makes autentification.
- After that you should push Authorize button and input token value for other services
- /api/Product/ - product category and product services
