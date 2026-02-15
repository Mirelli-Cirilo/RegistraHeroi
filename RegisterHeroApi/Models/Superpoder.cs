using System.ComponentModel.DataAnnotations;

namespace RegisterHeroApi.Models
{
    public class Superpoder
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SuperPoder {  get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Descricao { get; set; } = string.Empty;

        public ICollection<HeroiSuperpoder> HeroisSuperpoderes { get; set; } = new List<HeroiSuperpoder>();
    }
}
