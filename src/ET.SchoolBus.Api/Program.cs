using ET.SchoolBus.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI servisleri
builder.Services.AddDbContext<SchoolBusContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolBusConnection"), 
        builder => builder.MigrationsAssembly("ET.SchoolBus.Data")));

var app = builder.Build();

//Middlewares

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

 