using Business.Core.Configurations;
using CartingService.CartBLL;
using CartingService.CartDAL;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<ICartBL, CartBL>();
builder.Services.AddSingleton<ICartDataHandler, CartDataHandler>();
builder.Services.AddSingleton<IMongoClient, MongoClient>();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new QueryStringApiVersionReader("version");
});

builder.Services.AddSingleton((service) =>
{
    IMongoClient client = new MongoClient(builder.Configuration.GetSection("DatabaseSettings:ConnectionString").Get<string>());
    return client;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
