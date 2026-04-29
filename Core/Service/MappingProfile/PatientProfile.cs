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
    public class PatientProfile:Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ReverseMap();
            

        }
    }
}
