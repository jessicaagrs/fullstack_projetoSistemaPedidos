using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Models.Fornecedor;
using API.Models.Tributacao;

namespace API.Models.Produto
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public int FornecedorId { get; set; }

        [ForeignKey("FornecedorId")]
        public Fornecedores? Fornecedores { get; set; }

        public int TributacaoId { get; set; }

        [ForeignKey("TributacaoId")]
        public Tributacoes? Tributacoes { get; set; }
    }
}
