using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository;
using Fiap.Api.AspNet.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fiap.Api.AspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PluviometroController : ControllerBase
    {
        private readonly PluviometroRepository pluviometroRepository;

        public PluviometroController(DataBaseContext context)
        {
            pluviometroRepository = new PluviometroRepository(context);
        }

        [HttpGet]
        public ActionResult<List<PluviometroModel>> Get()
        {
            try
            {
                var lista = pluviometroRepository.Listar();

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
        public ActionResult<PluviometroModel> Get([FromRoute] int id)
        {
            try
            {
                var pluviometroModel = pluviometroRepository.Consultar(id);

                if (pluviometroModel != null)
                {
                    return Ok(pluviometroModel);
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
        public ActionResult<PluviometroModel> Post([FromBody] PluviometroModel pluviometroModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                pluviometroRepository.Inserir(pluviometroModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + pluviometroModel.PluviometroId);
                return Created(location, pluviometroModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível o Representante. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<PluviometroModel> Delete([FromRoute] int id)
        {
            try
            {
                var pluviometroModel = pluviometroRepository.Consultar(id);

                if (pluviometroModel != null)
                {
                    pluviometroRepository.Excluir(id);
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
        public ActionResult<PluviometroModel> Put([FromRoute] int id, [FromBody] PluviometroModel pluviometroModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pluviometroModel.PluviometroId != id)
            {
                return NotFound();
            }


            try
            {
                pluviometroRepository.Alterar(pluviometroModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o pluviômetro. Detalhes: {error.Message}" });
            }
        }
    }
}
