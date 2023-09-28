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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService; 
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-questions")]
        public IActionResult getAllQuestion()
        {
            try
            {
                var question = _questionService.getAllQuestion().ToList();
                if (!question.Any())
                {
                    return BadRequest("Không có câu hỏi nào.");
                }
                return Ok(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-question")]
        public IActionResult createQuestion(QuestionModel question)
        {
            try
            {
                var kt = _questionService.getAllQuestion().Where(c => c.QuestionId == question.QuestionId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                QuestionEntity questionEntity = new QuestionEntity
                {
                    QuestionId = question.QuestionId,
                    QuestionText = question.QuestionText,
                    LectureId = question.Lecture.LectureId,
                    UserId = question.User.UserId
                };
                _questionService.createQuestion(questionEntity);
                return Ok(questionEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-question")]
        public IActionResult updateQuestion(QuestionModel question)
        {
            try
            {
                QuestionEntity questionEntity = new QuestionEntity
                {
                    QuestionId = question.QuestionId,
                    QuestionText = question.QuestionText,
                    LectureId = question.Lecture.LectureId,
                    UserId = question.User.UserId
                };
                _questionService.updateQuestion(questionEntity);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-question")]
        public IActionResult deleteQuestion(string id)
        {
            try
            {
                var user = _questionService.deleteQuestion(id);
                if (!user)
                {
                    return BadRequest("Không tìm thấy câu hỏi để xóa.");
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
