using Microsoft.EntityFrameworkCore;
using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

namespace PortfolioTemplate.Repositories
{
    public class GenericRepository<T> where T : class
    {
        // --- Veritabanı Bağlantı Bilgisi --- //
        private readonly PortfolioDbContext _context;
        public GenericRepository(PortfolioDbContext context)
        {
            _context = context;
        }
        // --- Veritabanı Bağlantı Bilgisi --- //

        public IEnumerable<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<SosyalMedya> ListWithRelations()
        {
            return _context.SosyalMedya.Include(h => h.Hakkimda).ToList();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
