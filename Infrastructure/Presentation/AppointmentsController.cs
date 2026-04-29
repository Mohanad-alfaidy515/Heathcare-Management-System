using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController(IServiceManager serviceManager):ControllerBase
    {

        [HttpPost("AddAppointment")]
        public async Task<IActionResult>AddAppointment(AppointmentDto appointmentDto)
        {
           var result=await serviceManager.appointmentService.AddAppointment(appointmentDto);
            if (result is null) return BadRequest();
            return Ok(result);  
        }
        [HttpGet]
        public async Task<IActionResult>GetAllAppointment()
        {
            var result =await serviceManager.appointmentService.GetAllAppointment();
            if (result is null) return BadRequest();
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult>GetAppointmentById(int id)
        {
            var result =await serviceManager.appointmentService.GetAppointmentById(id);   
            if (result is null) return BadRequest();
            return Ok(result);
        }
    }
}
