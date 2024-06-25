using Base.Domain.Entities.Domain;
using Base.Domain.Interfaces.Repositories;
using Base.Domain.Interfaces.Services;

namespace Base.Domain.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoService(IPedidoRepository _pedidoRepository)
        {
            pedidoRepository = _pedidoRepository;
        }

        public bool CadastroPedido(Pedido pedido)
        {
            return pedidoRepository.CadastroPedido(pedido);
        }

        public bool CadastroUsuario(Usuario usuario)
        {
            return pedidoRepository.CadastroUsuario(usuario);
        }
    }
}
