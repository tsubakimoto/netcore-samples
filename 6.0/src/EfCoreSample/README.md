# Entity Framework Core 6
- [Overview of Entity Framework Core - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/)
- [Tutorial: Access data with managed identity - Azure App Service | Microsoft Docs](https://docs.microsoft.com/en-us/azure/app-service/tutorial-connect-msi-sql-database?tabs=windowsclient%2Cefcore%2Cdotnetcore)

## EF Core installation
- [Installing Entity Framework Core - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/get-started/overview/install)

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

## Migration
- [Migrations Overview - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

```
dotnet ef migrations add InitialCreate --output-dir Data/Migrations
dotnet ef database update
```

## Reverse Engineering
- [Reverse Engineering - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli)

```
dotnet user-secrets set ConnectionStrings:SampleDatabaseContext "{connection-string}"
dotnet ef dbcontext scaffold Name=ConnectionStrings:SampleDatabaseContext --context-dir Data --output-dir Models Microsoft.EntityFrameworkCore.SqlServer
```
