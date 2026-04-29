using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Specialization:BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors {  get; set; }=new HashSet<Doctor>();    
    }
}
