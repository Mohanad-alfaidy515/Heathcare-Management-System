using AutoMapper;
using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfile
{
    public class AppointmentProfile:Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(p => p.doctor, o => o.MapFrom(s => s.doctor.FirstName ))
                .ForMember(p=>p.Patient,o=>o.MapFrom(s=>s.Patient.FirstName))
                .ReverseMap()
                .ForMember(d=>d.doctor,o=>o.Ignore())
                .ForMember(d=>d.Patient,o=>o.Ignore());
            CreateMap<Patient, PatientDto>();
        }
    }
}
