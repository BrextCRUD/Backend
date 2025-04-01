using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _service.GetAllAsync();
            if (countries == null || !countries.Any())
                return NotFound("No se encontraron países.");
            
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _service.GetByIdAsync(id);
            if (country == null)
                return NotFound($"No se encontró el país con el ID {id}.");

            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryDTO dto)
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
                return BadRequest("No se pudo crear el país.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CountryDTO dto)
        {
            // Valida el DTO
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var country = await _service.GetByIdAsync(id);
            if (country == null)
                return NotFound($"No se encontró el país con el ID {id}.");

            try
            {
                var success = await _service.UpdateAsync(id, dto);
                if (success)
                    return Ok(dto); 
                return BadRequest("No se pudo actualizar el país.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _service.GetByIdAsync(id);
            if (country == null)
                return NotFound($"No se encontró el país con el ID {id}.");

            var success = await _service.DeleteAsync(id);
            if (success)
                return NoContent(); 
            return BadRequest("No se pudo eliminar el país.");
        }
    }
}
