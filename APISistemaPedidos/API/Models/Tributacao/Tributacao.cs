using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
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

        public void Validar()
        {
            if (Ncm.Length == 0 || Descricao.Length == 0)
                throw new Exception("NCM ou descrição não foram informados.");

            if (AliquotaImposto == 0)
                throw new Exception("É necessário informar uma alíquota de impostos para a NCM.");
        }
    }
}
