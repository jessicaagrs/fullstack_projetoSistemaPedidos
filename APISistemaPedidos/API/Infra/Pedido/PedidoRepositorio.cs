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
            foreach (var produto in pedido.ProdutosPedido)
            {
                _dbContext.Attach(produto);
            }
            _dbContext.Pedido.Add(pedido);
            _dbContext.SaveChanges();
            return pedido;
        }

        public Pedidos Atualizar(Pedidos pedido)
        {
            foreach (var produto in pedido.ProdutosPedido)
            {
                _dbContext.Attach(produto);
            }
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
            var pedidos = _dbContext.Pedido
                .Include(p => p.ProdutosPedido)
                    .ThenInclude(pp => pp.Fornecedores)
                .ToList();

            foreach (var pedido in pedidos)
            {
                foreach (var produtoPedido in pedido.ProdutosPedido)
                {
                    _dbContext.Entry(produtoPedido).Reference(pp => pp.Tributacoes).Load();
                }
            }
            return pedidos;
        }
    }
}
