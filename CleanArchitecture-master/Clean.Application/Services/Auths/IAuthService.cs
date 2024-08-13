using Clean.Application.Dtos.Auth;
using Clean.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Services.Auths
{
    public interface IAuthService
    {
        public Task<ResponseDto> Signup(SignupDto signupDto);
        public Task<ResponseDto> Login(LoginDto loginDto);
       public Task<ResponseDto> SendOTPSMS(LoginDto loginDto);
    }
}
