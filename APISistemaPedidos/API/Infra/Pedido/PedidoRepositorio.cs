using API.Models;
using API.Models.Pedido;
using Microsoft.EntityFrameworkCore;


namespace API.Infra.Pedido
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly EFDBContext _dbContext;

        public PedidoRepositorio(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pedidos Adicionar(Pedidos pedido)
        {
            _dbContext.Pedido.Add(pedido);
            _dbContext.SaveChanges();
            return pedido;
        }

        public Pedidos Atualizar(Pedidos pedido)
        {
            _dbContext.Pedido.Update(pedido);
            _dbContext.SaveChanges();
            return pedido;
        }

        public Pedidos Remover(int pedidoId)
        {
            var pedido = ObterPorId(pedidoId);

            if (pedido != null)
            {
                _dbContext.Pedido.Remove(pedido);
                _dbContext.SaveChanges();
                return pedido;
            }
            return null;
        }

        public Pedidos ObterPorId(int pedidoId)
        {
            var pedido = _dbContext.Pedido.FirstOrDefault(t => t.Id == pedidoId);

            return pedido;
        }

        public IEnumerable<Pedidos> ObterTodos()
        {
            return _dbContext.Pedido.ToList();
        }

    }

}
