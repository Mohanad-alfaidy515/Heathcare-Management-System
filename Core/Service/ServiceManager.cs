using AutoMapper;
using Domain.Contract;
using Microsoft.AspNetCore.Identity;
using ServiceAbstractions;
using Domain.Models;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDoctorService> _doctorService;
        private readonly Lazy<IAppointmentService> _appointmentService;
        private readonly Lazy<IPatientService> _patientService;
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<IMedicalRecordService> _medicalRecordService;
        private readonly Lazy<ISchedulingService> _schedulingService;
        private readonly Lazy<IInvoiceService> _invoiceService;

        public ServiceManager(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService)
        {
            _doctorService = new Lazy<IDoctorService>(() => new DoctorService(unitOfWork, mapper));
            _appointmentService = new Lazy<IAppointmentService>(() => new AppointmentService(unitOfWork, mapper));
            _patientService = new Lazy<IPatientService>(() => new PatientService(unitOfWork, mapper));
            _authService = new Lazy<IAuthService>(() => new AuthService(userManager, roleManager, tokenService));
            _medicalRecordService = new Lazy<IMedicalRecordService>(() => new MedicalRecordService(unitOfWork, mapper));
            _schedulingService = new Lazy<ISchedulingService>(() => new SchedulingService(unitOfWork));
            _invoiceService = new Lazy<IInvoiceService>(() => new InvoiceService(unitOfWork, mapper));
        }

        public IDoctorService doctorService => _doctorService.Value;
        public IAppointmentService appointmentService => _appointmentService.Value;
        public IPatientService PatientService => _patientService.Value;
        public IAuthService AuthService => _authService.Value;
        public IMedicalRecordService MedicalRecordService => _medicalRecordService.Value;
        public ISchedulingService SchedulingService => _schedulingService.Value;
        public IInvoiceService InvoiceService => _invoiceService.Value;
    }
}
