using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.DTOs.Mappers;

public class MapperPago
{
    public static Pago FromDTOAltaPagoToPago(DTOAltaPago dto)
    {
        if (dto.TipoSeleccionado.Equals("Recurrente"))
        {
            PagoRecurrente recurrente = new PagoRecurrente();
            if (dto.MetodoDePago.Equals("Efectivo"))
            {
                recurrente.MetodoPago = MetodoDePago.Efectivo;
            }

            if (dto.MetodoDePago.Equals("Credito"))
            {
                recurrente.MetodoPago = MetodoDePago.Credito;
            }

            recurrente.FechaInicio = dto.FechaInicio;
            recurrente.FechaFin = dto.FechaFin;
            recurrente.FechaPago = dto.FechaInicio;
            recurrente.Descripcion = dto.Descripcion;
            recurrente.TipoGastoID = dto.IdTipoGasto;
            recurrente.MontoPago = dto.Monto;
            recurrente.CalcularMontoTotal();

            return recurrente;



        }
        else
        {
            PagoUnico unico = new PagoUnico();

            if (dto.MetodoDePago.Equals("Efectivo"))
            {
                unico.MetodoPago = MetodoDePago.Efectivo;
            }

            if (dto.MetodoDePago.Equals("Credito"))
            {
                unico.MetodoPago = MetodoDePago.Credito;
            }
            unico.TipoGastoID = dto.IdTipoGasto;
            unico.Descripcion = dto.Descripcion;
            unico.FechaPago = dto.FechaPago;
            unico.NumeroRecibo = dto.NumeroRecibo;
            unico.MontoTotal = dto.Monto;

            return unico;
        }


    }

    public static DTOPago FromPagoToDtoPago(Pago p)
    {

        DTOPago dto = new DTOPago();
        dto.Descripcion = p.Descripcion;
        dto.Id = p.Id;
        dto.Id = p.Id;
        dto.MontoTotal = p.MontoTotal;
        dto.FechaPago = p.FechaPago;
    //    dto.UsuarioEmail = p.Usuario.Email;
        dto.TipoGasto = p.TipoGasto.Nombre;




        return dto;

    }

    public static List<DTOPago> ToListDTOPago(List<Pago> listaPagos)
    {
        List<DTOPago> ret = new List<DTOPago>();

        foreach (Pago p in listaPagos)
        {

            DTOPago dTOPais = MapperPago.FromPagoToDtoPago(p);
            ret.Add(dTOPais);
        }
        return ret;


    }


}