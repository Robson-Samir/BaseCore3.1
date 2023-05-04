using System.Linq;
using System.Security.Claims;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Base.Infrastructure.CrossCutting.Enums;
using System;

namespace Base.Application.Api.Attributes
{
    public class ClaimRequirementFilter : Attribute, IAuthorizationFilter
    {
        readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.User.Claims.Any())
            {
                context.Result = new ForbidResult();
            }
            else
            {
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                if (controllerActionDescriptor != null)
                {
                    var acessos = controllerActionDescriptor.MethodInfo.GetCustomAttributes<Acesso>();
                    var permissao = false;
                    var permissaoTodos = "";
                    var permissaoComposta = "";

                    var funcoes = context.HttpContext.User.Claims.Where(x => x.Type.ToUpper() == ChaveDeLogin.Funcao.ToString().ToUpper());
                    foreach (var acesso in acessos)
                    {
                        permissaoTodos = $"{(int)acesso._Funcionalidade}-{(int)TipoDePermissao.Todos}".ToUpper();
                        permissaoComposta = $"{(int)acesso._Funcionalidade}-{((int)acesso._TipoDePermissao)}".ToUpper();

                        if (funcoes.Any(c => (string.Compare(c.Value, permissaoTodos, true) == 0 || string.Compare(c.Value, permissaoComposta, true) == 0)))
                        {
                            permissao = true;
                            break;
                        }
                    }

                    if (!permissao)
                    {
                        context.Result = new ForbidResult();
                    }
                }
            }
        }
    }
}
