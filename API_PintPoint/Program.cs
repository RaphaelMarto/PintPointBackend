using API_PintPoint.Service;
using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using CORE_PintPoint.Services;
using INFRA_PintPoint.Repository;
using INFRA_PintPoint.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

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

builder.Services.AddScoped<IAuthRepo, AuthRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<AuthenticateService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["jwt:issuer"],
            ValidAudience = builder.Configuration.GetSection("jwt").GetValue<string>("audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:secretKey"])),
            ClockSkew = TimeSpan.FromSeconds(10)
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policyBuilder =>
    {
        policyBuilder
            .RequireAuthenticatedUser()
            .RequireAssertion(context => context.User.HasClaim(ClaimTypes.Role, "Admin"))
            .Build();
    });
});

builder.Services.AddCors(options => options.AddPolicy("localhost",
    o => o.AllowCredentials()
          .WithOrigins("https://localhost:7136", "http://localhost:4200")
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
