using Clean.Application.Dtos;
using Clean.Application.Dtos.Auth;
using Clean.Application.Services.Auths;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService) {
            this.authService = authService;
        }
        [HttpPost("Login")]
        public async Task<ResponseDto> login(LoginDto loginDto)
        {
            return await this.authService.Login(loginDto);
        }
        [HttpPost("SendOTPSMS")]
        public async Task<ResponseDto> SendOTPSMS(LoginDto loginDto)
        {
            return await this.authService.SendOTPSMS(loginDto);
        }

        [HttpPost("Signup")]
        public async Task<ResponseDto> Signup(SignupDto signupDto)
        {
            return await this.authService.Signup(signupDto);
        }
    }
}
