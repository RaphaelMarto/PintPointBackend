using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using CORE_PintPoint.Services;
using INFRA_PintPoint.Repository;
using INFRA_PintPoint.Service;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<SqlConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IBeersRepo, BeersRepo>();
builder.Services.AddScoped<IBeersService, BeersService>();

builder.Services.AddScoped<IBeerTypeRepo, BeerTypeRepo>();
builder.Services.AddScoped<IBeerTypeService, BeerTypeService>();

builder.Services.AddScoped<IBreweriesRepo, BreweriesRepo>();
builder.Services.AddScoped<IBreweriesService, BreweriesService>();

builder.Services.AddScoped<ICountriesRepo, CountriesRepo>();
builder.Services.AddScoped<ICountriesService, CountriesService>();

builder.Services.AddScoped<IRatingRepo, RatingRepo>();
builder.Services.AddScoped<IRatingService, RatingService>();

builder.Services.AddCors(options => options.AddPolicy("localhost",
    o => o.AllowCredentials()
          .WithOrigins("http://localhost:7136", "http://localhost:4200")
          .AllowAnyHeader()
          .AllowAnyMethod()));

var app = builder.Build();

app.UseCors("localhost");

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
