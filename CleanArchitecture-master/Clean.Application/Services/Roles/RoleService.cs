using Clean.Application.Dtos;
using Clean.Application.Dtos.Roles;
using Clean.Application.Interface;

namespace Clean.Application.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public async Task<ResponseDto> CreateRole(AddRoleDto addRoleDto)
        {
            return await this.roleRepository.CreateRole(addRoleDto);
        }

        public async Task<ResponseDto> DeleteRole(int id)
        {
            return await this.roleRepository.DeleteRole(id);
        }

        public async Task<ResponseDto> GetAllRole(int pageNo, int pageSize, string searchString, bool includeDeleted)
        {
            return await this.roleRepository.GetAllRole(pageNo, pageSize, searchString, includeDeleted);
        }

        public async Task<ResponseDto> GetRoleById(int id)
        {
            return await this.roleRepository.GetRoleById(id);  
        }

        public async Task<ResponseDto> RestoreRole(int id)
        {
            return await this.roleRepository.RestoreRole(id);
        }

        public async Task<ResponseDto> UpdateRole(EditRoleDto editRoleDto)
        {
           return await this.roleRepository.UpdateRole(editRoleDto);
        }


    }
}
