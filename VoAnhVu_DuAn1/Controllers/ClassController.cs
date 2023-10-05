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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-class")]
        public IActionResult getAllClass()
        {
            try
            {
                var role = _classService.getAllClass().ToList();
                if (!role.Any())
                {
                    return BadRequest("Không có lớp nào.");
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/[Controller]/create-class")]
        public IActionResult createClass(ClassModel Class)
        {
            try
            {
                var kt = _classService.getAllClass().Where(c => c.ClassId == Class.ClassId);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại ! Hãy nhập mã khác");
                }
                ClassEntity classEntity = new ClassEntity
                {
                    ClassId = Class.ClassId,
                    ClassName = Class.ClassName
                };
                _classService.createClass(classEntity);
                return Ok(classEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-class")]
        public IActionResult updateClass(ClassModel Class)
        {
            try
            {
                ClassEntity classEntity = new ClassEntity
                {
                    ClassId = Class.ClassId,
                    ClassName = Class.ClassName
                };
                _classService.updateClass(classEntity);
                return Ok(classEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-class")]
        public IActionResult deleteClass(string id)
        {
            try
            {
                bool cl = _classService.deleteClass(id);
                if (!cl)
                {
                    return BadRequest("Không tìm thấy lớp học để xóa!");
                }
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
