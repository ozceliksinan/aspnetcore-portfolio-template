using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class YetenekRepository : GenericRepository<Yeteneklerim>
    {
        public YetenekRepository(PortfolioDbContext context) : base(context)
        {

        }
    }
}
