
ProductAPP Sln 









Project creation steps


dotnet new classlib -o ./Core/ProductApp.Application
dotnet new classlib -o ./Core/ProductApp.Domain
dotnet new classlib -o ./Core/ProductApp.Mapper

dotnet new classlib -o ./Infrastructure/ProductApp.Infrastructure
dotnet new classlib -o ./Infrastructure/ProductApp.Persistence


dotnet new webapi -o ./Presentation/ProductApp.Api

dotnet sln ProductAPP.sln add ./Core/ProductApp.Application
dotnet sln ProductAPP.sln add ./Core/ProductApp.Domain
dotnet sln ProductAPP.sln add ./Core/ProductApp.Mapper

dotnet sln ProductAPP.sln add ./Infrastructure/ProductApp.Infrastructure
dotnet sln ProductAPP.sln add ./Infrastructure/ProductApp.Persistence

dotnet sln ProductAPP.sln add ./Presentation/ProductApp.Api



dotnet add package Microsoft.EntityFrameworkCore --version 7.0.4
dotnet add package Microsoft.AspNetCore.Http.Abstractions --version 2.2.0
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions --version 8.0.0
dotnet add package Microsoft.Extensions.Configuration --version 7.0.0
dotnet add package Microsoft.Extensions.Options.ConfigurationExtensions --version 8.0.0
