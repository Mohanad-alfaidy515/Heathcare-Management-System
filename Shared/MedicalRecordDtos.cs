namespace Shared
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public List<PrescriptionDto> Prescriptions { get; set; } = new();
        public List<MedicalTestDto> MedicalTests { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }

    public class CreateMedicalRecordDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public List<CreatePrescriptionDto> Prescriptions { get; set; } = new();
        public List<CreateMedicalTestDto> MedicalTests { get; set; } = new();
    }

    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }

    public class CreatePrescriptionDto
    {
        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }

    public class MedicalTestDto
    {
        public int Id { get; set; }
        public string TestName { get; set; } = string.Empty;
        public string? Result { get; set; }
        public DateTime TestDate { get; set; }
    }

    public class CreateMedicalTestDto
    {
        public string TestName { get; set; } = string.Empty;
        public string? Result { get; set; }
        public DateTime TestDate { get; set; }
    }
}
