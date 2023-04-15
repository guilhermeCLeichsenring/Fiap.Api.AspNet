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
    public class AreaDeRiscoController : Controller
    {
        private readonly AreaDeRiscoRepository areaDeRiscoRepository;

        public AreaDeRiscoController(DataBaseContext context)
        {
            areaDeRiscoRepository = new AreaDeRiscoRepository(context);
        }

        [HttpGet]
        public ActionResult <IList<AreaDeRiscoModel>> Get()
        {
            try
            {
                var lista = areaDeRiscoRepository.Listar();

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
        public ActionResult<AreaDeRiscoModel> Get([FromRoute] int id)
        {
            try
            {
                var areaDeRiscoModel = areaDeRiscoRepository.Consultar(id);

                if (areaDeRiscoModel != null)
                {
                    return Ok(areaDeRiscoModel);
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
        public ActionResult<AreaDeRiscoModel> Post([FromBody] AreaDeRiscoModel areaDeRiscoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                areaDeRiscoRepository.Inserir(areaDeRiscoModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + areaDeRiscoModel.AreaDeRiscoId);
                return Created(location, areaDeRiscoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a Area de Risco. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<AreaDeRiscoModel> Delete([FromRoute] int id)
        {
            try
            {
                var areaDeRiscoModel = areaDeRiscoRepository.Consultar(id);

                if (areaDeRiscoModel != null)
                {
                    areaDeRiscoRepository.Excluir(id);
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
        public ActionResult<AreaDeRiscoModel> Put([FromRoute] int id, [FromBody] AreaDeRiscoModel areaDeRiscoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (areaDeRiscoModel.AreaDeRiscoId != id)
            {
                return NotFound();
            }


            try
            {
                areaDeRiscoRepository.Alterar(areaDeRiscoModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a área de risco. Detalhes: {error.Message}" });
            }
        }


    }
}
