using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using passenger.DataAccess;
using passenger.ApplicationServices;
using passenger.DataAccess.Repositories;
using passenger.Core;

var builder = WebApplication.CreateBuilder(args);
var defaultDateCulture = "es-MX";
var ci = new CultureInfo(defaultDateCulture);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(ci);
    options.SupportedCultures = new List<CultureInfo>
    {
        ci,
    };
    options.SupportedUICultures = new List<CultureInfo>
    {
        ci,
    };
});

string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PassengerContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<IPassengerAppService, PassengerAppService>();
builder.Services.AddTransient<IRepository<int, Passenger>, Repository<int, Passenger>>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
