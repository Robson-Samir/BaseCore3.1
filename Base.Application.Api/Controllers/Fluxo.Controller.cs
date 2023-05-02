using Base.Application.Services.Interfaces;
using Base.Domain.Entities.Domain;
using Base.Domain.Entities.Search;
using Base.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Base.Application.Api.Controllers
{
    [Route("api/fluxo")]
    [ApiController]
    public class FluxoController : ControllerBase
    {
        private IFluxoAppService fluxoAppService;

        public FluxoController(IFluxoAppService _fluxoAppService)
        {
            fluxoAppService = _fluxoAppService; 
        }

        [Route("lancamento")]
        [HttpPost]
        public ResultadoOperacao<bool> Pagamento(Fluxo fluxo)
        {
            var pagamento = fluxoAppService.Pagamento(fluxo);
            return new ResultadoOperacao<bool>(pagamento);
        }

        [Route("relatorio")]
        [HttpGet]
        public ResultadoPesquisa<FluxoSearch> RelatorioConsolidado()
        {
            var relatorio = fluxoAppService.RelatorioConsolidado();
            return new ResultadoPesquisa<FluxoSearch>(relatorio);
        }
    }
}
