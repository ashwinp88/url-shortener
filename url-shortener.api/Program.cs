using url_shortener;
using url_shortener.application;
using url_shortener.core.interfaces;
using url_shortener.infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository<string>, InMemoryRepository>();
builder.Services.AddScoped<IApplication, Application>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Get}/{id?}"
);

app.MapControllers();

app.Run();
