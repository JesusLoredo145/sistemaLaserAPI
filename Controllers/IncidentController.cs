using Microsoft.AspNetCore.Mvc;
using sistemaLaserAPI.Dtos;
using sistemaLaserAPI.Interfaces;

namespace sistemaLaserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        //ping pa ver si jalo o me suicido 
        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok(new
            {
                Status = "Online",
                Message = "Hola UNEZ",
                Api = "Sistema Laser API",
                Version = "1.0.0",
                ServerTime = DateTime.UtcNow,
                Database = "SQLite"
            });
        }
        //registrar nueva incidencia 
        [HttpPost]
        public async Task<IActionResult> Create(CreateIncidentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.deviceId))
            {
                return BadRequest("El DeviceId es obligatorio.");
            }

            if (dto.counter < 1)
            {
                return BadRequest("El contador debe ser mayor a cero.");
            }

            if (dto.signalValue < 0)
            {
                return BadRequest("El valor de la señal no es válido.");
            }
            var incident = await _incidentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = incident.id }, incident);
        }
        //obtener todos 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incidents = await _incidentService.GetAllAsync();
            return Ok(incidents);
        }
        //obtener por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var incident = await _incidentService.GetByIdAsync(id);
            if (incident == null)
                return NotFound();
            return Ok(incident);
        }
        //obtener total de incidencias
        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var total = await _incidentService.CountAsync();
            return Ok(new
            {
                Total = total
            });
        }
        //obtener la ultima incidencia registrada 
        [HttpGet("latest")]
        public async Task<IActionResult> Latest()
        {
            var incident = await _incidentService.GetLatestAsync();
            if (incident == null)
                return NotFound();
            return Ok(incident);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _incidentService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return Ok(new
            {
                Success =true,
                Message = "Incidencia eliminada"
            });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _incidentService.DeleteAllAsync();
            return Ok(new
            {
                Success = true,
                Message = "Todas las incidencias fueron eliminadas... no uses este metodo tan seguido"
            });
        }
    }
}
