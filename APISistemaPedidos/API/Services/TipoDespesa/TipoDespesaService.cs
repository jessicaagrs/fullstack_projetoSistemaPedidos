using API.Models.Fornecedor;
using API.Models.TipoDespesa;

namespace API.Services.TipoDespesa
{
    public class TipoDespesaService : ITipoDespesaService
    {
        private readonly ITipoDespesaRepositorio _tipoDespesaRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public TipoDespesaService(ITipoDespesaRepositorio tipoDespesaRepositorio, IFornecedorRepositorio fornecedorRepositorio)
        {
            _tipoDespesaRepositorio = tipoDespesaRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        public TipoDespesas Adicionar(TipoDespesas tipoDespesa)
        {
            if (tipoDespesa is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            tipoDespesa.Validar();
           var tipoDespesas =  _tipoDespesaRepositorio.Adicionar(tipoDespesa);
            return tipoDespesas;
        }

        public TipoDespesas Atualizar(TipoDespesas tipoDespesa)
        {
            if (tipoDespesa is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            tipoDespesa.Validar();
            var tipoDespesas = _tipoDespesaRepositorio.Atualizar(tipoDespesa);
            return tipoDespesas;
        }

        public TipoDespesas Remover(int tipoDespesaId)
        {
            var despesaVinculada = EmUso(tipoDespesaId);
            if (despesaVinculada)
                throw new Exception("A despesa está vinculada a um fornecedor e não pode ser removida.");

            if (tipoDespesaId > 0)
            {
                var tipoDespesa = _tipoDespesaRepositorio.Remover(tipoDespesaId);
                return tipoDespesa;
            }
            return null;
                
        }

        public IEnumerable<TipoDespesas> ObterTodos()
        {
            return _tipoDespesaRepositorio.ObterTodos();
        }

        private bool EmUso(int despesaId)
        {
            var despesaEmUso = _fornecedorRepositorio.ObterTodos().Where(f => f.TipoDespesaId == despesaId).Any();
            if (despesaEmUso) return true; return false;
        }
    }
}
