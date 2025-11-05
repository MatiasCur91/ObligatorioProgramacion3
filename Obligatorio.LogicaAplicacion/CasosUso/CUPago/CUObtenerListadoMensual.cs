using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUObtenerListadoMensual : ICUObtenerListadoMensual
    {
        private IRepositorioPago _repoPago;

        public CUObtenerListadoMensual(IRepositorioPago repoPago)
        {
            _repoPago = repoPago;
        }

        public List<DTOPago> Obtener(int mes, int anio)
        {
            List<Pago> pagos = _repoPago.FindAll();
            List<DTOPago> dtoPagos = new List<DTOPago>();

            for (int i = 0; i < pagos.Count; i++)
            {
                Pago p = pagos[i];

             


                string tipoPago = "";
                double saldoPendiente = 0;


                if (p is PagoRecurrente recurrente
                && recurrente.FechaInicio <= new DateTime(anio, mes, 1)
                && (recurrente.FechaFin == null 
                || recurrente.FechaFin >= new DateTime(anio, mes + 1, 1)))
                {
                        recurrente.FechaPago = new DateTime(anio, mes, recurrente.FechaInicio.Day);

                        tipoPago = "Recurrente";
                    
                        int mesesTotales = ((recurrente.FechaFin.Year - recurrente.FechaInicio.Year) * 12) +
                                           recurrente.FechaFin.Month - recurrente.FechaInicio.Month + 1;

                        int mesesTranscurridos = ((anio - recurrente.FechaInicio.Year) * 12) +
                                                  mes - recurrente.FechaInicio.Month + 1;

                        int mesesRestantes = Math.Max(0, mesesTotales - mesesTranscurridos);
                        saldoPendiente = mesesRestantes * recurrente.MontoTotal;
                    }
                    
                    else if (p.FechaPago.Month == mes && p.FechaPago.Year == anio)
                { 

                    tipoPago = "Único";
                    saldoPendiente = 0;
                }

                dtoPagos.Add(new DTOPago
                {
                    Id = p.Id,
                    Descripcion = p.Descripcion,
                    MetodoDePago = p.MetodoPago.ToString(),
                    TipoGasto = p.TipoGasto.Nombre,
                    TipoPago = tipoPago,
                    MontoTotal = p.MontoTotal,
                    NombreUsuario = p.Usuario.NombreCompleto.Nombre + " " + p.Usuario.NombreCompleto.Apellido,
                    UsuarioEmail = p.Usuario.Email,
                    SaldoPendiente = saldoPendiente
                });
            }

            return dtoPagos;
        }
    }
}
