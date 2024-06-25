using Base.Application.Services.Interfaces;
using Base.Domain.Entities.Domain;
using Base.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Base.Application.Api.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoAppService appAppService;

        public PedidoController(IPedidoAppService pedidoAppService)
        {
            appAppService = pedidoAppService;
        }

        [Route("cadpedido")]
        [HttpPost]
        public ResultadoOperacao<bool> CadastroPedido(Pedido pedido)
        {
            var resull = appAppService.CadastroPedido(pedido);
            return new ResultadoOperacao<bool>(resull);
        }

        [Route("caduser")]
        [HttpGet]
        public ResultadoPesquisa<bool>  CadastroUsuario(Usuario usuario)
        {
            var result = appAppService.CadastroUsuario(usuario);
            return new ResultadoPesquisa<bool>(result);
        }
    }
}
