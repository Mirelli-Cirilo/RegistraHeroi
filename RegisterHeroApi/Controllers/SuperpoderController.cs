using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterHeroApi.Data;
using RegisterHeroApi.DTOs.Superpoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterHeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperpoderesController : ControllerBase
    {
        private readonly RegisterHeroContext _context;

        public SuperpoderesController(RegisterHeroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperpoderDto>>> GetAll()
        {
            var superpoderes = await _context.Superpoderes
                .Select(s => new SuperpoderDto
                {
                    Id = s.Id,
                    Superpoder = s.SuperPoder,
                    Descricao = s.Descricao
                })
                .ToListAsync();

            if (superpoderes.Count == 0)
                return NotFound(new { mensagem = "Nenhum superpoder cadastrado." });

            return Ok(superpoderes);
        }
    }
}