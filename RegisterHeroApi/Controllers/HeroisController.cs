using Microsoft.AspNetCore.Mvc;
using RegisterHeroApi.DTOs.Heroi;
using RegisterHeroApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterHeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroisController : ControllerBase
    {
        private readonly IRegisterHeroService _service;

        public HeroisController(IRegisterHeroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var herois = await _service.GetAllAsync();
                return Ok(herois);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var heroi = await _service.GetByIdAsync(id);
                return Ok(heroi);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HeroiCreateDto dto)
        {
            try
            {
                if (dto.DataNascimento.HasValue && dto.DataNascimento.Value.Date > DateTime.Today)
                    return BadRequest("Data de nascimento não pode ser futura.");

                var heroiCriado = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = heroiCriado.Id }, heroiCriado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HeroiUpdateDto dto)
        {
            try
            {
                if (dto.DataNascimento.HasValue && dto.DataNascimento.Value.Date > DateTime.Today)
                    return BadRequest("Data de nascimento não pode ser futura.");

                var heroiAtualizado = await _service.UpdateAsync(id, dto);
                return Ok(heroiAtualizado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok(new { mensagem = "Herói excluído com sucesso." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}