using System;
using System.Collections.Generic;
using RegisterHeroApi.DTOs.Superpoder;

namespace RegisterHeroApi.DTOs.Heroi
{
    public class HeroiResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string NomeHeroi { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }

        public List<SuperpoderDto> Superpoderes { get; set; } = new();
    }
}
