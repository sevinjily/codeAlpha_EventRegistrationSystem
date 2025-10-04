using Microsoft.AspNetCore.Identity;

namespace EventRegistration.Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiredTime { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
