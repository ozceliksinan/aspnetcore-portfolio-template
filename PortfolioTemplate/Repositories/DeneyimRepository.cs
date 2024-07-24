using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class DeneyimRepository : GenericRepository<Deneyimler>
    {
        public DeneyimRepository(PortfolioDbContext context) : base(context)
        {

        }
    }
}
