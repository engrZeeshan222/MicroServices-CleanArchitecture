using Clean.Application.Dtos;
using Clean.Application.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Interface
{
    public interface IAuthRepository
    {
        public Task<ResponseDto> Signup(SignupDto signupDto);
        public Task<ResponseDto> Login(LoginDto loginDto);
        public Task<ResponseDto> SendOTPSMS(LoginDto loginDto);
    }
}
