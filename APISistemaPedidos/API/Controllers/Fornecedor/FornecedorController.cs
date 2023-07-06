using API.Models;
using API.Models.Fornecedor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Fornecedor
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
               var fornecedores =  _fornecedorService.ObterTodos();
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost()]
        public IActionResult Post([FromBody] Fornecedores fornecedor)
        {
            try
            {
               var fornecedores = _fornecedorService.Adicionar(fornecedor);
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        [Route("/Fornecedor/{fornecedorId}")]
        public IActionResult Delete(int fornecedorId)
        {
            try
            {
                var fornecedores = _fornecedorService.Remover(fornecedorId);
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Fornecedores fornecedor)
        {
            try
            {
                var fornecedores = _fornecedorService.Atualizar(fornecedor);
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}