using System;
using System.Collections.Generic;

namespace API.Models.Tributacao
{
    public interface ITributacaoRepositorio
    {
        Tributacoes Adicionar(Tributacoes tributacao);
        Tributacoes Atualizar(Tributacoes tributacao);
        Tributacoes Remover(int tributacaoId);
        Tributacoes ObterPorId(int tributacaoId);
        IEnumerable<Tributacoes> ObterTodos();
    }
}
