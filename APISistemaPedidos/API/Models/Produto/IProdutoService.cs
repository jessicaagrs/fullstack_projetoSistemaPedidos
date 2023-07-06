using System.Collections.Generic;

namespace API.Models.Produto
{
    public interface IProdutoService
    {
        Produtos Adicionar(Produtos produto);
        Produtos Atualizar(Produtos produto);
        Produtos Remover(int produtoId);
        IEnumerable<Produtos> ObterTodos();
    }
}
