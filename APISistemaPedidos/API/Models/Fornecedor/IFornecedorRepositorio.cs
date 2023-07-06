using System;
using System.Collections.Generic;

namespace API.Models.Fornecedor
{
    public interface IFornecedorRepositorio
    {
        Fornecedores Adicionar(Fornecedores fornecedor);
        Fornecedores Atualizar(Fornecedores fornecedor);
        Fornecedores Remover(int fornecedorId);
        Fornecedores ObterPorId (int fornecedorId);
        IEnumerable<Fornecedores> ObterTodos();
    }
}
