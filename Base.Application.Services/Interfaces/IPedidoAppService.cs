using Base.Domain.Entities.Domain;

namespace Base.Application.Services.Interfaces
{
    public interface IPedidoAppService
    {
        bool CadastroUsuario(Usuario usuario);
        bool CadastroPedido(Pedido usuario);
    }
}
