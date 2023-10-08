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
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;
        public ExamResultController(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-exam-result")]
        public IActionResult getAllExamResult()
        {
            try
            {
                var result = _examResultService.getAllExamResult().ToList();
                if (!result.Any())
                {
                    return BadRequest("Không có kết quả nào.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-exam-result")]
        public IActionResult createExamResult(ExamResultModel result)
        {
            try
            {
                var kt = _examResultService.getAllExamResult().Where(c => c.ExamResultId == result.ExamResultId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                ExamResultEntity examResultEntity = new ExamResultEntity
                {
                    ExamResultId = result.ExamResultId,
                    UserId = result.User.UserId,
                    ExamId = result.Exam.ExamId,
                    Score = result.Score
                };
                _examResultService.createExamResult(examResultEntity);
                return Ok(examResultEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-exam-result")]
        public IActionResult updateExamResult(ExamResultModel result)
        {
            try
            {
                ExamResultEntity examResultEntity = new ExamResultEntity
                {
                    ExamResultId = result.ExamResultId,
                    UserId = result.User.UserId,
                    ExamId = result.Exam.ExamId,
                    Score = result.Score
                };
                _examResultService.updateExamResult(examResultEntity);
                return Ok(examResultEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-exam-result")]
        public IActionResult deleteExamResult(string id)
        {
            try
            {
                var result = _examResultService.deleteExamResult(id);
                if (!result)
                {
                    return BadRequest("Không tìm thấy kết quả để xóa.");
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
