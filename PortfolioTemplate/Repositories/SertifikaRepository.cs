using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class SertifikaRepository : GenericRepository<Sertifikalarim>
    {
        public SertifikaRepository(PortfolioDbContext context) : base(context)
        {

        }
    }
}
