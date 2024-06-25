using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;

namespace Base.Domain.Interfaces.Services
{
    public interface IFluxoService
    {
        bool Pagamento(Fluxo fluxo);
        FluxoSearch RelatorioConsolidado();
    }
}
