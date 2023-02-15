using CourseOnline.Application;
using CourseOnline.Infraestructure.Persistence;

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
