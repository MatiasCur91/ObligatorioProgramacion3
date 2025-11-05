using Microsoft.EntityFrameworkCore;
using Obligatorio.DTOs.DTOs.DTOsRol;
using Obligatorio.DTOs.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ValueObjects;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.DTOs.Mappers;


public class MapperUsuario
{
          
    

    public static DTOUsuario FromUsuarioToDtoUsuario(Usuario u)
    {

        DTOUsuario dto = new DTOUsuario();
        dto.Nombre = u.NombreCompleto.Nombre;
        dto.Apellido = u.NombreCompleto.Apellido;

        dto.Email = u.Email;
        dto.Rol = u.Rol.Nombre;
       

        return dto;
    }

    public static Usuario FromDtoAltaUsuarioToUsuario(DTOAltaUsuario dto)
    {

        Usuario nuevo = new Usuario(new NombreCompletoVO(dto.Nombre, dto.Apellido));
        nuevo.Password = Utilidades.Crypto.HashPasswordConBcrypt(dto.Password, 10);

        nuevo.Email = CrearEmail(nuevo.NombreCompleto);
        return nuevo;
    }

    public static string CrearEmail(NombreCompletoVO nombreCompleto)
    {
        if (string.IsNullOrWhiteSpace(nombreCompleto.Nombre) || string.IsNullOrWhiteSpace(nombreCompleto.Apellido))
            throw new ArgumentException("El nombre y apellido no pueden estar vacíos.");

        string nombreLimpio = QuitarAcentos(nombreCompleto.Nombre);
        string apellidoLimpio = QuitarAcentos(nombreCompleto.Apellido);

        string nombreParte = nombreLimpio.Substring(0, 3);
        string apellidoParte = apellidoLimpio.Substring(0, 3);

        if (nombreLimpio.Length < 3) nombreParte = nombreLimpio;
        if (apellidoLimpio.Length < 3) apellidoParte = apellidoLimpio;

        string emailGenerado = nombreParte + apellidoParte + "@laEmpresa.com";

        return emailGenerado;

    }

    private static string QuitarAcentos(string texto)
    {
        if (string.IsNullOrEmpty(texto)) return texto;

        string sinAcentos = texto.ToLower()
            .Replace("á", "a")
            .Replace("é", "e")
            .Replace("í", "i")
            .Replace("ó", "o")
            .Replace("ú", "u")
            .Replace("ü", "u")
            .Replace("ñ", "n");

        return sinAcentos;
    }

 
}