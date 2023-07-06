using System.ComponentModel.DataAnnotations;

namespace API.Models.TipoDespesa
{
    public class TipoDespesas
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

        public string Grupo { get; set; }

    }
}
