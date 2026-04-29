using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointment();
        Task<AppointmentDto> GetAppointmentById(int id);
        Task<AppointmentDto> AddAppointment(AppointmentDto appointment);
    }
}
