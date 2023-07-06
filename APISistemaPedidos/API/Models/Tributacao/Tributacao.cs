using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Models.TipoDespesa;

namespace API.Models.Tributacao
{
    public class Tributacoes
    {
        [Key]
        public int Id { get; set; }
        public string Ncm { get; set; }
        public decimal AliquotaImposto { get; set; }
        public string Descricao { get; set; }
    }
}
