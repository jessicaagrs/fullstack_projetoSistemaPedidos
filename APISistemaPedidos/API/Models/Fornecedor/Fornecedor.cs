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
        public int TipoDespesaId { get; set; }

        [ForeignKey("TipoDespesaId")]
        public TipoDespesas? Despesa { get; set; }

        public void Validar()
        {
            if (RazaoSocial.Length == 0 || Cnpj.Length == 0)
                throw new Exception("Razão Social ou CNPJ não foram preenchidos.");

            if (TipoDespesaId == 0)
                throw new Exception("É necessário vincular uma despesa ao fornecedor.");
        }
    }
}
