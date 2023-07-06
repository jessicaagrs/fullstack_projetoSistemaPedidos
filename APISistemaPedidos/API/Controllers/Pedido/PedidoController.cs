using API.Models;
using API.Models.Pedido;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Pedido
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var pedidos = _pedidoService.ObterTodos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost()]
        public IActionResult Post([FromBody] Pedidos pedido)
        {
            try
            {
                var pedidos = _pedidoService.Adicionar(pedido);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        [Route("/Pedido/{pedidoId}")]
        public IActionResult Delete(int pedidoId)
        {
            try
            {
                var pedidos = _pedidoService.Remover(pedidoId);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Pedidos pedido)
        {
            try
            {
                var pedidos = _pedidoService.Atualizar(pedido);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}