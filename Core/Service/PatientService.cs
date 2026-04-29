using AutoMapper;
using Domain.Contract;
using Domain.Exceptions;
using Domain.Models;
using ServiceAbstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PatientService(IUniteOfWork uniteOfWork,IMapper mapper) : IPatientService
    {
        public async Task<IEnumerable<PatientDto>> GetAllPatients()
        {
           var patients=await uniteOfWork.GetRepoistory<Patient, int>().GetAllAsync();
            var result= mapper.Map<IEnumerable<PatientDto>>(patients);
            return result;
        }
       
     

        public async Task<PatientDto> GetPatientById(int id)
        {
            var patients=await  uniteOfWork.GetRepoistory<Patient, int>().GetByIdAsync(id);
            if (patients == null || patients.IsDeleted)
                throw new Patient_NotFoundException(id);
            return mapper.Map<PatientDto>(patients);
        }

        public async Task<bool> UpdateStatus(int id, PatientDto patient)
        {
            var patientEntity = mapper.Map<Patient>(patient);
             uniteOfWork.GetRepoistory<Patient,int>().Update(id, patientEntity);
            await uniteOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteStatus(int id)
        {
            //var patientEntity = mapper.Map<Patient>(patientDto);
            var patient = await uniteOfWork.GetRepoistory<Patient, int>().GetByIdAsync(id);
            if (patient == null) return false;
            patient.isDelete=true;
            uniteOfWork.GetRepoistory<Patient, int>().Update(id,patient);
            await uniteOfWork.SaveChangesAsync();
            return true;


        }

    }
}
