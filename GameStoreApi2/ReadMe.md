#Game Store Api


##Starting SQL Server
```powershell
$sa_password = "saPassword"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string
```powershell
$sa_password = "saPassword"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User ID=sa; Password=$sa_password;TrustServerCertificate=True"
```

