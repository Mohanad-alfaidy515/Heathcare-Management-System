using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class AppointmentSpecification:BaseSpecification<Appointment,int>
    {
        public AppointmentSpecification(int id):base(p=>p.Id ==id)
        {
            AddIncludes();
        }
        public AppointmentSpecification():base(null)
        {
            AddIncludes();

        }
        private void AddIncludes()
        {
            AddInclude(p => p.doctor);
            AddInclude(p => p.Patient);
        }
    }
}
