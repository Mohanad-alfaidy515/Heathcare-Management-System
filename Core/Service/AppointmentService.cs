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
    public class AppointmentService(IUniteOfWork uniteOfWork,IMapper mapper) : IAppointmentService
    {
        public async Task<AppointmentDto> AddAppointment(AppointmentDto appointment)
        {
            var appoinmentEntity = mapper.Map<Appointment>(appointment);
            await uniteOfWork.GetRepoistory<Appointment, int>().AddSync(appoinmentEntity) ;
           await uniteOfWork.SaveChangesAsync();
            var spec = new AppointmentSpecification(appoinmentEntity.Id);
            var result = await uniteOfWork.GetRepoistory<Appointment, int>().GetByIdAsync(spec,appoinmentEntity.Id);
            return mapper.Map<AppointmentDto>(result);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointment()
        {
            var spec = new AppointmentSpecification();
           var appointments= await uniteOfWork.GetRepoistory<Appointment, int>().GetAllAsync(spec);
           var result= mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return result;
        }

        public async Task<AppointmentDto> GetAppointmentById(int id)
        {
           var appointments=await uniteOfWork.GetRepoistory<Appointment, int>().GetByIdAsync(id);
            if(appointments is null)throw new AppointmentException(id);
           var result= mapper.Map<AppointmentDto>(appointments);
            return result;
        }
    }
}
