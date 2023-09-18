using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Service;

namespace VoAnhVu_DuAn1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AuthenticationService _authenticationService;

        public UserController(IUserService userService, AuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("/api/[Controller]/login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _userService.GetUserByUsernameAndPassword(model.Username, model.Password);
            if (user == null)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = _authenticationService.GenerateToken(user)
            });
        }

        [HttpGet]
        [Route("/api/[Controller]/get-all-users")]
        public IActionResult getAllUser()
        {
            try
            {
                var user = _userService.getAllUser().ToList();
                if(!user.Any())
                {
                    return BadRequest("Không có người dùng nào.");
                }
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-user-by-id")]
        public IActionResult getUserById(string id)
        {
            try
            {
                var user = _userService.getUserById(id);
                if(user is null)
                {
                    return BadRequest("Không tìm thấy người dùng.");
                }
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/search-user")]
        public IActionResult searchUser(string key)
        {
            try
            {
                var user = _userService.searchUser(key).ToList();
                if (!user.Any())
                {
                    return BadRequest("Không tìm thấy người dùng.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-user")]
        public IActionResult createUser(UserModel user)
        {
            try
            {
                var kt = _userService.getAllUser().Where(c => c.UserId == user.UserId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                UserEntity userEntity = new UserEntity
                {
                    UserId = user.UserId,
                    Avatar = user.Avatar,
                    FullName = user.FullName,
                    Gender = user.Gender,
                    Email = user.Email,
                    Phone = user.Phone,
                    Address = user.Address,
                    Username = user.Username,
                    Password = user.Password,
                    RoleId = user.RoleId,
                };
                _userService.createUser(userEntity);
                return Ok(userEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-user")]
        public IActionResult updateUser(UserModel user)
        {
            try
            {
                UserEntity userEntity = new UserEntity
                {
                    UserId = user.UserId,
                    Avatar = user.Avatar,
                    FullName = user.FullName,
                    Gender = user.Gender,
                    Email = user.Email,
                    Phone = user.Phone,
                    Address = user.Address,
                    Username = user.Username,
                    Password = user.Password,
                    RoleId = user.RoleId
                };
                _userService.updateUser(userEntity);
                return Ok(userEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-user")]
        public IActionResult deleteUser(string id)
        {
            try
            {
                var user = _userService.deleteUser(id);
                if (!user)
                {
                    return BadRequest("Không tìm thấy người dùng để xóa.");
                }
                return Ok("Xóa thành công."); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
