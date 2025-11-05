using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filtros
{
    public class AdministradorYGerenteAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("LogueadoRol");

            if (rol != "Administrador" && rol != "Gerente")
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }


            base.OnActionExecuting(context);
        }
    }
}
