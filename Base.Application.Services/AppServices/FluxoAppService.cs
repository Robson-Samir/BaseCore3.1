using Base.Application.Services.Interfaces;
using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;
using Base.Domain.Interfaces.Services;

namespace Base.Application.Services.AppServices
{
    public class FluxoAppService : IFluxoAppService
    {
        private readonly IFluxoService fluxoService;

        public FluxoAppService(IFluxoService _fluxoService)
        {
            fluxoService = _fluxoService;
        }

        public bool Pagamento(Fluxo fluxo)
        {
            return fluxoService.Pagamento(fluxo);
        }

        public FluxoSearch RelatorioConsolidado()
        {
            return fluxoService.RelatorioConsolidado();
        }
    }
}
