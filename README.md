# Game Store API

## Starting SWL Server

```powershell
$sa_password = "N6SOlIO1QRPeter.12345"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string to secret manager

```powershell
$sa_password = "N6SOlIO1QRPeter.12345"

dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=sa; Password=$sa_password; TrustServerCertificate=True"
``````
