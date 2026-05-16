using Domain.Models;
using Shared;

namespace Service.MappingProfile
{
    public class MedicalRecordProfile : AutoMapper.Profile
    {
        public MedicalRecordProfile()
        {
            CreateMap<MedicalRecord, MedicalRecordDto>()
                .ForMember(d => d.PatientName, o => o.MapFrom(s => $"{s.Patient.FirstName} {s.Patient.LastName}"))
                .ForMember(d => d.DoctorName, o => o.MapFrom(s => $"{s.Doctor.FirstName} {s.Doctor.LastName}"))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreateAt));

            CreateMap<CreateMedicalRecordDto, MedicalRecord>();

            CreateMap<Prescription, PrescriptionDto>();
            CreateMap<CreatePrescriptionDto, Prescription>();

            CreateMap<MedicalTest, MedicalTestDto>();
            CreateMap<CreateMedicalTestDto, MedicalTest>();
        }
    }
}
