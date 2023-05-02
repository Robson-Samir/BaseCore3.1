using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;
using Base.Domain.Interfaces;
using Base.Domain.Interfaces.Repositories;
using Base.Infrastructure.Data.Contexts;
using Base.Infrastructure.Data.UnitOfWork;

namespace Base.Infrastructure.Data.Repository
{
    public class FluxoRepository : UnitOfWork<FluxoSearch>, IUnitOfWork<FluxoSearch>, IFluxoRepository
    {
        public FluxoRepository(DataContext context)
            : base(context)
        {
        }

        public bool Pagamento(Fluxo fluxo)
        {
            return true;
        }

        public FluxoSearch RelatorioConsolidado()
        {
            return new FluxoSearch();
        }
    }
}
