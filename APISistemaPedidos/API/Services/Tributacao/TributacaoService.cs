using API.Models.Fornecedor;
using API.Models.Produto;
using API.Models.Tributacao;
using System.Text.RegularExpressions;

namespace API.Services.Tributacao
{
    public class TributacaoService : ITributacaoService
    {
        private readonly ITributacaoRepositorio _tributacaoRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public TributacaoService(ITributacaoRepositorio fornecedorRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _tributacaoRepositorio = fornecedorRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public Tributacoes Adicionar(Tributacoes tributacao)
        {
            if (tributacao is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var ncmValido = ValidarNcmTributacao(tributacao);
            if (!ncmValido)
                throw new Exception("A quantidade de caracteres de NCM é inválido");

            var tributacoes = _tributacaoRepositorio.Adicionar(tributacao);
            return tributacoes;
        }

        public Tributacoes Atualizar(Tributacoes tributacao)
        {
            if (tributacao is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var ncmValido = ValidarNcmTributacao(tributacao);
            if (!ncmValido)
                throw new Exception("A quantidade de caracteres de NCM é inválido");

            var tributacoes = _tributacaoRepositorio.Atualizar(tributacao);
            return tributacoes;
        }

        public Tributacoes Remover(int tributacaoId)
        {
            var tributacaoEmUso = EmUso(tributacaoId);
            if (!tributacaoEmUso)
                throw new Exception("O produto está vinculado a um pedido e não pode ser removido");

            if (tributacaoId > 0)
            {
                var tributacao = _tributacaoRepositorio.Remover(tributacaoId);
                return tributacao;
            }
            return null;

        }

        public IEnumerable<Tributacoes> ObterTodos()
        {
            return _tributacaoRepositorio.ObterTodos();
        }

        private bool EmUso(int tributacaoId)
        {
            var tributacaoEmUso = _produtoRepositorio.ObterTodos().Where(p => p.Tributacoes?.Id == tributacaoId).Any();
            if (tributacaoEmUso) return true; return false;
        }

        private bool ValidarNcmTributacao(Tributacoes tributacao)
        {
            string ncmNumeros = Regex.Replace(tributacao.Ncm, @"[.\-/]", "");

            if (ncmNumeros.Length == 8 ) return true; return false;
        }

    }
}
