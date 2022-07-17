using CustomerSupport.Application.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using CustomerSupport.Resource;

namespace CustomerSupport.API.Common
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = null;
            var excecao = context.Exception;

            string stack = context.Exception.Message;

            if (excecao is ArgumentNullException)
            {
                apiError = new ApiError(Geral.GenericError, stack);
                context.HttpContext.Response.StatusCode = 400;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError(Geral.UnauthorizedAccess, stack);
                context.HttpContext.Response.StatusCode = 401;
            }
            else
            {
                apiError = new ApiError(Geral.GenericError, "");
                context.HttpContext.Response.StatusCode = 500;
            }
            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }
    }
}
