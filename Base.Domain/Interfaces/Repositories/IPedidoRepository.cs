using Base.Domain.Entities.Domain;

namespace Base.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        bool CadastroUsuario(Usuario usuario);
        bool CadastroPedido(Pedido pedido);
    }
}
