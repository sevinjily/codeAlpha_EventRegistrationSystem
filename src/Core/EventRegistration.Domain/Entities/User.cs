using Microsoft.AspNetCore.Identity;

namespace EventRegistration.Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
        public DateTime BirthDate { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
