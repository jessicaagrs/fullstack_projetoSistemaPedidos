using API.Models.Pedido;

namespace API.Models.Pedido
{
    public interface IPedidoService
    {
        Pedidos Adicionar(Pedidos pedido);
        Pedidos Atualizar(Pedidos pedido);
        Pedidos Remover(int pedidoId);
        IEnumerable<Pedidos> ObterTodos();
    }
}
