using Microsoft.AspNetCore.Identity;

namespace PortfolioTemplate.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string? NameSurname { get; set; }
    }
}
