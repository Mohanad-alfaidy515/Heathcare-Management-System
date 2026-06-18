using ServiceAbstractions;

namespace ServiceAbstractions
{
    public interface IServiceManager
    {
        IDoctorService doctorService { get; }
        IAppointmentService appointmentService { get; }
        IPatientService PatientService { get; }
        IAuthService AuthService { get; }
        IMedicalRecordService MedicalRecordService { get; }
        ISchedulingService SchedulingService { get; }
        IInvoiceService InvoiceService { get; }
    }
}
