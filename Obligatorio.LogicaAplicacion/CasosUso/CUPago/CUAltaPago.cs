

using Obligatorio.DTOs.DTOs.DTOsPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUAltaPago : ICUAltaPago
    {
        private IRepositorioPago _repoPago;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioTipoGasto _repoTipoGasto;

        public CUAltaPago(IRepositorioPago repoPago, IRepositorioUsuario repoUsuario, IRepositorioTipoGasto repoTipoGasto)
        {
            _repoPago = repoPago;
            _repoUsuario = repoUsuario;
            _repoTipoGasto = repoTipoGasto;

        }

        public void AltaPago(DTOAltaPago dto, string emailUsuario)
        {
            var usuario = _repoUsuario.FindByEmail(emailUsuario);
            if (usuario == null)
                throw new UsuarioNoEncontradoException("Usuario no encontrado.");

            var tipo = _repoTipoGasto.FindById(dto.IdTipoGasto);
            if (tipo == null)
                throw new DatosInvalidosException("Tipo de gasto no encontrado.");

            var pago = MapperPago.FromDTOAltaPagoToPago(dto);
            pago.Usuario = usuario;
            pago.TipoGasto = tipo;

            pago.Validar();

            _repoPago.Add(pago);
            }



    }
}
