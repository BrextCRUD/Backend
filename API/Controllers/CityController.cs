using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/city")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _service.GetAllAsync();
            if (countries == null || !countries.Any())
                return NotFound("No se encontraron ciudades.");
            
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await _service.GetByIdAsync(id);
            if (city == null)
                return NotFound($"No se encontró la ciudad con el ID {id}.");

            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityDTO dto)
        {
         
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var success = await _service.CreateAsync(dto);
                if (success)
                {
                    return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto.Name);
                }
                return BadRequest("No se pudo crear la ciudad.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CityDTO dto)
        {
            // Valida el DTO
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var city = await _service.GetByIdAsync(id);
            if (city == null)
                return NotFound($"No se encontró la ciudad con el ID {id}.");

            try
            {
                var success = await _service.UpdateAsync(id, dto);
                if (success)
                    return Ok(dto); 
                return BadRequest("No se pudo actualizar la ciudad.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _service.GetByIdAsync(id);
            if (city == null)
                return NotFound($"No se encontró la ciudad con el ID {id}.");

            var success = await _service.DeleteAsync(id);
            if (success)
                return NoContent(); 
            return BadRequest("No se pudo eliminar la ciudad.");
        }
    }
}
