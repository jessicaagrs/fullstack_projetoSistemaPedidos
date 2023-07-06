using API.Models;
using API.Models.Tributacao;
using Microsoft.EntityFrameworkCore;


namespace API.Infra.Tributacao
{
    public class TributacaoRepositorio : ITributacaoRepositorio
    {
        private readonly EFDBContext _dbContext;

        public TributacaoRepositorio(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Tributacoes Adicionar(Tributacoes tributacao)
        {
            _dbContext.Tributacao.Add(tributacao);
            _dbContext.SaveChanges();
            return tributacao;
        }

        public Tributacoes Atualizar(Tributacoes tributacao)
        {
            _dbContext.Tributacao.Update(tributacao);
            _dbContext.SaveChanges();
            return tributacao;
        }

        public Tributacoes Remover(int tributacaoId)
        {
            var tributacao = ObterPorId(tributacaoId);

            if (tributacao != null)
            {
                _dbContext.Tributacao.Remove(tributacao);
                _dbContext.SaveChanges();
                return tributacao;
            }
            return null;
        }

        public Tributacoes ObterPorId(int tributacaoId)
        {
            var tributacao = _dbContext.Tributacao.FirstOrDefault(t => t.Id == tributacaoId);

            return tributacao;
        }

        public IEnumerable<Tributacoes> ObterTodos()
        {
            return _dbContext.Tributacao.ToList();
        }

    }

}
