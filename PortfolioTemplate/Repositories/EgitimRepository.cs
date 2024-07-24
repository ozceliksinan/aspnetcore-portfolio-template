using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class EgitimRepository : GenericRepository<Egitim>
    {
        public EgitimRepository(PortfolioDbContext context) : base(context)
        {

        }
    }
}
