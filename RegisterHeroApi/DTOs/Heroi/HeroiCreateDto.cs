using System;
using System.Collections.Generic;

namespace RegisterHeroApi.DTOs.Heroi
{
    public class HeroiCreateDto
    {
        public string Nome { get; set; } = string.Empty;
        public string NomeHeroi { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }

        public List<int> SuperpoderesIds { get; set; } = new();
    }
}
