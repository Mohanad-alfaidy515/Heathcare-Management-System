using Shared;

namespace ServiceAbstractions
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordDto createDto);
        Task<MedicalRecordDto?> GetMedicalRecordByIdAsync(int id);
        Task<IEnumerable<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId);
    }
}
