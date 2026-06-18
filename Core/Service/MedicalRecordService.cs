using AutoMapper;
using Domain.Contract;
using Domain.Models;
using ServiceAbstractions;
using Shared;
using Service.Specifications;

namespace Service
{
    public class MedicalRecordService(IUnitOfWork unitOfWork, IMapper mapper) : IMedicalRecordService
    {
        public async Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordDto createDto)
        {
            var record = mapper.Map<MedicalRecord>(createDto);
            await unitOfWork.GetRepository<MedicalRecord, int>().AddAsync(record);
            await unitOfWork.SaveChangesAsync();

            // Refresh to get details for mapping
            var spec = new MedicalRecordWithDetailsSpecification(record.Id);
            var savedRecord = await unitOfWork.GetRepository<MedicalRecord, int>().GetByIdAsync(spec, record.Id);
            return mapper.Map<MedicalRecordDto>(savedRecord);
        }

        public async Task<MedicalRecordDto?> GetMedicalRecordByIdAsync(int id)
        {
            var spec = new MedicalRecordWithDetailsSpecification(id);
            var record = await unitOfWork.GetRepository<MedicalRecord, int>().GetByIdAsync(spec, id);
            return record == null ? null : mapper.Map<MedicalRecordDto>(record);
        }

        public async Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId)
        {
            var spec = new MedicalRecordWithDetailsSpecification(patientId, true);
            var records = await unitOfWork.GetRepository<MedicalRecord, int>().GetAllAsync(spec);
            return mapper.Map<IEnumerable<MedicalRecordDto>>(records);
        }
    }
}
