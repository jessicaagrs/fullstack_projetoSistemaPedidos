using API.Models;
using API.Models.TipoDespesa;
using API.Models.TipoDespesa.TipoDespesa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoDespesaController : ControllerBase
    {
        private ITipoDespesaService _tipoDespesaService;

        public TipoDespesaController(ITipoDespesaService tipoDespesaService)
        {
            _tipoDespesaService = tipoDespesaService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
               var tipoDespesas =  _tipoDespesaService.ObterTodos();
                return Ok(tipoDespesas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost()]
        public IActionResult Post([FromBody] TipoDespesas tipoDespesa)
        {
            try
            {
               var tipoDespesas =  _tipoDespesaService.Adicionar(tipoDespesa);
                return Ok(tipoDespesas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        [Route("/TipoDespesa/{tipoDespesaId}")]
        public IActionResult Delete(int tipoDespesaId)
        {
            try
            {
                var tipoDespesas = _tipoDespesaService.Remover(tipoDespesaId);
                return Ok(tipoDespesas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody] TipoDespesas tipoDespesa)
        {
            try
            {
                var tipoDespesas = _tipoDespesaService.Atualizar(tipoDespesa);
                return Ok(tipoDespesas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}