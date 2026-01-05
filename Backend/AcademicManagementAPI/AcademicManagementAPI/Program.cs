using AcademicManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// 🔹 Authentication - JWT
builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
  };
});
// 🔹 Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 CORS (IMPORTANT for Angular)
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngular",
      policy => policy
          .AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod());
});


var app = builder.Build();

// 🔹 Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// 🔹 Enable CORS BEFORE controllers
app.UseCors("AllowAngular");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
