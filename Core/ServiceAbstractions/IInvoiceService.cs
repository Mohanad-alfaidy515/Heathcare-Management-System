using Shared;
using Domain.Models.Enums;

namespace ServiceAbstractions
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto createDto);
        Task<InvoiceDto?> GetInvoiceByIdAsync(int id);
        Task<InvoiceDto?> GetInvoiceByAppointmentIdAsync(int appointmentId);
        Task<bool> UpdateInvoiceStatusAsync(int id, InvoiceStatus status);
    }
}
