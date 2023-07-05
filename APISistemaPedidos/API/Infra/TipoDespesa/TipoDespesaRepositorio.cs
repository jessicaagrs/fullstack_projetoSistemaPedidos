using API.Models;
using API.Models.TipoDespesa;
using Microsoft.EntityFrameworkCore;


namespace API.Infra.TipoDespesa
{
    public class TipoDespesaRepositorio : ITipoDespesaRepositorio
    {
        private readonly EFDBContext _dbContext;

        public TipoDespesaRepositorio(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TipoDespesas Adicionar(TipoDespesas tipoDespesa)
        {
            _dbContext.TipoDespesa.Add(tipoDespesa);
            _dbContext.SaveChanges();
            return tipoDespesa;
        }

        public TipoDespesas Atualizar(TipoDespesas tipoDespesa)
        {
            _dbContext.TipoDespesa.Update(tipoDespesa);
            _dbContext.SaveChanges();
            return tipoDespesa;
        }

        public TipoDespesas Remover(int tipoDespesaId)
        {
            var tipoDespesa = ObterPorId(tipoDespesaId);

            if (tipoDespesa != null)
            {
                _dbContext.TipoDespesa.Remove(tipoDespesa);
                _dbContext.SaveChanges();
                return tipoDespesa;
            }
            return null;
        }

        public TipoDespesas ObterPorId(int tipoDespesaId)
        {
            var tipoDespesa = _dbContext.TipoDespesa.FirstOrDefault(t => t.Id == tipoDespesaId);

            return tipoDespesa;
        }

        public IEnumerable<TipoDespesas> ObterTodos()
        {
            return _dbContext.TipoDespesa.ToList();
        }

    }

}
