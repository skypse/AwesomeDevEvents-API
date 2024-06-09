using AwesomeDevEvents.API.Entities;
using AwesomeDevEvents.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEvents.API.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;

        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }
        
        // api/dev-events GET
        [HttpGet]
        // trazer todos elementos no estado não removido
        public IActionResult GetAll()
        {
            // Verifica se DevEvents é nul
            if (_context.DevEvents == null)
            {
                return NotFound("Nenhum evento encontrado.");
            }

            // Puxando os eventos que não estão cancelados
            var devEvents = _context.DevEvents.Where(d => !d.IsDeleted).ToList();

            return Ok(devEvents);
        }

        // api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa6 GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            // Verifica se DevEvents é nul
            if (_context.DevEvents == null)
            {
                return NotFound("Nenhum evento encontrado.");
            }

            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            // se for nulo retorna
            if (devEvent == null)
            {
                return NotFound();
            }

            return Ok(devEvent);
        }

        // api/dev-events/ POST
        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            // Verifica se DevEvents é nul
            if (_context.DevEvents == null)
            {
                return NotFound("Nenhum evento encontrado.");
            }

            _context.DevEvents.Add(devEvent);

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }

        [HttpPut("{id}")]
        // api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa6 PUT
        public IActionResult Update(Guid id,DevEvent input)
        {
            // Verifica se DevEvents é nul
            if (_context.DevEvents == null)
            {
                return NotFound("Nenhum evento encontrado.");
            }

            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            // se for nulo retorna
            if (devEvent == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(input.Descricao) || (string.IsNullOrEmpty(input.Titulo)))
            {
                return BadRequest("A descrição ou Titulo não pode ser nula ou vazia.");
            }

            devEvent.Update(input.Titulo, input.Descricao, input.DataInicio, input.DataFinal);

            return NoContent();
        }

        // api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa6 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            // Verifica se DevEvents é nul
            if (_context.DevEvents == null)
            {
                return NotFound("Nenhum evento encontrado.");
            }

            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            // se for nulo retorna
            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();

            return NoContent();

        }
        // api/dev-events/3fa85f64-5717-4562-b3fc-2c963f66afa6/palestrantes
        [HttpPost("{id}/palestrantes")]
        public IActionResult PostPalestrantes(Guid id,DevEventPalestrantes palestrante)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Palestrantes.Add(palestrante);

            return NoContent();
        }
    }
}
