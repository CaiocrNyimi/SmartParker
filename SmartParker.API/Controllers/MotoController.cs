using Microsoft.AspNetCore.Mvc;
using SmartParker.Application.DTOs;
using SmartParker.Application.Services;

namespace SmartParker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _motoService;

        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var motos = await _motoService.GetAllAsync();
            return Ok(motos);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var moto = await _motoService.GetByIdAsync(id);
            return moto is null ? NotFound() : Ok(moto);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByName([FromQuery] string nome)
        {
            var motos = await _motoService.SearchByNomeAsync(nome);
            return Ok(motos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MotoDto dto)
        {
            var created = await _motoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, MotoUpdateDto dto)
        {
            var updated = await _motoService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            var moto = await _motoService.GetByIdAsync(id);
            return Ok(moto);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _motoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}