using Base.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.InteropServices;
using Base.Infrastructure.CrossCutting.Logs;
using System.Net;

namespace Base.Application.Api.Attributes
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var codigo = Marshal.GetExceptionPointers().ToString();
            var portalExeception = context.Exception.GetType().GetProperty("Causas");
            var messagem = context.Exception.Message;
            var rastreamento = context.Exception.StackTrace;

            if (context.Exception is BusinessException)
            {
                Log.Information("[BusinessException] " + messagem);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new ResultadoBase(codigo, messagem, rastreamento));
            }
            else
            {
                Log.Error("[Exception] " + messagem);

                if (portalExeception?.PropertyType.Name == "PortalHttpExceptionInfo[]")
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.HttpContext.Response.ContentType = "application/json";
                    context.Result = new JsonResult(new ResultadoBase(codigo, messagem, rastreamento));
                }

                else
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.HttpContext.Response.ContentType = "application/json";
                    context.Result = new JsonResult(new ResultadoBase(codigo, messagem, rastreamento));
                }

                base.OnException(context);
            }
        }
    }
}

