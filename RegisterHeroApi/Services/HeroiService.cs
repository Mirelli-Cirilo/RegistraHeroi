using Microsoft.EntityFrameworkCore;
using RegisterHeroApi.Data;
using RegisterHeroApi.DTOs.Heroi;
using RegisterHeroApi.DTOs.Superpoder;
using RegisterHeroApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterHeroApi.Services
{
    public class HeroiService : IRegisterHeroService
    {
        private readonly RegisterHeroContext _context;

        public HeroiService(RegisterHeroContext context)
        {
            _context = context;
        }

        public async Task<List<HeroiListDto>> GetAllAsync()
        {
            var herois = await _context.Herois
                .Select(h => new HeroiListDto
                {
                    Id = h.Id,
                    NomeHeroi = h.NomeHeroi
                })
                .ToListAsync();

            if (herois.Count == 0)
                throw new KeyNotFoundException("Nenhum herói cadastrado.");

            return herois;
        }

        public async Task<HeroiResponseDto> GetByIdAsync(int id)
        {
            var heroi = await _context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.SuperPoder)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (heroi == null)
                throw new KeyNotFoundException("Herói não encontrado.");

            return new HeroiResponseDto
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.HeroisSuperpoderes.Select(hs => new SuperpoderDto
                {
                    Id = hs.SuperPoder.Id,
                    Superpoder = hs.SuperPoder.SuperPoder,
                    Descricao = hs.SuperPoder.Descricao
                }).ToList()
            };
        }

        public async Task<HeroiResponseDto> CreateAsync(HeroiCreateDto dto)
        {
            bool nomeHeroiExiste = await _context.Herois
                .AnyAsync(h => h.NomeHeroi == dto.NomeHeroi);

            if (nomeHeroiExiste)
                throw new InvalidOperationException("Já existe um herói com esse nome de herói.");

            var heroi = new Heroi
            {
                Nome = dto.Nome,
                NomeHeroi = dto.NomeHeroi,
                DataNascimento = dto.DataNascimento,
                Altura = dto.Altura,
                Peso = dto.Peso,
                HeroisSuperpoderes = new List<HeroiSuperpoder>()
            };

            foreach (var idSuperpoder in dto.SuperpoderesIds)
            {
                var superpoder = await _context.Superpoderes.FindAsync(idSuperpoder);

                if (superpoder == null)
                    throw new System.Exception($"Superpoder com ID {idSuperpoder} não existe.");

                heroi.HeroisSuperpoderes.Add(new HeroiSuperpoder
                {
                    SuperpoderId = idSuperpoder
                });
            }

            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(heroi.Id);
        }

        public async Task<HeroiResponseDto> UpdateAsync(int id, HeroiUpdateDto dto)
        {
            var heroi = await _context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (heroi == null)
                throw new KeyNotFoundException("Herói não encontrado.");

            bool nomeHeroiExiste = await _context.Herois
                .AnyAsync(h => h.NomeHeroi == dto.NomeHeroi && h.Id != id);

            if (nomeHeroiExiste)
                throw new InvalidOperationException("Já existe um herói com esse nome de herói.");

            heroi.Nome = dto.Nome;
            heroi.NomeHeroi = dto.NomeHeroi;
            heroi.DataNascimento = dto.DataNascimento;
            heroi.Altura = dto.Altura;
            heroi.Peso = dto.Peso;

            heroi.HeroisSuperpoderes.Clear();

            foreach (var idSuperpoder in dto.SuperpoderesIds)
            {
                var superpoderExiste = await _context.Superpoderes
                    .AnyAsync(s => s.Id == idSuperpoder);

                if (!superpoderExiste)
                    throw new System.Exception($"Superpoder com ID {idSuperpoder} não existe.");

                heroi.HeroisSuperpoderes.Add(new HeroiSuperpoder
                {
                    HeroiId = heroi.Id,
                    SuperpoderId = idSuperpoder
                });
            }

            await _context.SaveChangesAsync();

            return await GetByIdAsync(heroi.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var heroi = await _context.Herois.FindAsync(id);

            if (heroi == null)
                throw new KeyNotFoundException("Herói não encontrado.");

            _context.Herois.Remove(heroi);
            await _context.SaveChangesAsync();
        }
    }
}