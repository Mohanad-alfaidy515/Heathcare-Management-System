using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class DoctorCountSpecifications:BaseSpecification<Doctor,int>
    {
        public DoctorCountSpecifications(DoctorSpecificationsParamters specparm) :
            base(
                 p =>
                (!specparm.Specializationn.HasValue || p.SpecializationId == specparm.Specializationn) &&
                (string.IsNullOrEmpty(specparm.name) || p.FirstName.ToLower().Contains(specparm.name.ToLower()))
                )
        {
            
        }
    }
}
