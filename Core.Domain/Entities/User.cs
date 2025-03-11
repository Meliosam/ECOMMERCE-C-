using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Nome { get; set; } = string.Empty;
    }
}
