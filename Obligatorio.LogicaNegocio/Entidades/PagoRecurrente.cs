using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;

namespace Obligatorio.LogicaNegocio.Entidades;

public class PagoRecurrente : Pago
{

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public double MontoPago { get; set; }

    public override void Validar()
    {
        if (FechaFin <= FechaInicio)
        {
            throw new DatosInvalidosException("La fecha de fin debe ser posterior al inicio.");
        }
    }
    public void CalcularMontoTotal()
    {
        int cantidadMeses = ((FechaFin.Year - FechaInicio.Year) * 12) + (FechaFin.Month - FechaInicio.Month) + 1;
        MontoTotal = MontoPago * cantidadMeses;
    }
    public PagoRecurrente()
    {
    }
    public PagoRecurrente(DateTime fechaInicio, DateTime fechaFin, double montoPago)
    {

        if (fechaInicio.Year < 2000)
        {

            throw new DatosInvalidosException("Fecha de inicio inválida");
        }
        if (fechaInicio > fechaFin)
        {

            throw new DatosInvalidosException("Fechas inválidas");
        }
        if (montoPago <= 0)
        {
            throw new DatosInvalidosException("Monto inválido");
        }

        FechaFin = fechaFin;
        FechaInicio = fechaInicio;
        MontoPago = montoPago;



    }



}