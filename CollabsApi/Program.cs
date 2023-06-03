using CollabsApi.Models;
using CollabsApi.Services;
using MassTransit;
using CollabsApi.Consumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MyOCPDatabaseSettings>(
    builder.Configuration.GetSection("MyOCPDatabase"));


builder.Services.AddSingleton<CollabService>();
builder.Services.AddSingleton<EnfantsService>(); 
   //NEWWWWWW

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP Demande pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
