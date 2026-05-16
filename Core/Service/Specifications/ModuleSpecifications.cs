using Domain.Models;
using Service.Specifications;

namespace Service.Specifications
{
    public class MedicalRecordWithDetailsSpecification : BaseSpecification<MedicalRecord, int>
    {
        public MedicalRecordWithDetailsSpecification(int id) : base(r => r.Id == id)
        {
            AddInclude(r => r.Patient);
            AddInclude(r => r.Doctor);
            AddInclude(r => r.Prescriptions);
            AddInclude(r => r.MedicalTests);
        }

        public MedicalRecordWithDetailsSpecification(int patientId, bool isPatientId)
            : base(r => r.PatientId == patientId)
        {
            AddInclude(r => r.Patient);
            AddInclude(r => r.Doctor);
            AddInclude(r => r.Prescriptions);
            AddInclude(r => r.MedicalTests);
        }
    }

    public class DoctorAvailabilitySpecification : BaseSpecification<DoctorAvailability, int>
    {
        public DoctorAvailabilitySpecification(int doctorId, DayOfWeek dayOfWeek)
            : base(a => a.DoctorId == doctorId && a.DayOfWeek == dayOfWeek)
        {
        }
    }

    public class AppointmentByDoctorAndDateSpecification : BaseSpecification<Appointment, int>
    {
        public AppointmentByDoctorAndDateSpecification(int doctorId, DateTime date)
            : base(a => a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date)
        {
        }
    }
}
