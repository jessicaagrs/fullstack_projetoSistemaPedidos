using API.Models.Fornecedor;
using API.Models.Pedido;
using API.Models.Produto;
using API.Models.Tributacao;

namespace API.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly ITributacaoRepositorio _tributacaoRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio, IFornecedorRepositorio fornecedorRepositorio, ITributacaoRepositorio tributacaoRepositorio, IPedidoRepositorio pedidoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
            _tributacaoRepositorio = tributacaoRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
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
            var produtoEmUso = EmUso(produtoId);
            if (!produtoEmUso)
                throw new Exception("O produto está vinculado a um pedido e não pode ser removido");

            if (produtoId > 0)
            {
                var produto = _produtoRepositorio.Remover(produtoId);
                return produto;
            }
            return null;
        }

        public IEnumerable<Produtos> ObterTodos()
        {
            return _produtoRepositorio.ObterTodos();
        }

        private bool ValidarFornecedor(int fornecedorId)
        {
            var fornecedorExiste = _fornecedorRepositorio.ObterTodos().Any(td => td.Id == fornecedorId);
            return fornecedorExiste;
        }

        private bool ValidarTributacao(int tributacaoId)
        {
            var tributacaoExiste = _tributacaoRepositorio.ObterTodos().Any(td => td.Id == tributacaoId);
            return tributacaoExiste;
        }

        private bool EmUso(int produtoId)
        {
            var produtoEmUso = _pedidoRepositorio.ObterTodos()
                .Any(p => p.ProdutosPedido.Any(x => x.Id == produtoId));

            return produtoEmUso;
        }
    }
}
