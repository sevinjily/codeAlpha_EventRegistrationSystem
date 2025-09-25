using EventRegistration.Domain.Common;

namespace EventRegistration.Domain.Entities
{
    public class Event:EntityBase
    {
        public string EventName { get; set; }       // Event adı
        public string Description { get; set; }     // Tədbirin təsviri
        public DateTime StartDate { get; set; }     // Başlanğıc tarixi
        public DateTime EndDate { get; set; }       // Bitmə tarixi
        public string Location { get; set; }        // Məkan
        public int UserLimit { get; set; }          // Maksimum iştirakçı sayı

        // Navigation property: Bir event-ə çoxlu qeydiyyat ola bilər
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
