using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractions;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SchedulingController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet("available-slots")]
        public async Task<IActionResult> GetAvailableSlots(int doctorId, DateTime date)
        {
            var result = await serviceManager.SchedulingService.GetAvailableSlotsAsync(doctorId, date);
            return Ok(result);
        }

        [HttpPost("availability")]
        [Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> AddAvailability(DoctorAvailability availability)
        {
            var result = await serviceManager.SchedulingService.AddAvailabilityAsync(availability);
            return Ok(result);
        }
    }
}
