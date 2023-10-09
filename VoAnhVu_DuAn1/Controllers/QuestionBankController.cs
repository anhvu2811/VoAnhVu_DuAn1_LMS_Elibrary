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
    public class QuestionBankController : ControllerBase
    {
        private readonly IQuestionBankService _questionBankService;
        public QuestionBankController(IQuestionBankService questionBankService)
        {
            _questionBankService = questionBankService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-question-bank")]
        public IActionResult getAllQuestionBank()
        {
            try
            {
                var qb = _questionBankService.getAllQuestionBank().ToList();
                if (!qb.Any())
                {
                    return BadRequest("Không tìm thấy ngân hàng câu hỏi nào.");
                }
                return Ok(qb);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/[Controller]/create-question-bank")]
        public IActionResult createQuestionBank(QuestionBankModel qb)
        {
            try
            {
                var kt = _questionBankService.getAllQuestionBank().Where(c => c.QuestionBankId == qb.QuestionBankId);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại ! Hãy nhập mã khác");
                }
                QuestionBankEntity questionBankEntity = new QuestionBankEntity
                {
                    QuestionBankId = qb.QuestionBankId,
                    QuestionBankName = qb.QuestionBankName,
                    Level = qb.Level
                };
                _questionBankService.createQuestionBank(questionBankEntity);
                return Ok(questionBankEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-question-bank")]
        public IActionResult updateQuestionBank(QuestionBankModel qb)
        {
            try
            {
                QuestionBankEntity questionBankEntity = new QuestionBankEntity
                {
                    QuestionBankId = qb.QuestionBankId,
                    QuestionBankName = qb.QuestionBankName,
                    Level = qb.Level
                };
                _questionBankService.updateQuestionBank(questionBankEntity);
                return Ok(questionBankEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-question-bank")]
        public IActionResult deleteQuestionBank(string id)
        {
            try
            {
                bool qb = _questionBankService.deleteQuestionBank(id);
                if (!qb)
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
