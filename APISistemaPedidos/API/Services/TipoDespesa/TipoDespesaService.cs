using API.Models.TipoDespesa;
using API.Models.TipoDespesa.TipoDespesa;

namespace API.Services.TipoDespesa
{
    public class TipoDespesaService : ITipoDespesaService
    {
        private readonly ITipoDespesaRepositorio _tipoDespesaRepositorio;

        public TipoDespesaService(ITipoDespesaRepositorio tipoDespesaRepositorio)
        {
            _tipoDespesaRepositorio = tipoDespesaRepositorio;
        }

        public TipoDespesas Adicionar(TipoDespesas tipoDespesa)
        {
            if (tipoDespesa is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

           var tipoDespesas =  _tipoDespesaRepositorio.Adicionar(tipoDespesa);
            return tipoDespesas;
        }

        public TipoDespesas Atualizar(TipoDespesas tipoDespesa)
        {
            if (tipoDespesa is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

           var tipoDespesas = _tipoDespesaRepositorio.Atualizar(tipoDespesa);
            return tipoDespesas;
        }

        public TipoDespesas Remover(int tipoDespesaId)
        {
            if (tipoDespesaId > 0)
            {
                var tipoDespesas = _tipoDespesaRepositorio.Remover(tipoDespesaId);
                return tipoDespesas;
            }
            return null;
                
        }

        public IEnumerable<TipoDespesas> ObterTodos()
        {
            return _tipoDespesaRepositorio.ObterTodos();
        }

    }
}
