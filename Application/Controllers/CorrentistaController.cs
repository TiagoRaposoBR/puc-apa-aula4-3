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
        private BaseService<Correntista> service = new BaseService<Correntista>();

        [HttpPost("NovoCorrentista")]
        public IActionResult NovoCorrentista([FromBody] Correntista item)
        {
            try
            {
                service.Post<CorrentistaValidator>(item);

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
                return new ObjectResult(service.Get(id));
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
                return new ObjectResult(service.Get());
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
                service.Delete(id);

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