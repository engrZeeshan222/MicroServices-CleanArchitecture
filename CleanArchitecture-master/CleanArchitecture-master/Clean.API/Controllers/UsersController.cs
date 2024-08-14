using Clean.Application.Dtos;
using Clean.Application.Dtos.Users;
using Clean.Application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string? searchString, bool includeDeleted)
        {
            return await userService.GetAllUsers(pageNo, pageSize, searchString, includeDeleted);
        }
        [HttpPost]
        public async Task<ResponseDto> AddUser(AddUserDto userDto)
        {
            return await userService.CreateUser(userDto);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            return await this.userService.GetUserById(id);
        }
        [HttpPut]
        public async Task<ResponseDto> UpdateUser(EditUserDto editUserDto)
        {
            return await userService.UpdateUser(editUserDto);
        }

        [HttpDelete]
        public async Task<ResponseDto> DeleteUser(int id)
        {
            return await userService.DeleteUser(id);
        }

        [HttpPut("{id}")]
        public async Task<ResponseDto> RestoreUser(int id)
        {
            return await userService.RestoreUser(id);
        }
    }
}
