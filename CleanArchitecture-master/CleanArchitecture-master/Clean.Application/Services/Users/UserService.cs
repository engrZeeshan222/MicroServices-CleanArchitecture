using Clean.Application.Dtos;
using Clean.Application.Dtos.Users;
using Clean.Application.Interface;

namespace Clean.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ResponseDto> CreateUser(AddUserDto addUserDto)
        {
          return  await this.userRepository.CreateUser(addUserDto);
        }

        public Task<ResponseDto> DeleteUser(int id)
        {
           return this.userRepository.DeleteUser(id);
        }

        public async Task<ResponseDto> GetAllUsers(int pageNo, int pageSize, string searchString, bool includeDeleted)
        {
           return await this.userRepository.GetAllUsers(pageNo, pageSize, searchString, includeDeleted);
        }

        public async Task<ResponseDto> GetUserById(int id)
        {
            return await this.userRepository.GetUserById(id);
        }

        public async Task<ResponseDto> RestoreUser(int id)
        {
           return await this.userRepository.RestoreUser(id);
        }

        public async Task<ResponseDto> UpdateUser(EditUserDto editUserDto)
        {
            return await this.userRepository.UpdateUser(editUserDto);
        }
    }
}
