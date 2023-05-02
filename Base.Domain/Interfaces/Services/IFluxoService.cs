using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;
using Base.Infrastructure.CrossCutting.Enums;

namespace Base.Domain.Interfaces.Services
{
    public interface IFluxoService
    {
        bool Pagamento(Fluxo fluxo);
        FluxoSearch RelatorioConsolidado();
    }
}
