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
    public class CorrentistaController : ControllerBase
    {
        private BaseService<Correntista> correntistaService = new BaseService<Correntista>();
        private BaseService<ContaCorrente> contaService = new BaseService<ContaCorrente>();

        [HttpPost("NovoCorrentista")]
        public IActionResult NovoCorrentista([FromBody] Correntista item)
        {
            try
            {
                correntistaService.Post<CorrentistaValidator>(item);

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

        [HttpGet("GetCorrentista/{id}")]
        public IActionResult GetCorrentista(int id)
        {
            try
            {
                return new ObjectResult(correntistaService.Get(id));
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

        [HttpGet("GetContasDoCorrentista/{id}")]
        public IActionResult GetContasDoCorrentista(int id)
        {
            try
            {
                return new ObjectResult(contaService.Get().Where(c => c.correntistaId == id).ToList());
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

        [HttpGet("ListarCorrentistas")]
        public IActionResult ListarCorrentistas()
        {
            try
            {
                return new ObjectResult(correntistaService.Get());
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                correntistaService.Delete(id);

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