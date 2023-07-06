using API.Models.Tributacao;

namespace API.Services.Tributacao
{
    public class TributacaoService : ITributacaoService
    {
        private readonly ITributacaoRepositorio _tributacaoRepositorio;

        public TributacaoService(ITributacaoRepositorio fornecedorRepositorio)
        {
            _tributacaoRepositorio = fornecedorRepositorio;
        }

        public Tributacoes Adicionar(Tributacoes tributacao)
        {
            if (tributacao is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var tributacoes = _tributacaoRepositorio.Adicionar(tributacao);
            return tributacoes;
        }

        public Tributacoes Atualizar(Tributacoes tributacao)
        {
            if (tributacao is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var tributacoes = _tributacaoRepositorio.Atualizar(tributacao);
            return tributacoes;
        }

        public Tributacoes Remover(int fornecedorId)
        {
            if (fornecedorId > 0)
            {
                var tributacoes = _tributacaoRepositorio.Remover(fornecedorId);
                return tributacoes;
            }
            return null;

        }

        public IEnumerable<Tributacoes> ObterTodos()
        {
            return _tributacaoRepositorio.ObterTodos();
        }

    }
}
