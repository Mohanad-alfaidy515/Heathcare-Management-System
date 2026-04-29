using AutoMapper;
using Domain.Contract;
using ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUniteOfWork uniteOfWork, IMapper mapper) : IServiceManager
    {
        public IDoctorService doctorService { get; } = new DoctorService(uniteOfWork, mapper);

        public IAppointmentService appointmentService { get; } = new AppointmentService(uniteOfWork, mapper);

        public IPatientService PatientService { get; } = new PatientService(uniteOfWork, mapper);
    }
}
