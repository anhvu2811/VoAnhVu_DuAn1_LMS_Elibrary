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
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-topic")]
        public IActionResult getAllTopic()
        {
            try
            {
                var topic = _topicService.getAllTopic().ToList();
                if (!topic.Any())
                {
                    return BadRequest("Không có chủ đề nào.");
                }
                return Ok(topic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/[Controller]/create-topic")]
        public IActionResult createTopic(TopicModel topic)
        {
            try
            {
                var kt = _topicService.getAllTopic().Where(c => c.TopicId == topic.TopicId);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại ! Hãy nhập mã khác");
                }
                TopicEntity topicEntity = new TopicEntity
                {
                    TopicId = topic.TopicId,
                    TopicName = topic.TopicName,
                    Description = topic.Description,
                };
                _topicService.createTopic(topicEntity);
                return Ok(topicEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-topic")]
        public IActionResult updateTopic(TopicModel topic)
        {
            try
            {
                TopicEntity topicEntity = new TopicEntity
                {
                    TopicId = topic.TopicId,
                    TopicName = topic.TopicName,
                    Description = topic.Description,
                };
                _topicService.updateTopic(topicEntity);
                return Ok(topic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-topic")]
        public IActionResult deleteTopic(string id)
        {
            try
            {
                bool topic = _topicService.deleteTopic(id);
                if (!topic)
                {
                    return BadRequest("Không tìm thấy chủ đề để xóa!");
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
