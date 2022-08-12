using journey.ApplicationServices;
using journey.Core;
using journey.DataAccess;
using journey.DataAccess.Repositories;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;

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
builder.Services.AddDbContext<JourneyContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<IJourneyAppService, JourneyAppService>();
builder.Services.AddTransient<IRepository<int, Journey>, Repository<int, Journey>>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
