using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository;
using Fiap.Api.AspNet.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Fiap.Api.AspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RioController : ControllerBase
    {
        private readonly RioRepository rioRepository;
        
        public RioController(DataBaseContext context)
        {
            rioRepository = new RioRepository(context);
        }

        [HttpGet]
        public ActionResult<List<RioModel>> Get()
        {
            try
            {
                var lista = rioRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<RioModel> Get([FromRoute] int id)
        {
            try
            {
                var rioModel = rioRepository.Consultar(id);

                if (rioModel != null)
                {
                    return Ok(rioModel);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<RioModel> Post([FromBody] RioModel rioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                rioRepository.Inserir(rioModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + rioModel.RioId);
                return Created(location, rioModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o rio. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<RioModel> Delete([FromRoute] int id)
        {
            try
            {
                var rioModel = rioRepository.Consultar(id);

                if (rioModel != null)
                {
                    rioRepository.Excluir(id);
                    // Retorno Sucesso.
                    // Efetuou a exclusão, porém sem necessidade de informar os dados.
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<RioModel> Put([FromRoute] int id, [FromBody] RioModel rioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (rioModel.RioId != id)
            {
                return NotFound();
            }


            try
            {
                rioRepository.Alterar(rioModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o rio. Detalhes: {error.Message}" });
            }
        }
    }
}
