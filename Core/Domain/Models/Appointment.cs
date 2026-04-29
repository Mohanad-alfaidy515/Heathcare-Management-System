using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Appointment:BaseEntity<int>
    {
        public int DoctorId {  get; set; }
        public Doctor doctor { get; set; }
        public int PatientId {  get; set; }
        public Patient Patient { get; set; }    
        public AppointmentStatus Status { get; set; }
        public string Notes {  get; set; }
    }
}
