using API.Models;
using API.Models.Produto;
using Microsoft.EntityFrameworkCore;


namespace API.Infra.Produto
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly EFDBContext _dbContext;

        public ProdutoRepositorio(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Produtos Adicionar(Produtos produto)
        {
            _dbContext.Produto.Add(produto);
            _dbContext.SaveChanges();
            return produto;
        }

        public Produtos Atualizar(Produtos produto)
        {
            _dbContext.Produto.Update(produto);
            _dbContext.SaveChanges();
            return produto;
        }

        public Produtos Remover(int produtoId)
        {
            var produto = ObterPorId(produtoId);

            if (produto != null)
            {
                _dbContext.Produto.Remove(produto);
                _dbContext.SaveChanges();
                return produto;
            }
            return null;
        }

        public Produtos ObterPorId(int produtoId)
        {
            var produto = _dbContext.Produto.FirstOrDefault(t => t.Id == produtoId);

            return produto;
        }

        public IEnumerable<Produtos> ObterTodos()
        {
            return _dbContext.Produto.Include(p => p.Tributacoes).Include(p => p.Fornecedores).ToList();
        }

    }

}
