using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DecorationSystem.Filter
{
    public class LoginFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
         
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           string str= context.HttpContext.Session.GetString("isLogin");
            if (string.IsNullOrEmpty(str))
            {
                context.Result = new RedirectResult("/LogIn/Index");
            }

        }
    }
}
