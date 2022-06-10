using Business.Core;
using Business.Core.Catalog;
using Business.Core.Configurations;
using Catalog.BusinessLogicLayer;
using Catalog.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
//builder.Services.AddDbContext<EmployeeDbContext>(o =>
//{
//    o.UseSqlServer(_configuartion["connectionStrings:EmployeeDbConnectionString"]);
//});
var connectionString = builder.Configuration.GetSection("CatalogDatabaseConnectionString").Get<CatalogDatabaseConnectionString>().ConnectionString;
builder.Services.AddDbContext<CatalogContext>(opts => opts.UseSqlServer(connectionString));


builder.Services.AddScoped<IDataRepository<Item>, ItemRepository>();
builder.Services.AddScoped<IDataRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IBusinessLayer<Category>, CategoriesManager>();
builder.Services.AddScoped<IBusinessLayer<Item>, ItemsManager>();

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
