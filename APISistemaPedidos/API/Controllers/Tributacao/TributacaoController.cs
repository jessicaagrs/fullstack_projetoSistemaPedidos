using API.Models;
using API.Models.Tributacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Tributacao
{
    [ApiController]
    [Route("[controller]")]
    public class TributacaoController : ControllerBase
    {
        private ITributacaoService _tributacaoService;

        public TributacaoController(ITributacaoService fornecedorService)
        {
            _tributacaoService = fornecedorService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var tributacoes = _tributacaoService.ObterTodos();
                return Ok(tributacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost()]
        public IActionResult Post([FromBody] Tributacoes tributacao)
        {
            try
            {
                var tributacoes = _tributacaoService.Adicionar(tributacao);
                return Ok(tributacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        [Route("/Tributacao/{tributacaoId}")]
        public IActionResult Delete(int tributacaoId)
        {
            try
            {
                var tributacoes = _tributacaoService.Remover(tributacaoId);
                return Ok(tributacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Tributacoes tributacao)
        {
            try
            {
                var tributacoes = _tributacaoService.Atualizar(tributacao);
                return Ok(tributacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}