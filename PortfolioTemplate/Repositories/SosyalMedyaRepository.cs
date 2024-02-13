using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class SosyalMedyaRepository : GenericRepository<SosyalMedya>
    {
        public SosyalMedyaRepository(PortfolioDbContext context) : base(context)
        {

        }
    }
}
