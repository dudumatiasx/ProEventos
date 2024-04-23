using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using ProEventos.Application.Dtos;
namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() //ActionResult é usado para retornar códigos de status HTTP
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos == null) return NoContent(); //204 - No Content

                return Ok(eventos); //200 - OK
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) //ActionResult é usado para retornar códigos de status HTTP
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id);
                if (evento == null) return NoContent(); //204 - No Content

                return Ok(evento); //200 - OK
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema) //ActionResult é usado para retornar códigos de status HTTP
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema);
                if (evento == null) return NoContent(); //204 - No Content

                return Ok(evento); //200 - OK
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);
                if (evento == null) return NoContent(); //204 - No Content

                return Ok(evento); //200 - OK
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDto model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                if (evento == null) return NoContent(); //204 - No Content

                return Ok(evento); //200 - OK
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar evento. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id);
                if (evento == null) return NoContent(); //204 - No Content

                return await _eventoService.DeleteEvento(id) ?
                    Ok("Deletado") : //200 - OK
                    throw new Exception("Ocorreu um erro não específico ao tentar deletar o Evento."); //400 - Bad Request       

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar evento. Erro: {ex.Message}");
            }
        }
    }
}

