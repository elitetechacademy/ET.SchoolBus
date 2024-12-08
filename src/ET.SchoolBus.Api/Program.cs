
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ET.SchoolBus.Data;
using ET.SchoolBus.Application;
using ET.SchoolBus.Api.Configurations;
using ET.SchoolBus.Pack;
using ET.SchoolBus.Pack.AppContext;


var builder = WebApplication.CreateBuilder(args);

//DI servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Data Layer
builder.Services.AddDataServices(builder.Configuration);

//Add Jwt
builder.Services.AddAuthentication()
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))
        };
    });
builder.Services.ConfigureSwaggerService();

//Application Layer
builder.Services.AddApplicationServices();

//Integration Layer
builder.Services.AddIntegrationServices();

//Pack Layer
builder.Services.AddPackServices();

//Seq Logging
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSeq(builder.Configuration.GetSection("Seq"));
});

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
    });

var app = builder.Build();

app.UseCors("AllowAll");

//Middlewares
app.UseRouting();

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

//app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    var applicationContext = context.RequestServices
        .GetRequiredService<ApplicationUserContext>();
    applicationContext.CurrentUser = context.User;
    await next();
});

app.MapControllers();

app.Run();

