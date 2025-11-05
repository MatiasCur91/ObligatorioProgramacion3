using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago;

public class CUObtenerPagos : ICUObtenerPagos
{
    private IRepositorioPago _repoPago;

    public CUObtenerPagos(IRepositorioPago repoLibro)
    {
        _repoPago = repoLibro;

    }
    public List<DTOPago> ObtenerPagos()
    {
        List<Pago> pagos = _repoPago.FindAll();

        List<DTOPago> retorno = MapperPago.ToListDTOPago(pagos);
        return retorno;
    }

    public DTOPago ObtenerPago(int id)
    {
        Pago buscado = _repoPago.FindById(id);

        if (buscado is null)
        {

            throw new PagoNoEncontradoException();

        }

        DTOPago retorno = MapperPago.FromPagoToDtoPago(buscado);
        return retorno;
    }
}