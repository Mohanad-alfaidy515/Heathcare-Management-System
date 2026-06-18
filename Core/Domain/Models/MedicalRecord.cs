namespace Domain.Models
{
    public class MedicalRecord : BaseEntity<int>
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public string Diagnosis { get; set; } = string.Empty;
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
        public virtual ICollection<MedicalTest> MedicalTests { get; set; } = new HashSet<MedicalTest>();
    }

    public class Prescription : BaseEntity<int>
    {
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;
        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }

    public class MedicalTest : BaseEntity<int>
    {
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;
        public string TestName { get; set; } = string.Empty;
        public string? Result { get; set; }
        public DateTime TestDate { get; set; }
    }
}
