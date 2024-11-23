using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ET.SchoolBus.Data;
using ET.SchoolBus.Application;
using ET.SchoolBus.Api.Configurations;


var builder = WebApplication.CreateBuilder(args);

//DI servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Data Layer
builder.Services.AddDataServices(builder.Configuration);

//Add Jwt
builder.Services.AddAuthentication()
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))                   
        };
    });
builder.Services.ConfigureSwaggerService();

//Application Layer
builder.Services.AddApplicationServices();

//Integration Layer
builder.Services.AddIntegrationServices();

var app = builder.Build();

//Middlewares
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

 