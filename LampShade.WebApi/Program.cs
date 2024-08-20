using AccountManagment.Infrastructure.Configuration;
using DiscountManagment.Infrastructure.Configuration;
using Microsoft.OpenApi.Models;
using ShopManagment.Infrastructure.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LampShadeDB");

// Add services to the container.
ShopManagmentBoostrapper.Configure(builder.Services, connectionString);
DiscountManagmentBoostrapper.Configure(builder.Services, connectionString);
AccountManagmentBoostrapper.Configure(builder.Services, connectionString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    { 
        Title = "LampShade", 
        Version = "v1",
        Description = "An Api to perform LampShade by CLONER",
        Contact = new OpenApiContact
        {
            Name = "CLONER",
            Email = "clonerops@gmail.com",
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LampShade v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
