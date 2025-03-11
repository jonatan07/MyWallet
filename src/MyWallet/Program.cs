using MyWallet.API.DependencyInjections;
using MyWallet.Domain.Entities;
using MyWallet.Infrastructure.Context;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// -------------------------
//         SERILOG
// -------------------------
var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("../logs/MyWallet.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.AddSerilog(logger);
// -------------------------
//    DATABASE CONNECTION
// -------------------------
builder.Services.AddDbContext<BaseDbContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.CustomSchemaIds(type => type.ToString());
});

// -------------------------
//   DEPENDENCY INJECTIONS
// -------------------------
RepositoryDependencies.AddDependencies(builder.Services);
MediatorDependencies.AddDependencies(builder.Services);
// -------------------------
//        BUILD APP
// -------------------------
var app = builder.Build(); 
app.UsePathBase("/Wallets");
// Configure the HTTP request pipeline.
// -------------------------
//       SWAGGER UI
// -------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// -------------------------
//     APP Configuration
// -------------------------
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
