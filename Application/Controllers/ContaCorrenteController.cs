using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Service.Services;
using Service.Validators;

namespace Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private BaseService<ContaCorrente> contaService = new BaseService<ContaCorrente>();
        private BaseService<Correntista> correntistaService = new BaseService<Correntista>();
        private CoafService coafService = new CoafService();

        [HttpPost("NovaConta")]
        public IActionResult NovaConta([FromBody] ContaCorrente item)
        {
            try
            {
                contaService.Post<ContaCorrenteValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetConta/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(contaService.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("FazerTransacao")]
        public IActionResult FazerTransacao([FromBody] Transacao transacao)
        {
            try
            {
                ContaCorrente conta = contaService.Get(transacao.Id);
                conta.Saldo += transacao.Valor;
                contaService.Put<ContaCorrenteValidator>(conta);

                if (transacao.PrecisaNotificarCoaf())
                {
                    Correntista correntista = correntistaService.Get(conta.correntistaId);
                    coafService.NotificarCoafApi(correntista, transacao);
                }

                return new ObjectResult(conta);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (InvalidOperationException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                contaService.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}