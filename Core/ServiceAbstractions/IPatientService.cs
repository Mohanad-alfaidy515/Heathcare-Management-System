using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatients();
        Task<PatientDto>GetPatientById(int id);
        Task<bool>UpdateStatus(int id, PatientDto patient);
        Task<bool>DeleteStatus(int id);
    }
}
