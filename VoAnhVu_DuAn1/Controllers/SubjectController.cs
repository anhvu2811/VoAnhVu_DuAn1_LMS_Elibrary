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
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService  _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-subjects")]
        public IActionResult getAllSubject()
        {
            try
            {
                var subject = _subjectService.getAllSubject().ToList();
                if (!subject.Any())
                {
                    return BadRequest("Không tìm thấy môn học.");
                }
                return Ok(subject);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/search-subject")]
        public IActionResult searchSubject(string key)
        {
            try
            {
                var subject = _subjectService.searchSubject(key).ToList();
                if (subject == null)
                {
                    return BadRequest("Không tìm thấy môn học.");
                }
                return Ok(subject);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/sort-subject")]
        public IActionResult sortSubject(string sortBy, bool ascending = true)
        {
            try
            {
                var sortedSubjects = _subjectService.sortSubject(sortBy, ascending);
                return Ok(sortedSubjects);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-subject-by-id")]
        public IActionResult getSubjectById(string id)
        {
            try
            {
                var subject = _subjectService.getSubjectById(id);
                if(subject is null)
                {
                    return BadRequest("Không tìm thấy môn học.");
                }
                return Ok(subject);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-subject")]
        public IActionResult createSubject(SubjectModel subject)
        {
            try
            {
                var kt = _subjectService.getAllSubject().Where(c => c.SubjectId == subject.SubjectId);
                if (kt.Any())
                {
                    return BadRequest("Đã tòn tại ID ! Vui lòng nhập mã khác");
                }
                SubjectEntity subjectEntity = new SubjectEntity
                {
                    SubjectId = subject.SubjectId,
                    SubjectName = subject.SubjectName,
                    TopicId = subject.Topic.TopicId,
                };
                _subjectService.createSubject(subjectEntity);
                return Ok(subjectEntity);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-subject")]
        public IActionResult updateSubject(SubjectModel subject)
        {
            try
            {
                SubjectEntity subjectEntity = new SubjectEntity
                {
                    SubjectId = subject.SubjectId,
                    SubjectName = subject.SubjectName,
                    TopicId = subject.Topic.TopicId,
                };
                _subjectService.updateSubject(subjectEntity);
                return Ok(subjectEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-subject")]
        public IActionResult deleteSubject(string id)
        {
            try
            {
                var subject = _subjectService.deleteSubject(id);
                if (!subject)
                {
                    return BadRequest("Không tim thấy mã để xóa.");
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
