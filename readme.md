# .NET Core Demo - Personal Blog
It is a personal blog website using .NET Core 8, sqlite, Bootstrap 5, css and JQuery/JavaScript. 

## Init new project
1. dotnet new mvc -o \<projectname\>
2. dotnet dev-certs https --trust

## Run project
dotnet run

## Add gitignore
dotnet new gitignore

## Install Entity Framework (And use it in code first approach)
#### Uninstall previous version
dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
#### Install required packages
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

## Install ASP.NET Core Identity
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
(Then we can use "dotnet aspnet-codegenerator identity -h" to get more options)

## Using code generator
dotnet aspnet-codegenerator controller -name PostController -m Post -dc dotnet_mvc.Data.MvcBlogContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
dotnet aspnet-codegenerator identity -dc dotnet_mvc.Data.MvcBlogContext --databaseProvider sqlite
(optional: add '--files "Account.Register;Account.Login;Account.Logout"' to sepcify the required templates)

(dotnet aspnet-codegenerator controller -h to get help)
This code generator will generate a scaffold controller with CRUD routes and the related DB context.

## Init db using migration
1. dotnet ef migrations add InitialCreate
- Optional: you can seperate the initial table and authentication table migrations
2. dotnet ef database update
- Optional: dotnet ef database drop -f -v to remove database

## Notes
- If there are no administrator, the first registered user will be selected as admin. \
(Line 120-125 from Areas\Identity\Pages\Account\Register.cshtml.cs)