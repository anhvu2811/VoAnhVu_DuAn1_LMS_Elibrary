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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;
        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-questions")]
        public IActionResult getAllQuestionExam()
        {
            try
            {
                var ques = _questionsService.getAllQuestionExam().ToList();
                if (!ques.Any())
                {
                    return BadRequest("Không có câu hỏi nào.");
                }
                return Ok(ques);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-questions")]
        public IActionResult createQuestionExam(QuestionsModel ques)
        {
            try
            {
                var kt = _questionsService.getAllQuestionExam().Where(c => c.QuestionId == ques.QuestionId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                QuestionsEntity questionExamEntity = new QuestionsEntity
                {
                    QuestionId = ques.QuestionId,
                    QuestionType = ques.QuestionType,
                    QuestionName = ques.QuestionName,
                    QuestionBankId = ques.QuestionBank.QuestionBankId,
                };
                _questionsService.createQuestionExam(questionExamEntity);
                return Ok(questionExamEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-questions")]
        public IActionResult updateQuestionExam(QuestionsModel ques)
        {
            try
            {
                QuestionsEntity questionExamEntity = new QuestionsEntity
                {
                    QuestionId = ques.QuestionId,
                    QuestionType = ques.QuestionType,
                    QuestionName = ques.QuestionName,
                    QuestionBankId = ques.QuestionBank.QuestionBankId,
                };
                _questionsService.updateQuestionExam(questionExamEntity);
                return Ok(questionExamEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-questions")]
        public IActionResult deleteQuestionExam(string id)
        {
            try
            {
                var ques = _questionsService.deleteQuestionExam(id);
                if (!ques)
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
