using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/region")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _service;

        public RegionController(IRegionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _service.GetAllAsync();
            if (countries == null || !countries.Any())
                return NotFound("No se encontraron departamentos.");
            
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var region = await _service.GetByIdAsync(id);
            if (region == null)
                return NotFound($"No se encontró el departamento con el ID {id}.");

            return Ok(region);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegionDTO dto)
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
                return BadRequest("No se pudo crear el departamento.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RegionDTO dto)
        {
            // Valida el DTO
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var region = await _service.GetByIdAsync(id);
            if (region == null)
                return NotFound($"No se encontró el departamento con el ID {id}.");

            try
            {
                var success = await _service.UpdateAsync(id, dto);
                if (success)
                    return Ok(dto); 
                return BadRequest("No se pudo actualizar el departamento.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var region = await _service.GetByIdAsync(id);
            if (region == null)
                return NotFound($"No se encontró el departamento con el ID {id}.");

            var success = await _service.DeleteAsync(id);
            if (success)
                return NoContent(); 
            return BadRequest("No se pudo eliminar el departamento.");
        }
    }
}
