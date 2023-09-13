using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Services;

namespace VoAnhVu_DuAn1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAllRole()
        {
            var role = _roleService.GetAllRoles();
            return Ok(role);
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            _roleService.AddRole(role);
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteRole(int id)
        {
            try
            {
                _roleService.DeleteRole(id);
                return Ok("Xóa thành công.");
            }
            catch
            {
                return Ok("Xóa không thành công.");
            }
        }
        [HttpPut("id")]
        public IActionResult UpdateRole(int id, Role updateRole)
        {
            try
            {
                _roleService.UpdateRole(id, updateRole);
                return Ok("Sửa thành công.");
            }
            catch
            {
                return Ok("Sửa không thành công.");
            }
        }
    }
}
