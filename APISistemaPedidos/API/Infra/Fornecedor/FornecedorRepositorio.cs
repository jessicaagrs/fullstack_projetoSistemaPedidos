using API.Models;
using API.Models.Fornecedor;
using Microsoft.EntityFrameworkCore;


namespace API.Infra.Fornecedor
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly EFDBContext _dbContext;

        public FornecedorRepositorio(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Fornecedores Adicionar(Fornecedores fornecedor)
        {
            _dbContext.Fornecedor.Add(fornecedor);
            _dbContext.SaveChanges();
            return fornecedor;
        }

        public Fornecedores Atualizar(Fornecedores fornecedor)
        {
            _dbContext.Fornecedor.Update(fornecedor);
            _dbContext.SaveChanges();
            return fornecedor;
        }

        public Fornecedores Remover(int fornecedorId)
        {
            var fornecedor = ObterPorId(fornecedorId);

            if (fornecedor != null)
            {
                _dbContext.Fornecedor.Remove(fornecedor);
                _dbContext.SaveChanges();
                return fornecedor;
            }
            return null;
        }

        public Fornecedores ObterPorId(int fornecedorId)
        {
            var fornecedor = _dbContext.Fornecedor.FirstOrDefault(t => t.Id == fornecedorId);

            return fornecedor;
        }

        public IEnumerable<Fornecedores> ObterTodos()
        {
            return _dbContext.Fornecedor.Include(f => f.Despesa).ToList();
        }

    }

}
