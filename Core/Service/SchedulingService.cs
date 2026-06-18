using Domain.Contract;
using Domain.Models;
using ServiceAbstractions;
using Service.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class SchedulingService(IUnitOfWork unitOfWork) : ISchedulingService
    {
        public async Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync(int doctorId, DateTime date)
        {
            var availSpec = new DoctorAvailabilitySpecification(doctorId, date.DayOfWeek);
            var availabilities = await unitOfWork.GetRepository<DoctorAvailability, int>().GetAllAsync(availSpec);
            var doctorDayAvailability = availabilities.FirstOrDefault();

            if (doctorDayAvailability == null) return Enumerable.Empty<TimeSlot>();

            var appSpec = new AppointmentByDoctorAndDateSpecification(doctorId, date);
            var doctorAppointments = await unitOfWork.GetRepository<Appointment, int>().GetAllAsync(appSpec);

            var slots = new List<TimeSlot>();
            var currentSlotStart = doctorDayAvailability.StartTime;

            while (currentSlotStart + TimeSpan.FromMinutes(30) <= doctorDayAvailability.EndTime)
            {
                var slotEnd = currentSlotStart + TimeSpan.FromMinutes(30);
                var isBooked = doctorAppointments.Any(a => a.AppointmentDate.TimeOfDay == currentSlotStart);

                slots.Add(new TimeSlot
                {
                    StartTime = currentSlotStart,
                    EndTime = slotEnd,
                    IsAvailable = !isBooked
                });

                currentSlotStart = slotEnd;
            }

            return slots;
        }

        public async Task<DoctorAvailability> AddAvailabilityAsync(DoctorAvailability availability)
        {
            await unitOfWork.GetRepository<DoctorAvailability, int>().AddAsync(availability);
            await unitOfWork.SaveChangesAsync();
            return availability;
        }

        public async Task<bool> IsSlotAvailableAsync(int doctorId, DateTime appointmentDate)
        {
            var slots = await GetAvailableSlotsAsync(doctorId, appointmentDate.Date);
            return slots.Any(s => s.StartTime == appointmentDate.TimeOfDay && s.IsAvailable);
        }
    }
}
