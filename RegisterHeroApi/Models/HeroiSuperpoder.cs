namespace RegisterHeroApi.Models
{
    public class HeroiSuperpoder
    {
        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; } = null!;
        public int SuperpoderId { get; set; }
        public Superpoder SuperPoder { get; set; } = null!;
    }
}
