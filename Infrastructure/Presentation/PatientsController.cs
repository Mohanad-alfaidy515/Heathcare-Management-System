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
    public class PatientsController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPatient()
        {
            var result = await serviceManager.PatientService.GetAllPatients();
            if (result is null)
                return BadRequest();
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await serviceManager.PatientService.GetPatientById(id);
            if (result is null)
                return BadRequest();
            return Ok(result);

        }
        [HttpPut("profile")]
       public async Task<IActionResult>UpdatePatientProfile(int id,PatientDto patientDto)
        {
            var result = await serviceManager.PatientService.UpdateStatus(id, patientDto);
            if (!result)
                return BadRequest();
            return Ok(result);

        }
        [HttpDelete("profile")]
        public async Task<IActionResult>DeletePatientProfile(int id)
        {
            var result=await serviceManager.PatientService.DeleteStatus(id);
            if(!result)
                return BadRequest();
            return Ok(result);  
        }



    }
}
