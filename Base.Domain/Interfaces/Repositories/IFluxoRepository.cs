using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;

namespace Base.Domain.Interfaces.Repositories
{
    public interface IFluxoRepository
    {
        bool Pagamento(Fluxo fluxo);
        FluxoSearch RelatorioConsolidado();
    }
}
