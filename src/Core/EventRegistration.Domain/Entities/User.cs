using Microsoft.AspNetCore.Identity;

namespace EventRegistration.Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
