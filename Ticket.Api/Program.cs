using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Globalization;
using ticket.DataAccess;
using ticket.DataAccess.Repositories;
using Ticket.ApplicationServices;
using Ticket.ApplicationServices.Mapper;

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
builder.Services.AddDbContext<TicketContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<ITicketAppService, TicketAppService>();
builder.Services.AddTransient<IRepository<int, ticket.Core.Ticket>, Repository<int, ticket.Core.Ticket>>();

builder.Services.AddAutoMapper(typeof(MapperProfile));

IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .WriteTo.Console()
    .WriteTo.MySQL(
        connectionString: @"server=localhost;port=3306;user=root;password=12345678;database=ticketlogs",
        tableName: "logging"
       //restrictedToMinimumLevel: Debug"
       )
    .CreateLogger();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


try
{

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .WriteTo.MySQL(
            connectionString: @"server=localhost;port=3306;user=root;password=12345678;database=passengerlogs",
            tableName: "logging")
        .ReadFrom.Configuration(ctx.Configuration));
    //restrictedToMinimumLevel: Debug"

    var app = builder.Build();
    app.UseSerilogRequestLogging();
    Log.Information("Starting up!");

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


    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhabdled exception occurred during bootstrapping");
    return 1;

}
finally
{
    Log.Information("Stopped cleanly");
    Log.CloseAndFlush();
}
