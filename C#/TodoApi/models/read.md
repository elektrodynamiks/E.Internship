https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio-code

// Create a new web API project
// to enable swagger in mac env. Modify tutorial to:

dotnet new webapi --no-openapi true --use-controllers -o TodoApi

// Add a NuGet package that is needed for the next section.
cd TodoApi  
dotnet add package Microsoft.EntityFrameworkCore.InMemory
--
Test the project
Trust the HTTPS development certificate by running the following command:
dotnet dev-certs https –trust
--
Get started with Swashbuckle and ASP.NET Core
Package installation
dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 6.6.2
--
Add the Swagger generator to the services collection in Program.cs:
C#Copy
builder.Services.AddControllers(); builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen();
--
Enable the middleware for serving the generated JSON document and the Swagger UI, also in Program.cs:
C#Copy
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
--
To serve the Swagger UI at the app's root (https://localhost:<port>/), set the RoutePrefix property to an empty string:
C#Copy
if (builder.Environment.IsDevelopment()) { app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development. { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); options.RoutePrefix = string.Empty; }); }

--
Run the app:
Run the following command to start the app on the https profile:
dotnet run --launch-profile https
--
Test  
curl https://localhost:7198/weatherforecast
=>  
[{"date":"2024-12-10","temperatureC":45,"temperatureF":112,"summary":"Bracing"},{"date":"2024-12-11","temperatureC":44,"temperatureF":111,"summary":"Freezing"},{"date":"2024-12-12","temperatureC":33,"temperatureF":91,"summary":"Freezing"},{"date":"2024-12-13","temperatureC":21,"temperatureF":69,"summary":"Mild"},{"date":"2024-12-14","temperatureC":44,"temperatureF":111,"summary":"Bracing"}]

Adding a new model for TodoItem

Add a model class
A model is a set of classes that represent the data that the app manages. The model for this app is the TodoItem class.
Add a folder named Models.
Add a TodoItem.cs file to the Models folder with the following code:

namespace TodoApi.Models; public class TodoItem { public long Id { get; set; } public string? Name { get; set; } public bool IsComplete { get; set; } }

Add a database context
The database context is the main class that coordinates Entity Framework functionality for a data model. This class is created by deriving from the Microsoft.EntityFrameworkCore.DbContext class.
Add a TodoContext.cs file to the Models folder.

using Microsoft.EntityFrameworkCore;  
namespace TodoApi.Models;  
public class TodoContext : DbContext { public TodoContext(DbContextOptions<TodoContext> options) : base(options) { } public DbSet<TodoItem> TodoItems { get; set; } = null!; }

Register the database context
In ASP.NET Core, services such as the DB context must be registered with the dependency injection (DI)container. The container provides the service to controllers.
Update Program.cs with the following highlighted code:
using Microsoft.EntityFrameworkCore;  
using TodoApi.Models;

builder.Services.AddControllers();  
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

Scaffold a controller
Control-click the TodoAPI project and select Open in Terminal. The terminal opens at the TodoAPI project folder. Run the following commands:

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool update -g dotnet-aspnet-codegenerator

Build the project.
Run the following command:
.NET CLICopy
dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers

The preceding command scaffolds the TodoItemsController.

Update the return statement in the PostTodoItem to use the nameof operator:
C#Copy

// return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);  
return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem); }

Run the app
dotnet run --launch-profile https
