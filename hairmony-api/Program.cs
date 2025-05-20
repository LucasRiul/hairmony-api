using hairmony_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using hairmony_api.Interface;
using hairmony_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<hairmonyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
#region Injection
builder.Services.AddScoped<ILoginService, LoginService>();
#endregion

#region jwt
var jwtSettings = builder.Configuration.GetSection("Jwt");
//var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]); //dev
var secretKey = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET") ?? jwtSettings["SecretKey"]); //dev

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Em produção, defina como true
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero // Remove a tolerância de tempo padrão
    };
});

builder.Services.AddAuthorization();
#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy
            .WithOrigins("http://localhost:4230", "https://hairmony.hair/") 
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
    );
});
#endregion
// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAngularApp");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
