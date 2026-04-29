using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AppointmentDto
    {
        public int Id { get; set; }
       
        public string doctor { get; set; }
       
        public string Patient { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
