using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractions;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MedicalRecordsController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> Create(CreateMedicalRecordDto createDto)
        {
            var result = await serviceManager.MedicalRecordService.CreateMedicalRecordAsync(createDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await serviceManager.MedicalRecordService.GetMedicalRecordByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatientId(int patientId)
        {
            var result = await serviceManager.MedicalRecordService.GetMedicalRecordsByPatientIdAsync(patientId);
            return Ok(result);
        }
    }
}
