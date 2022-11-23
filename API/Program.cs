using API.Infrastructure.Data;
using API.Infrastructure.Repository;
using API.Utils;

var builder = WebApplication.CreateBuilder(args);

 var cadena = builder.Configuration.GetConnectionString("Default");

// Add services to the container.

builder.Services.AddControllers();

// Inyecta en el constructor de cada controller
//builder.Services.AddSingleton(new UI(cadena));

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddTransient<ICursoRepository, CursoRepository>();
builder.Services.AddTransient<ISolicitudRepository, SolicitudRepository>();
builder.Services.AddTransient<IDetalleRepository, DetalleRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
