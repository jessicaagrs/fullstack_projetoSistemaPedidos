using API.Models.Fornecedor;
using API.Models.Produto;
using API.Models.Tributacao;

namespace API.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly ITributacaoRepositorio _tributacaoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio, IFornecedorRepositorio fornecedorRepositorio, ITributacaoRepositorio tributacaoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
            _tributacaoRepositorio = tributacaoRepositorio;
        }

        public Produtos Adicionar(Produtos produto)
        {
            if (produto is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var fornecedorExiste = ValidarFornecedor(produto.FornecedorId);
            var tributacaoExiste = ValidarTributacao(produto.TributacaoId);

            if (!fornecedorExiste)
                throw new Exception("Fornecedor não é válido.");

            if (!tributacaoExiste)
                throw new Exception("Tributação não é válida.");

            var produtos = _produtoRepositorio.Adicionar(produto);
            return produtos;
        }

        public Produtos Atualizar(Produtos produto)
        {
            if (produto is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var fornecedorExiste = ValidarFornecedor(produto.FornecedorId);
            var tributacaoExiste = ValidarTributacao(produto.TributacaoId);

            if (!fornecedorExiste)
                throw new Exception("Fornecedor não é válido.");

            if (!tributacaoExiste)
                throw new Exception("Tributação não é válida.");

            var produtos = _produtoRepositorio.Atualizar(produto);
            return produtos;
        }

        public Produtos Remover(int produtoId)
        {
            if (produtoId > 0)
            {
                var produtos = _produtoRepositorio.Remover(produtoId);
                return produtos;
            }
            return null;

        }

        public IEnumerable<Produtos> ObterTodos()
        {
            return _produtoRepositorio.ObterTodos();
        }

        public bool ValidarFornecedor(int fornecedorId)
        {
            var fornecedores = _fornecedorRepositorio.ObterTodos().ToList();
            return fornecedores.Any(td => td.Id == fornecedorId);
        }

        public bool ValidarTributacao(int tributacaoId)
        {
            var tributacoes = _tributacaoRepositorio.ObterTodos().ToList();
            return tributacoes.Any(td => td.Id == tributacaoId);
        }

    }
}
