using System.ComponentModel.DataAnnotations;

namespace API.Models.TipoDespesa
{
    public class TipoDespesas
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Grupo { get; set; }

        public void Validar()
        {
            if (Descricao.Length == 0 || Grupo.Length == 0)
                throw new Exception("A descrição e grupo são obrigatórios.");
        }
    }
}
