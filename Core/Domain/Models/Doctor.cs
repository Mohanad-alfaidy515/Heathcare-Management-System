using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Doctor:BaseEntity<int>
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Title {  get; set; }
        public string bio { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization {  get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
       
    }
}
