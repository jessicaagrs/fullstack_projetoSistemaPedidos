﻿using API.Models.Pedido;
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

            var produtoExiste = ValidarProduto(pedido.ProdutoId);

            if (!produtoExiste)
                throw new Exception("Produto não é válido.");

            var pedidos = _pedidoRepositorio.Adicionar(pedido);
            return pedidos;
        }

        public Pedidos Atualizar(Pedidos pedido)
        {
            if (pedido is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var produtoExiste = ValidarProduto(pedido.ProdutoId);

            if (!produtoExiste)
                throw new Exception("Produto não é válido.");

            var pedidos = _pedidoRepositorio.Atualizar(pedido);
            return pedidos;
        }

        public Pedidos Remover(int pedidoId)
        {
            if (pedidoId > 0)
            {
                var pedidos = _pedidoRepositorio.Remover(pedidoId);
                return pedidos;
            }
            return null;

        }

        public IEnumerable<Pedidos> ObterTodos()
        {
            return _pedidoRepositorio.ObterTodos();
        }

        public bool ValidarProduto(int produtoId)
        {
            var produtos = _produtoRepositorio.ObterTodos().ToList();
            return produtos.Any(td => td.Id == produtoId);
        }

    }
}
