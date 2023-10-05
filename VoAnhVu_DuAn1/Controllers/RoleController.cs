using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Service;

namespace VoAnhVu_DuAn1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Lãnh đạo")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-role")]
        public IActionResult getAllRole()
        {
            try
            {
                var role = _roleService.getAllRole().ToList();
                if (!role.Any())
                {
                    return BadRequest("Không có vai trò nào.");
                }
                return Ok(role);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("/api/[Controller]/create-role")]
        public IActionResult createRole(RoleModel role)
        {
            try
            {
                var kt = _roleService.getAllRole().Where(c => c.RoleId == role.RoleId);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại ! Hãy nhập mã khác");
                }
                RoleEntity roleEntity = new RoleEntity
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Description = role.Description,
                };
                _roleService.createRole(roleEntity);
                return Ok(roleEntity);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-role")]
        public IActionResult updateRole(RoleModel role)
        {
            try
            {
                RoleEntity rl = new RoleEntity
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Description = role.Description,
                };
                _roleService.updateRole(rl);
                return Ok(rl);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-role")]
        public IActionResult deleteRole(string id)
        {
            try
            {
                bool role = _roleService.deleteRole(id);
                if (!role)
                {
                    return BadRequest("Không tìm thấy vai trò để xóa!");
                }
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("/api/[Controller]/get-role-by-id")]
        //public IActionResult getRoleById(string id)
        //{
        //    try
        //    {
        //        var role = _roleService.getRoleById(id);
        //        if (role is null)
        //        {
        //            return BadRequest("Không có vai trò.");
        //        }
        //        return Ok(role);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        //[HttpGet]
        //[Route("/api/[Controller]/search-role")]
        //public IActionResult searchRole(string key)
        //{
        //    try
        //    {
        //        var role = _roleService.searchRole(key).ToList();
        //        if (!role.Any())
        //        {
        //            return BadRequest("Không tìm thấy vai trò.");
        //        }
        //        return Ok(role);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
