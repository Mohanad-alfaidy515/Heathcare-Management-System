namespace Shared
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateInvoiceDto
    {
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
    }
}
