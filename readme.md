# .NET Core Demo - Personal Blog
It is a personal blog website using .NET Core 8, sqlite, Bootstrap 5, css and JQuery/JavaScript. 

## Init new project
1. dotnet new mvc -o \<projectname\>
2. dotnet dev-certs https --trust

## Run project
dotnet run

## Add gitignore
dotnet new gitignore

## Install Entity Framework
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

## Using code generator
dotnet aspnet-codegenerator controller -name PostController -m Post -dc dotnet_mvc.Data.MvcBlogContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite

(dotnet aspnet-codegenerator controller -h to get help)
This code generator will generate a scaffold controller with CRUD routes and the related DB context.

## Init db using migration
1. dotnet ef migrations add InitialCreate
2. dotnet ef database update
- Optional: dotnet ef database drop -f -v to remove database