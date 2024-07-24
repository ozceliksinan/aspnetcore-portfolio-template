using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class HobiRepository : GenericRepository<Hobilerim>
    {
        public HobiRepository(PortfolioDbContext context) : base(context)
        {

        }
    }
}
