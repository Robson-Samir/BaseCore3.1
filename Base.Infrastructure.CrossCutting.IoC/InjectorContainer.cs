using Microsoft.Extensions.DependencyInjection;
using Base.Application.Services.Interfaces;
using Base.Application.Services.AppServices;
using Base.Domain.Interfaces.Services;
using Base.Domain.Service;
using Base.Domain.Interfaces.Repositories;
using Base.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Base.Infrastructure.CrossCutting.IoC
{
    public class InjectorContainer
    {
        public IServiceCollection ObterScopo(IServiceCollection interfaceService, IConfiguration Configuration)
        {
            #region AppService

            interfaceService.AddScoped(typeof(IFluxoAppService), typeof(FluxoAppService));

            #endregion

            #region Service

            interfaceService.AddScoped(typeof(IFluxoService), typeof(FluxoService));

            #endregion

            #region Repository

            interfaceService.AddScoped(typeof(IFluxoRepository), typeof(FluxoRepository));

            #endregion

            #region Configuração

            interfaceService.AddSingleton<IConfiguration>(Configuration);
            interfaceService.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            return interfaceService;
        }
    }
}
