using Clean.Application.Dtos.Users;
using Clean.Application.Dtos;

namespace Clean.Application.Services.Users
{
    public interface IUserService
    {
        public Task<ResponseDto> CreateUser(AddUserDto addUserDto);
        public Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string searchString, bool includeDeleted);
        public Task<ResponseDto> GetUserById(int id);
        public Task<ResponseDto> UpdateUser(EditUserDto editUserDto);
        public Task<ResponseDto> DeleteUser(int id);
        public Task<ResponseDto> RestoreUser(int id);
    }
}
