using API_AppParkingSoft.DAL;
using API_AppParkingSoft.Domain.Interfaces;
using API_AppParkingSoft.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add DbContext
builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Interfaces and services
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IRateService, RateService>();
builder.Services.AddScoped<IReserveService, ReserveService>();
builder.Services.AddTransient<SeederDB>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

SeederDB();

//Configuración de un Alimentador de BD
void SeederDB()
{
    IServiceScopeFactory? scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopeFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }
}

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
