using Base.Application.Services.Interfaces;
using Base.Domain.Entities.Domain;
using Base.Domain.Interfaces.Services;

namespace Base.Application.Services.AppServices
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoService pedidoservice;

        public PedidoAppService(IPedidoService _pedidoService)
        {
            pedidoservice = _pedidoService;     
        }

        public bool CadastroPedido(Pedido pedido)
        {
            return pedidoservice.CadastroPedido(pedido);
        }

        public bool CadastroUsuario(Usuario usuario)
        {
            return pedidoservice.CadastroUsuario(usuario);
        }
    }
}
