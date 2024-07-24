using PortfolioTemplate.Models;

namespace PortfolioTemplate.Data
{
    public class IndexViewModel
    {
        public IEnumerable<Hakkimda>? Hakkimda { get; set; }
        public IEnumerable<Deneyimler>? Deneyimler { get; set; }
        public IEnumerable<Egitim>? Egitim { get; set; }
        public IEnumerable<Yeteneklerim>? Yeteneklerim { get; set; }
        public IEnumerable<Hobilerim>? Hobilerim { get; set; }
        public IEnumerable<Sertifikalarim>? Sertifikalarim { get; set; }
        public IEnumerable<Iletisim>? Iletisim { get; set; }
        public IEnumerable<SosyalMedya>? SosyalMedya { get; set; }
    }
}
