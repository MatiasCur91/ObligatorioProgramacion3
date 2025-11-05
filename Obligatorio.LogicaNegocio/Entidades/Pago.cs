using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.LogicaNegocio.Entidades;

public abstract class Pago
{
    public int Id { get; set; }
    public MetodoDePago MetodoPago { get; set; }

    public TipoGasto TipoGasto { get; set; }

    public int TipoGastoID { get; set; }

    public Usuario Usuario { get; set; }

    public string Descripcion { get; set; }

    public double MontoTotal { get; set; }

    public DateTime FechaPago { get; set; }


    public Pago()
    {

    }
    public abstract void Validar();


    public Pago(MetodoDePago metodoDePago, TipoGasto tipoGasto, string descripcion, double monto, DateTime fechaPago, Usuario usuario)
    {
        if (string.IsNullOrEmpty(descripcion))
        {
            throw new DatosInvalidosException("Descripcion vacía");
        }
        if (descripcion.Length < 2)
        {
            throw new DatosInvalidosException("Descripcion no cumple con el largo.");
        }

        if (monto <= 0)
        {
            throw new DatosInvalidosException("Monto no válido");
        }
        if (fechaPago.Year < 2000)
        {

            throw new DatosInvalidosException("Fecha inválida");
        }
        
        MetodoPago = metodoDePago;
        TipoGasto = tipoGasto;
        Descripcion = descripcion;
        MontoTotal = monto;
        FechaPago = fechaPago;
        Usuario = usuario;


    }
}