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
    public class QuestionExamController : ControllerBase
    {
        private readonly IQuestionExamService _questionExamService;
        public QuestionExamController(IQuestionExamService questionExamService)
        {
            _questionExamService = questionExamService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-question-exam")]
        public IActionResult getAllQuestionExam()
        {
            try
            {
                var ques = _questionExamService.getAllQuestionExam().ToList();
                if (!ques.Any())
                {
                    return BadRequest("Không có người dùng nào.");
                }
                return Ok(ques);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-question-exam")]
        public IActionResult createQuestionExam(QuestionExamModel ques)
        {
            try
            {
                var kt = _questionExamService.getAllQuestionExam().Where(c => c.QuestionExamId == ques.QuestionExamId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                QuestionExamEntity questionExamEntity = new QuestionExamEntity
                {
                    QuestionExamId = ques.QuestionExamId,
                    ExamId = ques.Exam.ExamId,
                    QuestionId = ques.Question.QuestionId,
                };
                _questionExamService.createQuestionExam(questionExamEntity);
                return Ok(questionExamEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-question-exam")]
        public IActionResult updateQuestionExam(QuestionExamModel ques)
        {
            try
            {
                QuestionExamEntity questionExamEntity = new QuestionExamEntity
                {
                    QuestionExamId = ques.QuestionExamId,
                    ExamId = ques.Exam.ExamId,
                    QuestionId = ques.Question.QuestionId,
                };
                _questionExamService.updateQuestionExam(questionExamEntity);
                return Ok(questionExamEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-question-exam")]
        public IActionResult deleteUser(string id)
        {
            try
            {
                var ques = _questionExamService.deleteQuestionExam(id);
                if (!ques)
                {
                    return BadRequest("Không tìm thấy đề thi để xóa.");
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
