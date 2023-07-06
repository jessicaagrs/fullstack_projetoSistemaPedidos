using System.Collections.Generic;

namespace API.Models.Fornecedor
{
    public interface IFornecedorService
    {
        Fornecedores Adicionar(Fornecedores fornecedor);
        Fornecedores Atualizar(Fornecedores fornecedor);
        Fornecedores Remover(int fornecedorId);
        IEnumerable<Fornecedores> ObterTodos();
    }
}
