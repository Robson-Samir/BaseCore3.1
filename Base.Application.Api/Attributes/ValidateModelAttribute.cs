﻿using Base.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Base.Application.Api.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                var resultado = new ResultadoOperacao();
                foreach (var values in actionContext.ModelState.Values)
                {
                    foreach (var error in values.Errors)
                    {
                        resultado.Excecao.Add(new Excecao { Mensagem = error.Exception != null ? error.Exception.Message : error.ErrorMessage });
                    }
                }

                actionContext.HttpContext.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                actionContext.Result = new JsonResult(resultado);
            }
        }
    }
}
