using AutoMapper;
using Domain.Contract;
using Domain.Exceptions;
using Domain.Models;
using Service.Specifications;
using ServiceAbstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DoctorService(IUniteOfWork uniteOfWork,IMapper mapper)
        : IDoctorService
    {
        public async Task<PaginationResponse<DoctoerReturnDto>> GetAllDoctorAsync(DoctorSpecificationsParamters specparm)
        {
            var spec = new DoctorSpecifications(specparm);
          //throught repoistory 
         var doctors= await uniteOfWork.GetRepoistory<Doctor,int>().GetAllAsync(spec);
            var speccount = new DoctorCountSpecifications(specparm);
            var count=await uniteOfWork.GetRepoistory<Doctor,int>().CountASYNC(speccount);
            //mapping 
           var resuult= mapper.Map<IEnumerable<DoctoerReturnDto>>(doctors);
            return  new PaginationResponse<DoctoerReturnDto>(specparm._pageIndex,specparm._pageSize, count, resuult);
            
        }

        public async Task<DoctoerReturnDto?> GetDoctrByIdAsync(int id)
        {
            //var spec=new DoctorSpecifications(id);
          
           var doctor=await uniteOfWork.GetRepoistory<Doctor,int>().GetByIdAsync(id);   
            if(doctor is null ) throw new DoctorNotFoundException(id);
           var result= mapper.Map<DoctoerReturnDto>(doctor);
            return result;
        }

        public async Task<IEnumerable<SpecializationReturnDto>> GetSpecializationAsync()
        {
            var specialization=await  uniteOfWork.GetRepoistory<Specialization,int>().GetAllAsync();
            var result= mapper.Map<IEnumerable<SpecializationReturnDto>>(specialization);
            return result;
        }
    }
}
