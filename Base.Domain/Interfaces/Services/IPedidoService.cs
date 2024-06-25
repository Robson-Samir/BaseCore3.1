using Base.Domain.Entities.Domain;

namespace Base.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        bool CadastroUsuario(Usuario usuario);
        bool CadastroPedido(Pedido pedido);
    }
}
