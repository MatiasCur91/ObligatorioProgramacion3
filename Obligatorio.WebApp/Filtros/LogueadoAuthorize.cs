using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filtros
{
    public class LogueadoAuthorize:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("LogueadoRol");

            if (rol == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }


            base.OnActionExecuting(context);
        }
    }
}
