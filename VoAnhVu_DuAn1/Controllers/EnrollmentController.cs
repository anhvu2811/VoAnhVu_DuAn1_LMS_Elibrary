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
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-enrollments")]
        public IActionResult getAllEnrollment()
        {
            try
            {
                var enrollment = _enrollmentService.getAllEnrollment().ToList();
                if (!enrollment.Any())
                {
                    return BadRequest("Không có.");
                }
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-enrollment")]
        public IActionResult createEnrollment(EnrollmentModel enrollment)
        {
            try
            {
                var kt = _enrollmentService.getAllEnrollment().Where(c => c.EnrollmentId == enrollment.EnrollmentId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                EnrollmentEntity enrollmentEntity = new EnrollmentEntity
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    UserId = enrollment.User.UserId,
                    SubjectId = enrollment.Subject.SubjectId
                };
                _enrollmentService.createEnrollment(enrollmentEntity);
                return Ok(enrollmentEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-enrollment")]
        public IActionResult updateEnrollment(EnrollmentModel enrollment)
        {
            try
            {
                EnrollmentEntity enrollmentEntity = new EnrollmentEntity
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    UserId = enrollment.User.UserId,
                    SubjectId = enrollment.Subject.SubjectId
                };
                _enrollmentService.updateEnrollment(enrollmentEntity);
                return Ok(enrollmentEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-enrollment")]
        public IActionResult deleteEnrollment(string id)
        {
            try
            {
                var enrollment = _enrollmentService.deleteEnrollment(id);
                if (!enrollment)
                {
                    return BadRequest("Không tìm thấy để xóa.");
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
