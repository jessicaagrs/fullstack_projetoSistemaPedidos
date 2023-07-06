using System.Collections.Generic;

namespace API.Models.Tributacao
{
    public interface ITributacaoService
    {
        Tributacoes Adicionar(Tributacoes tributacao);
        Tributacoes Atualizar(Tributacoes tributacao);
        Tributacoes Remover(int tributacaoId);
        IEnumerable<Tributacoes> ObterTodos();
    }
}
