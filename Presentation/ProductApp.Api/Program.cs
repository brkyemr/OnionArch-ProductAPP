using ProductApp.Persistence;
using ProductApp.Application;
using ProductApp.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;
 builder.Configuration
    .SetBasePath(env.ContentRootPath)  //for dynamic root path 
    .AddJsonFile("appsettings.json",optional : false)
    .AddJsonFile($"appsettings.Development.json",optional: true);  

//builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:MSsql_Conn"]));
Console.WriteLine("config read in the pg.cs => ",builder.Configuration["ConnectionStrings:DefaultConnection"]);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
