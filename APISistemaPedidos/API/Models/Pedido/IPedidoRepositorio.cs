using System;
using System.Collections.Generic;

namespace API.Models.Pedido
{
    public interface IPedidoRepositorio
    {
        Pedidos Adicionar(Pedidos pedido);
        Pedidos Atualizar(Pedidos pedido);
        Pedidos Remover(int pedidoId);
        Pedidos ObterPorId(int pedidoId);
        IEnumerable<Pedidos> ObterTodos();
    }
}
