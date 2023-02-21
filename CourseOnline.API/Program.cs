using CourseOnline.Application;
using CourseOnline.Infraestructure.Persistence;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using CourseOnline.API.Middlewares;
using CourseOnline.API.Extensions;
using CourseOnline.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;
using CourseOnline.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CourseOnline.Security.TokenSecurity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text.Json.Serialization;
using CourseOnline.Infraestructure.Persistence.DapperConecction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Get IConfiguration
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

// add autorization for all controller
builder.Services.AddControllers( opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add own services layers
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(configuration);
builder.Services.AddSecurityCustom();


// add service for identity
builder.Services.TryAddSingleton<ISystemClock, SystemClock>();

//add autentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer( opt =>
                {
                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = Keys.keyJwt(),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });

//add configuration  reference circle en json



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

var app = builder.Build().SeedData();

//put middlewares

app.UseMiddleware<ErrorHandlerMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
