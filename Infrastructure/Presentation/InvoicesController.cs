using Domain.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractions;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InvoicesController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateInvoiceDto createDto)
        {
            var result = await serviceManager.InvoiceService.CreateInvoiceAsync(createDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await serviceManager.InvoiceService.GetInvoiceByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetByAppointmentId(int appointmentId)
        {
            var result = await serviceManager.InvoiceService.GetInvoiceByAppointmentIdAsync(appointmentId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, InvoiceStatus status)
        {
            var result = await serviceManager.InvoiceService.UpdateInvoiceStatusAsync(id, status);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
