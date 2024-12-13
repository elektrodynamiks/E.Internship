# Create a web API with ASP.NET Core and MongoDB.

https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-9.0&tabs=visual-studio-code

Run the app
CLI:
dotnet run --launch-profile https

# Install MongoDB.

# Create the ASP.NET Core web API project.

https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/3-exercise-create-web-api

CLI:
// dotnet new webapi -o BookStoreApi --no-openapi true
dotnet new webapi -o BookStoreApi
code BookStoreApi

# Add MongoDB to the project

NET CLI:
dotnet add package MongoDB.Driver

# Add Swagger to the project.

https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio
// dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 6.6.2
NET CLI:
dotnet add BookStoreApi.csproj package NSwag.AspNetCore
