using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;

namespace Obligatorio.LogicaNegocio.Entidades;

public class PagoUnico : Pago
{


    public int NumeroRecibo { get; set; }
    public double MontoPago { get; set; }


    public override void Validar()
    {
        if (MontoTotal <= 0)
            throw new DatosInvalidosException("El monto debe ser mayor a 0.");

        if (FechaPago == null)
            throw new DatosInvalidosException("Debe ingresar la fecha del pago.");
    }

    public PagoUnico()
    {
    }
    public PagoUnico(int numeroRecibo, double montoPago)
    {
        if (numeroRecibo <= 0)
        {
            throw new DatosInvalidosException("Numero inválido");
        }

        if (montoPago <= 0)
        {
            throw new DatosInvalidosException("Monto inválido");
        }

        MontoPago = montoPago;
        NumeroRecibo = numeroRecibo;



    }

}