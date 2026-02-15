using System.ComponentModel.DataAnnotations;

namespace RegisterHeroApi.Models
{
    public class Heroi
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(120)]
        public string NomeHeroi { get; set; } = string.Empty;

        public DateTime? DataNascimento { get; set; }

        [Required]
        public float Altura { get; set; }

        [Required]
        public float Peso { get; set; }

        public ICollection<HeroiSuperpoder> HeroisSuperpoderes { get; set; } = new List<HeroiSuperpoder>();

    }
}
