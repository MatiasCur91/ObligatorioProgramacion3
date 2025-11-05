using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOsUsuario;

using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidos;

namespace Obligatorio.WebApp.Controllers;

public class AuthController : Controller
{
    private ICULogin _CuLogin;
    public AuthController(ICULogin CuLogin)
    {
        _CuLogin = CuLogin;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(DTOLogin dto)
    {

        try
        {
            //Verifico existencia del usuario
            DTOUsuario u = _CuLogin.VerificarExistencia(dto);

            ViewBag.msg = "Los datos son validos";

            //Grabar las variables de sesión.

            HttpContext.Session.SetString("LogueadoEmail", u.Email);
            HttpContext.Session.SetString("LogueadoRol", u.Rol); 

            return RedirectToAction("Index", "Home");

        }
        catch (DatosInvalidosException e)
        {

            ViewBag.msg = "Los datos no son válidos";
        }
        catch (Exception e)
        {

            ViewBag.msg = e.Message;
        }


        return View();
    }


    public IActionResult Logout()
    {

        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}

