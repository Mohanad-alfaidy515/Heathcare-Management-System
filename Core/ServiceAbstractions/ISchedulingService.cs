using Shared;
using Domain.Models;

namespace ServiceAbstractions
{
    public interface ISchedulingService
    {
        Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync(int doctorId, DateTime date);
        Task<DoctorAvailability> AddAvailabilityAsync(DoctorAvailability availability);
        Task<bool> IsSlotAvailableAsync(int doctorId, DateTime appointmentDate);
    }
}
