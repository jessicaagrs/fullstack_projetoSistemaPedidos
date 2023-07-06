using API.Models;
using API.Models.Produto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Produto
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtoService.ObterTodos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost()]
        public IActionResult Post([FromBody] Produtos produto)
        {
            try
            {
                var produtos = _produtoService.Adicionar(produto);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        [Route("/Produto/{produtoId}")]
        public IActionResult Delete(int produtoId)
        {
            try
            {
                var produtos = _produtoService.Remover(produtoId);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Produtos produto)
        {
            try
            {
                var produtos = _produtoService.Atualizar(produto);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}