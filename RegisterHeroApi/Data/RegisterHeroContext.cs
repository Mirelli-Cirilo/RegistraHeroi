using Microsoft.EntityFrameworkCore;
using RegisterHeroApi.Models;

namespace RegisterHeroApi.Data
{
    public class RegisterHeroContext : DbContext
    {
        public RegisterHeroContext(DbContextOptions<RegisterHeroContext> options)
        : base(options)
        {
        }

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Superpoder> Superpoderes { get; set; }
        public DbSet<HeroiSuperpoder> HeroisSuperpoderes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiSuperpoder>()
                .HasKey(hs => new { hs.HeroiId, hs.SuperpoderId });
        }
    }
}
