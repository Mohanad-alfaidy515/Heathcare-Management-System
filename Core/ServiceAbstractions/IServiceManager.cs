using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface IServiceManager
    {
        IDoctorService doctorService { get; }
        IAppointmentService appointmentService { get; }
        IPatientService PatientService { get; }
    }
}
