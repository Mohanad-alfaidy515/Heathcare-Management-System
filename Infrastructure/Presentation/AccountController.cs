using Microsoft.AspNetCore.Mvc;
using ServiceAbstractions;
using Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await serviceManager.AuthService.RegisterAsync(registerDto);
            if (!result.IsAuthenticated) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await serviceManager.AuthService.LoginAsync(loginDto);
            if (!result.IsAuthenticated) return Unauthorized(result.Message);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenRequestDto tokenRequestDto)
        {
            var result = await serviceManager.AuthService.RefreshTokenAsync(tokenRequestDto);
            if (!result.IsAuthenticated) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var result = await serviceManager.AuthService.ForgotPasswordAsync(forgotPasswordDto);
            return Ok(new { Message = "If the email is registered, a reset link has been sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var result = await serviceManager.AuthService.ResetPasswordAsync(resetPasswordDto);
            if (!result) return BadRequest("Error resetting password.");
            return Ok(new { Message = "Password has been reset successfully." });
        }
    }
}
