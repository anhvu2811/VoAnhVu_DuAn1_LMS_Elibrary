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
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;
        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-lectures")]
        public IActionResult getAllLecture()
        {
            try
            {
                var lecture = _lectureService.getAllLecture().ToList();
                if (!lecture.Any())
                {
                    return BadRequest("Không có bài giảng nào.");
                }
                return Ok(lecture);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-lecture")]
        public IActionResult createLecture(LectureModel lecture)
        {
            try
            {
                var kt = _lectureService.getAllLecture().Where(c => c.LectureId == lecture.LectureId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                LectureEntity lectureEntity = new LectureEntity
                {
                    LectureId = lecture.LectureId,
                    Title = lecture.Title,
                    FileUpload = lecture.FileUpload,
                    Time = lecture.Time,
                    SubjectId = lecture.SubjectId,
                };
                _lectureService.createLecture(lectureEntity);
                return Ok(lectureEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-lecture")]
        public IActionResult updateLecture(LectureModel lecture)
        {
            try
            {
                LectureEntity lectureEntity = new LectureEntity
                {
                    LectureId = lecture.LectureId,
                    Title = lecture.Title,
                    FileUpload = lecture.FileUpload,
                    Time = lecture.Time,
                    SubjectId = lecture.SubjectId
                };
                _lectureService.updateLecture(lectureEntity);
                return Ok(lectureEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-lecture")]
        public IActionResult deleteUser(string id)
        {
            try
            {
                var lecture = _lectureService.deleteLecture(id);
                if (!lecture)
                {
                    return BadRequest("Không tìm thấy bài giảng để xóa.");
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
