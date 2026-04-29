using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Patient:BaseEntity<int>
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string PhoneNumber {  get; set; }
        public bool isDelete {  get; set; }=false;
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
