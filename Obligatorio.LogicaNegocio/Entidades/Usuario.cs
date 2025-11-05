using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.LogicaNegocio.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public NombreCompletoVO NombreCompleto { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Equipo? Equipo { get; set; }

    public int? EquipoId { get; set; }

    public Rol Rol { get; set; }

    public Usuario(NombreCompletoVO nombreCompleto)
    {
        NombreCompleto = nombreCompleto;
    }
    public Usuario()
    {

    }



}