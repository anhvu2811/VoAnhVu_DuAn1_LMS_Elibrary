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
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-exam")]
        public IActionResult getAllExam()
        {
            try
            {
                var exam = _examService.getAllExam().ToList();
                if (!exam.Any())
                {
                    return BadRequest("Không có đề thi nào.");
                }
                return Ok(exam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/[Controller]/create-exam")]
        public IActionResult createExam(ExamModel exam)
        {
            try
            {
                var kt = _examService.getAllExam().Where(c => c.ExamId == exam.ExamId);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại ! Hãy nhập mã khác");
                }
                ExamEntity examEntity = new ExamEntity
                {
                    ExamId = exam.ExamId,
                    ExamName = exam.ExamName,
                    StartTime = exam.StartTime,
                    EndTime = exam.EndTime,
                    Description = exam.Description
                };
                _examService.createExam(examEntity);
                return Ok(examEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-role")]
        public IActionResult updateExam(ExamModel exam)
        {
            try
            {
                ExamEntity examEntity = new ExamEntity
                {
                    ExamId = exam.ExamId,
                    ExamName = exam.ExamName,
                    StartTime = exam.StartTime,
                    EndTime = exam.EndTime,
                    Description = exam.Description
                };
                _examService.updateExam(examEntity);
                return Ok(examEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-exam")]
        public IActionResult deleteExam(string id)
        {
            try
            {
                bool exam = _examService.deleteExam(id);
                if (!exam)
                {
                    return BadRequest("Không tìm thấy ngân hàng câu hỏi để xóa!");
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
