using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioTemplate.Models
{
    public class Hakkimda
    {
        public int HakkimdaId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Adres { get; set; }
        public string? Telefon { get; set; }
        public string? Mail { get; set; }
        public string? Aciklama { get; set; }
        public string? Resim { get; set; }
    }
}
