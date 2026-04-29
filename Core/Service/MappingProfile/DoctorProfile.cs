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
    public class DoctorProfile:Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctoerReturnDto>()
                .ForMember(d=>d.Specialization,o=>o.MapFrom(s=>s.Specialization.Name));
            CreateMap<Specialization, SpecializationReturnDto>();
                
        }
    }
}
