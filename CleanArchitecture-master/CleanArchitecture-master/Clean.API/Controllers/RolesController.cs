using Clean.Application.Dtos;
using Clean.Application.Dtos.Roles;
using Clean.Application.Services.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService) {
            this.roleService = roleService;
        }

        [HttpPost]
        public async Task<ResponseDto> CreateRole(AddRoleDto addRoleDto)
        {
            return await this.roleService.CreateRole(addRoleDto);
        }

        [HttpPut]
        public async Task<ResponseDto> UpdateRole(EditRoleDto editRoleDto)
        {
            return await this.roleService.UpdateRole(editRoleDto);
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto> GetUserById(int id)
        {
            return await this.roleService.GetRoleById(id);
        }

        [HttpGet]
        public async Task<ResponseDto> GetAllRole(int pageNo, int pageSize, string? searchString, bool includeDeleted)
        {
            return await this.roleService.GetAllRole(pageNo, pageSize, searchString, includeDeleted);
        }
        [HttpDelete]
        public async Task<ResponseDto> DeleteRole(int id)
        {
            return await this.roleService.DeleteRole(id);
        }

        [HttpPut("{id}")]
        public async Task<ResponseDto> RestoreRole(int id)
        {
            return await this.roleService.RestoreRole(id);
        }
    }
}
