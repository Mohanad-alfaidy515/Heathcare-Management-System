using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class DoctorSpecifications:BaseSpecification<Doctor,int>
    {

        public DoctorSpecifications(int id):base(p=>p.Id==id)
        {
            AddInclude(p => p.Specialization);
        }
        public DoctorSpecifications(DoctorSpecificationsParamters specparm) :
            base(
                p=>
                (!specparm.Specializationn.HasValue||p.SpecializationId==specparm.Specializationn)&&
                (string.IsNullOrEmpty(specparm.name)||p.FirstName.ToLower().Contains(specparm.name.ToLower()))
                )
          
        {
            AddInclude(p => p.Specialization);
            ApplySorting(specparm.sort);
            ApplyPagination(specparm._pageIndex, specparm._pageSize);
          
        }
        private void ApplySorting(string? sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "NameAsc":
                        AddOrderByy(p => p.FirstName);
                        break;
                    case "NameDesc":
                        AddOrderByyDecsinding(p => p.FirstName);
                        break;
                    default:
                        AddOrderByy(p => p.FirstName); break;

                }
            }
            else
            {
                AddOrderByy(p => p.FirstName);
            }
        }
    }
}
