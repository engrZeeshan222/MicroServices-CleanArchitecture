using Clean.Application.Dtos;
using Clean.Application.Dtos.Auth;
using Clean.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Services.Auths
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;
        public AuthService(IAuthRepository authRepository) {
            this.authRepository = authRepository;
        }

        public async Task<ResponseDto> Login(LoginDto loginDto)
        {
            return await this.authRepository.Login(loginDto);
        }

        public async Task<ResponseDto> Signup(SignupDto signupDto)
        {
            return await this.authRepository.Signup(signupDto);
        }
        public async Task<ResponseDto> SendOTPSMS(LoginDto loginDto)
        {
            return await this.authRepository.SendOTPSMS(loginDto);
        }
    }
}
