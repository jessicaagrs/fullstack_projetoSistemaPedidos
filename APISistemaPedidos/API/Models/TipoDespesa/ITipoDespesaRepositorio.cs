using System;
using System.Collections.Generic;

namespace API.Models.TipoDespesa
{
    public interface ITipoDespesaRepositorio
    {
        TipoDespesas Adicionar(TipoDespesas tipoDespesa);
        TipoDespesas Atualizar(TipoDespesas tipoDespesa);
        TipoDespesas Remover(int tipoDespesaId);
        TipoDespesas ObterPorId (int tipoDespesaId);
        IEnumerable<TipoDespesas> ObterTodos();
    }
}
