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
    public class DoctorsController(IServiceManager serviceManager):ControllerBase
    {
        [HttpGet]//Get:api/Doctors
        public async Task<IActionResult>GetAllDoctors([FromQuery]DoctorSpecificationsParamters specparm)
        {
           var result=await serviceManager.doctorService.GetAllDoctorAsync(specparm);
            if (result is null) return BadRequest();//400
            return Ok(result);//200
            
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetDictorByIdAsync(int id)
        {
          var result=await  serviceManager.doctorService.GetDoctrByIdAsync(id);
            if (result is null) return BadRequest(); 
            return Ok(result);
        }
        [HttpGet("Specialization")]
        public async Task<IActionResult>GetAllSpecilzation()
        {
           var result=await serviceManager.doctorService.GetSpecializationAsync();
            if (result is null) return BadRequest();
            return Ok(result);
        }

    }
}
