using API.Models.Pedido;
using API.Models.Produto;

namespace API.Services.Produto
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public PedidoService(IPedidoRepositorio pedidoRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public Pedidos Adicionar(Pedidos pedido)
        {
            if (pedido is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            //var teste = _produtoRepositorio.ObterTodos().FirstOrDefault(t => t.Id == 1);
            //pedido.ProdutosPedido.Add(teste);

            if (pedido.ProdutosPedido != null)
                ValidarProdutos(pedido.ProdutosPedido);

            var pedidos = _pedidoRepositorio.Adicionar(pedido);
            return pedidos;
        }

        public Pedidos Atualizar(Pedidos pedido)
        {
            if (pedido is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            if (pedido.ProdutosPedido != null)
                ValidarProdutos(pedido.ProdutosPedido);

            var pedidos = _pedidoRepositorio.Atualizar(pedido);
            return pedidos;
        }

        public Pedidos Remover(int pedidoId)
        {
            if (pedidoId > 0)
            {
                var pedido = _pedidoRepositorio.Remover(pedidoId);
                return pedido;
            }
            return null;

        }

        public IEnumerable<Pedidos> ObterTodos()
        {
            return _pedidoRepositorio.ObterTodos();
        }

        private void ValidarProdutos(List<Produtos> produtos)
        {
            if (produtos != null)
            {
                var produtosExistentes = _produtoRepositorio.ObterTodos();
                foreach (var produto in produtos)
                {
                    var existe = produtosExistentes.FirstOrDefault(p => p.Descricao == produto.Descricao);
                    if (existe == null)
                        throw new Exception($"Produto não existente na base de dados {produto.Descricao}");
                }
            }
        }

    }
}
