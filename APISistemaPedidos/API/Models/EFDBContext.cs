using API.Models.Fornecedor;
using API.Models.TipoDespesa;
using API.Models.Tributacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;


namespace API.Models
{
    public class EFDBContext : DbContext
    {
        public DbSet<TipoDespesas> TipoDespesa { get; set; }
        public DbSet<Fornecedores> Fornecedor { get; set; }
        public DbSet<Tributacoes> Tributacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BC-Teste");
        }
    }
}
