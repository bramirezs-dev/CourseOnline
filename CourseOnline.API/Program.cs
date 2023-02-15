using CourseOnline.Application;
using CourseOnline.Infraestructure.Persistence;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using CourseOnline.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

// Get IConfiguration
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add own services
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(configuration);

//Configuration Swagger
builder.Services.AddSwaggerGen(swagger => {
    swagger.SwaggerDoc("v1", new OpenApiInfo { Title="CoursesOnline.API", Version = "v1" });
});

builder.Services.AddApiVersioning( config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});


var app = builder.Build();

//put middlewares

app.UseMiddleware<ErrorHandlerMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
