using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AppointmentException(int id):NotFoundException($"this appointment id{id} not found!!")
    {
    }
}
