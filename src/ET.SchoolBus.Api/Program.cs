using ET.SchoolBus.Application;
using ET.SchoolBus.Data;

var builder = WebApplication.CreateBuilder(args);

//DI servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Data Layer
builder.Services.AddDataServices(builder.Configuration);

//Application Layer
builder.Services.AddApplicationServices();

var app = builder.Build();

//Middlewares
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseEndpoints(endpoints=>{
    endpoints.MapControllers();
});

app.Run();

 