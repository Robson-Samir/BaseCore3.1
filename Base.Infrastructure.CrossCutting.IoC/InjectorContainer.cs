using Microsoft.Extensions.DependencyInjection;
using Base.Application.Services.Interfaces;
using Base.Application.Services.AppServices;
using Base.Domain.Interfaces.Services;
using Base.Domain.Service;
using Base.Domain.Interfaces.Repositories;
using Base.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Base.Infrastructure.CrossCutting.Utilities;

namespace Base.Infrastructure.CrossCutting.IoC
{
    public class InjectorContainer
    {
        public IServiceCollection ObterScopo(IServiceCollection interfaceService, IConfiguration Configuration)
        {
            #region AppService

            interfaceService.AddScoped(typeof(IFluxoAppService), typeof(FluxoAppService));
            interfaceService.AddScoped(typeof(IPedidoAppService), typeof(PedidoAppService));

            #endregion

            #region Service

            interfaceService.AddScoped(typeof(IFluxoService), typeof(FluxoService));
            interfaceService.AddScoped(typeof(IPedidoService), typeof(PedidoService));

            #endregion

            #region Repository

            interfaceService.AddScoped(typeof(IFluxoRepository), typeof(FluxoRepository));
            interfaceService.AddScoped(typeof(IPedidoRepository), typeof(PedidoRepository));

            #endregion

            #region Configuração

            interfaceService.AddSingleton<IConfiguration>(Configuration);
            interfaceService.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion
            Constants.serviceProvider = interfaceService.BuildServiceProvider();
            return interfaceService;
        }
    }
}
