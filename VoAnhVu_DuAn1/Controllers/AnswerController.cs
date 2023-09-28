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
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-answers")]
        public IActionResult getAllAnswer()
        {
            try
            {
                var answer = _answerService.getAllAnswer().ToList();
                if (!answer.Any())
                {
                    return BadRequest("Không có câu trả lời nào.");
                }
                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-answer")]
        public IActionResult createAnswer(AnswerModel answer)
        {
            try
            {
                var kt = _answerService.getAllAnswer().Where(c => c.AnswerId == answer.AnswerId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                AnswerEntity answerEntity = new AnswerEntity
                {
                    AnswerId = answer.AnswerId,
                    AnswerText = answer.AnswerText,
                    QuestionId = answer.Question.QuestionId,
                };
                _answerService.createAnswer(answerEntity);
                return Ok(answerEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-answer")]
        public IActionResult updateAnswer(AnswerModel answer)
        {
            try
            {
                AnswerEntity answerEntity = new AnswerEntity
                {
                    AnswerId = answer.AnswerId,
                    AnswerText = answer.AnswerText,
                    QuestionId = answer.Question.QuestionId,
                };
                _answerService.updateAnswer(answerEntity);
                return Ok(answerEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-answer")]
        public IActionResult deleteAnswer(string id)
        {
            try
            {
                var answer = _answerService.deleteAnswer(id);
                if (!answer)
                {
                    return BadRequest("Không tìm thấy câu trả lời để xóa.");
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
