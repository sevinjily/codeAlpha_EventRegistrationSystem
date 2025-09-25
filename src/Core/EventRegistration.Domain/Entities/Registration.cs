using EventRegistration.Domain.Common;

namespace EventRegistration.Domain.Entities
{
    public class Registration:EntityBase
    {
        public Guid UserId { get; set; }       // FK - User
    public User User { get; set; }         // Navigation property

    public Guid EventId { get; set; }      // FK - Event
    public Event Event { get; set; }       // Navigation property

    public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;  // Qeydiyyat tarixi
    }
}
