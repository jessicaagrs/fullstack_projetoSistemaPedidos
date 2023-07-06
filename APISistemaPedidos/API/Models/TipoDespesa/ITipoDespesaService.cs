using System.Collections.Generic;

namespace API.Models.TipoDespesa
{
    public interface ITipoDespesaService
    {
        TipoDespesas Adicionar(TipoDespesas tipoDespesa);
        TipoDespesas Atualizar(TipoDespesas tipoDespesa);
        TipoDespesas Remover(int tipoDespesaId);
        IEnumerable<TipoDespesas> ObterTodos();
    }
}
