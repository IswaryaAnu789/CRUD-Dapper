using Dapperempdetails.Repository;
using Dapperempdetails.Repository.Interface;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Log/log.txt",rollingInterval:RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

//builder.Services.AddControllers(options =>
//{
//    options.ReturnHttpNotAcceptable = true;  // Return 406 Not Acceptable if the requested media type is not supported
//})
//.AddNewtonsoftJson()  // Enable Newtonsoft JSON for JSON serialization
//.AddXmlDataContractSerializerFormatters();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
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
