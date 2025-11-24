using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.AccesoDatos;
using Obligatorio.AccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Text;
using Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


//Repositiorios
builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();


//Casos de uso
builder.Services.AddScoped<ICUObtenerPagos, CUObtenerPagos>();
builder.Services.AddScoped<ICUAltaPago, CUAltaPago>();
builder.Services.AddScoped<ICULogin, CULogin>();
builder.Services.AddScoped<ICUObtenerPagosUsuario, CUObtenerPagosUsuario>();
builder.Services.AddScoped<ICUGenerarPasswordAleatoria, CUGenerarPasswordAleatoria>();
builder.Services.AddScoped<ICUObtenerUsuarioPorEmail, CUObtenerUsuarioPorEmail>();
builder.Services.AddScoped<ICUUpdateUsuario, CUUpdateUsuario>();
builder.Services.AddScoped<ICUObtenerEquiposPagosUnicosMayores, CUObtenerEquiposPagosUnicosMayores>();
builder.Services.AddScoped<ICUListarTipoGasto, CUListarTipoGasto>();



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JWT
//La clave debe ser almacenada en el json, o en el sistema operativo cuando est�en producci�n.
var clave = "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        //Definir las verificaciones a realizar
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = claveCodificada
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();