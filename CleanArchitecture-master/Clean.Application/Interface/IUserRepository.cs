using Clean.Application.Dtos;
using Clean.Application.Dtos.Users;

namespace Clean.Application.Interface
{
    public interface IUserRepository
    {
        public Task<ResponseDto> CreateUser(AddUserDto addUserDto);
        public Task<ResponseDto> UpdateUser(EditUserDto editUserDto);
        public Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string searchString, bool includeDeleted);
        public Task<ResponseDto> GetUserById(int id);
        public Task<ResponseDto> DeleteUser(int id);
        public Task<ResponseDto> RestoreUser(int id);

    }
}
