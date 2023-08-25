using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Models.Produto;

namespace API.Models.Pedido
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public List<Produtos> ProdutosPedido { get; set; }

        public void Validar()
        {
            if (Descricao.Length == 0)
                throw new Exception("Uma descrição precisa ser informada");

            if (Valor == 0 || ProdutosPedido.Count == 0) 
                throw new Exception("Um valor e pelo menos um produto devem ser informados.");

        }
    }
}
