using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class IletisimRepository : GenericRepository<Iletisim>
    {
        public IletisimRepository(PortfolioDbContext context) : base(context)
        {

        }
    }
}
