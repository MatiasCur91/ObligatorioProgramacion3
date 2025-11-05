using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filtros
{
    public class AdministradorAuthorize:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("LogueadoRol");

            if (rol != "Administrador")
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }


            base.OnActionExecuting(context);
        }
    }
}
