



using Microsoft.EntityFrameworkCore;
using Obligatorio.AccesoDatos;
using Obligatorio.AccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.CasosUso.CURol;
using Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto;
using Obligatorio.LogicaAplicacion.CasosUso.CUTiposDePago;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICURol;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.
// Registrar el DbContext en el contenedor de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

//ID de los repos

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();
builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();
builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();
builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();

//builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();



// ID Casos USO
builder.Services.AddScoped<ICULogin, CULogin>();
builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
builder.Services.AddScoped<ICUAltaPago, CUAltaPago>();
builder.Services.AddScoped<ICUObtenerRoles, CUObtenerRoles>();
builder.Services.AddScoped<ICUObtenerUsuariosConPagosMayores, CUObtenerUsuariosConPagosMayores>();
builder.Services.AddScoped<ICUAltaTipoGasto, CUAltaTipoGasto>();
builder.Services.AddScoped<ICUEliminarTipoGasto, CUEliminarTipoGasto>();
builder.Services.AddScoped<ICUObtenerPagos, CUObtenerPagos>();
builder.Services.AddScoped<ICUObtenerListadoMensual, CUObtenerListadoMensual>();
builder.Services.AddScoped<ICUListarTipoGasto, CUListarTipoGasto>();
builder.Services.AddScoped<ICUActualizarTipoGasto, CUActualizarTipoGasto>();




builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();