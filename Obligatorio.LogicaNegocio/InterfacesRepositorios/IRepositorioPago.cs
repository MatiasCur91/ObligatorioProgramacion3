using Obligatorio.LogicaNegocio.Entidades;



namespace Obligatorio.LogicaNegocio.InterfacesRepositorios;

public interface IRepositorioPago : IRepositorio<Pago>
{

    List<Usuario> ObtenerUsuariosConPagosMayores(double monto);

    List<Pago> FindByUsuario(int usuarioId);

}