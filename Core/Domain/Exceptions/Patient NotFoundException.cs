using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class Patient_NotFoundException(int id):NotFoundException($"this patient id{id}  Not Found!! ")
    {
    }
}
