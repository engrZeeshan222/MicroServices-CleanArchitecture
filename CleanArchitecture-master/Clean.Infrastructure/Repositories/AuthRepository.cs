using AutoMapper;
using Clean.Application.Dtos;
using Clean.Application.Dtos.Auth;
using Clean.Application.Dtos.Users;
using Clean.Application.Interface;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Clean.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public AuthRepository(ApplicationDbContext db, IMapper mapper, IConfiguration configuration)
        {
            this.db = db;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<ResponseDto> Login(LoginDto loginDto)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var IsExist = await IsUserEmailExist(loginDto.Email);
                if (IsExist != null)
                {
                    var IsPasswordExist = await IsEmailPasswordExist(loginDto);
                    if (IsPasswordExist != null)
                    {
                        var token = GenerateJwtToken(loginDto.Email);
                        var logintoken = new
                        {
                            token
                        };
                        response.Status = true;
                        response.Message = "Success";
                        response.Data = logintoken;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "User Email Or Password is Incorrect";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "User Is Not Exist";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return response;
        }
       public async Task<ResponseDto> SendOTPSMS(LoginDto loginDto)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var IsExist = await IsUserEmailExist(loginDto.Email);
                if (IsExist != null)
                {
                    var IsPasswordExist = await IsEmailPasswordExist(loginDto);
                    if (IsPasswordExist != null)
                    {
                        IsExist.OTP = Generate4DigitNumericOtp();
                       await SendSMS(IsExist.PhoneNumber,IsExist.OTP.ToString());
                        IsExist.OTPExpireTime = DateTime.Now.AddMinutes(5);
                        await db.SaveChangesAsync();
                        response.Status = true;
                        response.Message = "Success";
                        response.Data = IsExist.OTP;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "User Email Or Password is Incorrect";
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "User Is Not Exist";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return response;
        }
        public async Task<ResponseDto> Signup(SignupDto signupDto)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var isExist = await IsUserEmailExist(signupDto.Email);
                if (isExist != null)
                {
                    response.Status = false;
                    response.Message = "User Email Already Exist";
                    return response;
                }
                var user = this.mapper.Map<User>(signupDto);
                await this.db.Users.AddAsync(user);
                await this.db.SaveChangesAsync();
                var token = GenerateJwtToken(signupDto.Email);
                var logintoken = new
                {
                    token
                };
                response.Status = true;
                response.Message = "User Signup Successfully";
                response.Data = logintoken;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return response;
        }

        private string GenerateJwtToken(string Email)
        {
            var authClaims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.configuration["JWTSettings:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: this.configuration["JWTSettings:ValidIssuer"],
                audience: this.configuration["JWTSettings:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
       
        private async Task<User?> IsUserEmailExist(string email)
        {
            return await this.db.Users.Where(x => x.Email.Equals(email) && x.IsActive == true).FirstOrDefaultAsync();
        }

        private async Task<User?> IsEmailPasswordExist(LoginDto loginDto)
        {
            var user = await db.Users.Where(x => x.Email == loginDto.Email).FirstOrDefaultAsync();
            if (user != null && string.Equals(user.Password, loginDto.Password))
            {
                return user;
            }
            return null;
        }
        public static int Generate4DigitNumericOtp()
        {
            Random random = new Random();
            int otp = random.Next(1000, 10000); // Generate a 4-digit OTP
            return otp;
        }
        private async Task SendSMS(string phoneNumber, string message)
        {
            string accountSid = Environment.GetEnvironmentVariable("AC264b62e71db3732ca0ee2e68f2de0fbb");
            string authToken = Environment.GetEnvironmentVariable("ece14c85af895e29927fbb208b476bde");

            TwilioClient.Init(accountSid, authToken);

            var messages = MessageResource.Create(
                body: $"Here Is Your OTP {message}",
                from: new Twilio.Types.PhoneNumber("+13187025120"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );

            Console.WriteLine(messages.Sid);
        }
        private async Task SendWhatsApp(string phoneNumber, string message)
        {
            string accountSid = Environment.GetEnvironmentVariable("AC264b62e71db3732ca0ee2e68f2de0fbb");
            string authToken = Environment.GetEnvironmentVariable("ece14c85af895e29927fbb208b476bde");

            TwilioClient.Init(accountSid, authToken);

            var messages = MessageResource.Create(
                body: $"Here Is Your OTP {message}",
                from: new Twilio.Types.PhoneNumber("whatsapp:++14155238886"),
            to: new Twilio.Types.PhoneNumber($"whatsapp:{phoneNumber}")
            );

            Console.WriteLine(messages.Sid);
        }
    }
}
