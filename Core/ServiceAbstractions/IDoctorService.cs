using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface IDoctorService
    {
        Task<PaginationResponse<DoctoerReturnDto>>  GetAllDoctorAsync(DoctorSpecificationsParamters specparm);
        Task<DoctoerReturnDto?>GetDoctrByIdAsync(int  id);
        Task<IEnumerable<SpecializationReturnDto>> GetSpecializationAsync();


    }
}
