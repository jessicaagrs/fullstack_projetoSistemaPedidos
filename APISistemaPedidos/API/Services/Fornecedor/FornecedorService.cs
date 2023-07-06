using API.Models.Fornecedor;
using API.Models.TipoDespesa;

namespace API.Services.Fornecedor
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly ITipoDespesaRepositorio _tipoDespesaRepositorio;

        public FornecedorService(IFornecedorRepositorio fornecedorRepositorio, ITipoDespesaRepositorio tipoDespesaRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
            _tipoDespesaRepositorio = tipoDespesaRepositorio;
        }

        public Fornecedores Adicionar(Fornecedores fornecedor)
        {
            if (fornecedor is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var tipoDespesaValida = ValidarTipoDespesa(fornecedor.TipoDespesaId);

            if (!tipoDespesaValida)
                throw new Exception("Despesa inválida.");

            var fornecedores = _fornecedorRepositorio.Adicionar(fornecedor);
            return fornecedores;
        }

        public Fornecedores Atualizar(Fornecedores fornecedor)
        {
            if (fornecedor is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var tipoDespesaValida = ValidarTipoDespesa(fornecedor.TipoDespesaId);

            if (!tipoDespesaValida)
                throw new Exception("Despesa inválida.");

            var fornecedores = _fornecedorRepositorio.Atualizar(fornecedor);
            return fornecedores;
        }

        public Fornecedores Remover(int fornecedorId)
        {
            if (fornecedorId > 0)
            {
                var fornecedores = _fornecedorRepositorio.Remover(fornecedorId);
                return fornecedores;
            }
            return null;

        }

        public IEnumerable<Fornecedores> ObterTodos()
        {
            return _fornecedorRepositorio.ObterTodos();
        }

        public bool ValidarTipoDespesa(int tipoDespesaId)
        {
            var tipoDespesas = _tipoDespesaRepositorio.ObterTodos().ToList();
            return tipoDespesas.Any(td => td.Id == tipoDespesaId);
        }

    }
}
