using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;
using Base.Domain.Interfaces.Repositories;
using Base.Domain.Interfaces.Services;

namespace Base.Domain.Service
{
    public class FluxoService : IFluxoService
    {
        private readonly IFluxoRepository fluxoRepository;

        public FluxoService(IFluxoRepository _fluxoRepository)
        {
            fluxoRepository = _fluxoRepository;
        }

        public bool Pagamento(Fluxo fluxo)
        {
            return fluxoRepository.Pagamento(fluxo);
        }

        public FluxoSearch RelatorioConsolidado()
        {
            return fluxoRepository.RelatorioConsolidado();
        }
    }
}
