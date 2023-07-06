using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Models.TipoDespesa;

namespace API.Models.Fornecedor
{
    public class Fornecedores
    {
        [Key]
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }

        [ForeignKey("TipoDespesas")]
        public int TipoDespesaId { get; set; }
    }
}
