using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Data
{
    public class PortfolioDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {

        }

        public DbSet<Deneyimler> Deneyimler { get; set; }
        public DbSet<Egitim> Egitim { get; set; }
        public DbSet<Hakkimda> Hakkimda { get; set; }
        public DbSet<Hobilerim> Hobilerim { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Sertifikalarim> Sertifikalarim { get; set; }
        public DbSet<Yeteneklerim> Yeteneklerim { get; set; }
        public DbSet<SosyalMedya> SosyalMedya { get; set; }
    }
}
