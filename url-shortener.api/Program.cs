using Amazon.DynamoDBv2;
using Amazon.Runtime;
using url_shortener;
using url_shortener.core;
using url_shortener.core.Interfaces;
using url_shortener.infrastructure.DataStores;
using url_shortener.infrastructure.DataStores.Interfaces;
using url_shortener.infrastructure.RandomStringGenerators;
using url_shortener.infrastructure.RandomStringGenerators.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AmazonDynamoDBConfig config = new()
{
    ServiceURL = "http://localhost:8000"
};
AmazonDynamoDBClient amazonDbClient = new(config);

builder.Services.AddSingleton<IAmazonDynamoDB>(amazonDbClient);
builder.Services.AddSingleton<IDataStore<string>, DynamoDbStore>();
builder.Services.AddSingleton<IRandomStringGenerator, ShortStringGenerator>();
builder.Services.AddScoped<IApplication, Application>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
