using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;

namespace Base.Application.Services.Interfaces
{
    public interface IFluxoAppService
    {
        bool Pagamento(Fluxo fluxo);
        FluxoSearch RelatorioConsolidado();
    }
}
