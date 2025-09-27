using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection;
using Villa.DataAccess.Context;
using Villa.Web.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper, custom service injections
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddServiceExtensions();


var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
var mongoDatabaseName = builder.Configuration.GetValue<string>("MongoDbSettings:DatabaseName");

if (string.IsNullOrEmpty(mongoConnectionString))
    throw new ArgumentNullException("MongoDbConnection boş!");

if (string.IsNullOrEmpty(mongoDatabaseName))
    throw new ArgumentNullException("MongoDbSettings:DatabaseName boş!");


var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);


builder.Services.AddDbContext<VillaContext>(options =>
{
    options.UseMongoDB(mongoClient, mongoDatabaseName);
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
