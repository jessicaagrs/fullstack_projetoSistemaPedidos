using API.Models.Fornecedor;
using API.Models.Pedido;
using API.Models.Produto;
using API.Models.TipoDespesa;
using API.Models.Tributacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;


namespace API.Models
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }
        public DbSet<TipoDespesas> TipoDespesa { get; set; }
        public DbSet<Fornecedores> Fornecedor { get; set; }
        public DbSet<Tributacoes> Tributacao { get; set; }
        public DbSet<Produtos> Produto { get; set; }
        public DbSet<Pedidos> Pedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BC-Teste");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
