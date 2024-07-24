using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class HakkimdaRepository : GenericRepository<Hakkimda>
    {
        public HakkimdaRepository(PortfolioDbContext context) : base(context)
        {

        }
    }
}
