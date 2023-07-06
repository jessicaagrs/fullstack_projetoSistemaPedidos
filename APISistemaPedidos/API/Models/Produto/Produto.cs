using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Models.TipoDespesa;

namespace API.Models.Produto
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("Fornecedores")]
        public int FornecedorId { get; set; }

        [ForeignKey("Tributacoes")]
        public int TributacaoId { get; set; }
    }
}
