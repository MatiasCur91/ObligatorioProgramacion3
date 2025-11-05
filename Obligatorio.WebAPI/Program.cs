using Microsoft.EntityFrameworkCore;
using Obligatorio.AccesoDatos;
using Obligatorio.AccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


//Repositiorios
builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();


//Casos de uso
builder.Services.AddScoped<ICUObtenerPagos, CUObtenerPagos>();
builder.Services.AddScoped<ICUAltaPago, CUAltaPago>();




// Add services to the container.
builder.Services.AddControllers();
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