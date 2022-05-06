# Entity Framework Core 6
- [Overview of Entity Framework Core - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/)
- [Reverse Engineering - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli)
- [Tutorial: Access data with managed identity - Azure App Service | Microsoft Docs](https://docs.microsoft.com/en-us/azure/app-service/tutorial-connect-msi-sql-database?tabs=windowsclient%2Cefcore%2Cdotnetcore)

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet user-secrets set ConnectionStrings:SampleDatabaseContext "{connection-string}"
dotnet ef dbcontext scaffold Name=ConnectionStrings:SampleDatabaseContext --context-dir Data --output-dir Models Microsoft.EntityFrameworkCore.SqlServer
```
