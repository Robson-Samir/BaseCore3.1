using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;
using Base.Domain.Interfaces;
using Base.Domain.Interfaces.Repositories;
using Base.Infrastructure.CrossCutting.Utilities;
using Base.Infrastructure.Data.Contexts;
using Base.Infrastructure.Data.UnitOfWork;
using System.Net;

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
            if (fluxo == null)
                throw new PortalHttpException(HttpStatusCode.BadRequest, "Valor não pode ser nulo");

            return true;
        }

        public FluxoSearch RelatorioConsolidado()
        {
            return new FluxoSearch();
        }
    }
}
