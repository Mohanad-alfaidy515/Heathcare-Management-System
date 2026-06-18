using Domain.Models.Enums;

namespace Domain.Models
{
    public class Invoice : BaseEntity<int>
    {
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}
