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
    public class BoiaController : ControllerBase
    {
        private readonly BoiaRepository boiaRepository;

        public BoiaController(DataBaseContext context)
        {
            boiaRepository = new BoiaRepository(context);
        }

        [HttpGet]
        public ActionResult<List<BoiaModel>> Get()
        {
            try
            {
                var lista = boiaRepository.Listar();

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
        public ActionResult<BoiaModel> Get([FromRoute] int id)
        {
            try
            {
                var boiaModel = boiaRepository.Consultar(id);

                if (boiaModel != null)
                {
                    return Ok(boiaModel);
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
        public ActionResult<BoiaModel> Post([FromBody] BoiaModel boiaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                boiaRepository.Inserir(boiaModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + boiaModel.FerramentaId);
                return Created(location, boiaModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a ferramenta. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<BoiaModel> Delete([FromRoute] int id)
        {
            try
            {
                var boiaModel = boiaRepository.Consultar(id);

                if (boiaModel != null)
                {
                    boiaRepository.Excluir(id);
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
        public ActionResult<BoiaModel> Put([FromRoute] int id, [FromBody] BoiaModel boiaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (boiaModel.FerramentaId != id)
            {
                return NotFound();
            }


            try
            {
                boiaRepository.Alterar(boiaModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a ferramenta. Detalhes: {error.Message}" });
            }
        }
    }
}
