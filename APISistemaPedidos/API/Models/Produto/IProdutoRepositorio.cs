using System;
using System.Collections.Generic;

namespace API.Models.Produto
{
    public interface IProdutoRepositorio
    {
        Produtos Adicionar(Produtos produto);
        Produtos Atualizar(Produtos produto);
        Produtos Remover(int produtoId);
        Produtos ObterPorId(int produtoId);
        IEnumerable<Produtos> ObterTodos();
    }
}
