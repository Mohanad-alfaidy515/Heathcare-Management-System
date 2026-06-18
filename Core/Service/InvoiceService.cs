using AutoMapper;
using Domain.Contract;
using Domain.Models;
using Domain.Models.Enums;
using ServiceAbstractions;
using Shared;

namespace Service
{
    public class InvoiceService(IUnitOfWork unitOfWork, IMapper mapper) : IInvoiceService
    {
        public async Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto createDto)
        {
            var invoice = new Invoice
            {
                AppointmentId = createDto.AppointmentId,
                Amount = createDto.Amount,
                InvoiceDate = DateTime.Now,
                Status = InvoiceStatus.Pending
            };

            await unitOfWork.GetRepository<Invoice, int>().AddAsync(invoice);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(int id)
        {
            var invoice = await unitOfWork.GetRepository<Invoice, int>().GetByIdAsync(id);
            return invoice == null ? null : mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto?> GetInvoiceByAppointmentIdAsync(int appointmentId)
        {
            var invoices = await unitOfWork.GetRepository<Invoice, int>().GetAllAsync();
            var invoice = invoices.FirstOrDefault(i => i.AppointmentId == appointmentId);
            return invoice == null ? null : mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<bool> UpdateInvoiceStatusAsync(int id, InvoiceStatus status)
        {
            var repo = unitOfWork.GetRepository<Invoice, int>();
            var invoice = await repo.GetByIdAsync(id);
            if (invoice == null) return false;

            invoice.Status = status;
            repo.Update(id, invoice);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
