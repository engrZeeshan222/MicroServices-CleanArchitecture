using Clean.Application.Dtos;
using Clean.Application.Dtos.Roles;

namespace Clean.Application.Interface
{
    public interface IRoleRepository
    {
        public Task<ResponseDto> CreateRole(AddRoleDto addRoleDto);
        public Task<ResponseDto> UpdateRole(EditRoleDto editRoleDto);
        public Task<ResponseDto> GetAllRole(int pageNo, int pageSize, string searchString, bool includeDeleted);
        public Task<ResponseDto> GetRoleById(int id);
        public Task<ResponseDto> DeleteRole(int id);
        public Task<ResponseDto> RestoreRole(int id);
    }
}
