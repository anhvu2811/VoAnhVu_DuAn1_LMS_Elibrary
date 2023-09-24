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
    [Authorize]
    public class HelpController : ControllerBase
    {
        private readonly IHelpService _helpService;
        public HelpController(IHelpService helpService)
        {
            _helpService = helpService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-help")]
        public IActionResult getAllHelp()
        {
            try
            {
                var help = _helpService.getAllHelp().ToList();
                if (!help.Any())
                {
                    return BadRequest("Không có trợ giúp nào.");
                }
                return Ok(help);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-help")]
        public IActionResult createHelp(HelpModel help)
        {
            try
            {
                var kt = _helpService.getAllHelp().Where(c => c.HelpId == help.HelpId);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                HelpEntity helpEntity = new HelpEntity
                {
                    HelpId = help.HelpId,
                    Title = help.Title,
                    Content = help.Content
                };
                _helpService.createHelp(helpEntity);
                return Ok(helpEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-help")]
        public IActionResult updateHelp(HelpModel help)
        {
            try
            {
                HelpEntity helpEntity = new HelpEntity
                {
                    HelpId = help.HelpId,
                    Title = help.Title,
                    Content = help.Content
                };
                _helpService.updateHelp(helpEntity);
                return Ok(helpEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-help")]
        public IActionResult deleteHelp(string id)
        {
            try
            {
                var help = _helpService.deleteHelp(id);
                if (!help)
                {
                    return BadRequest("Không tìm thấy trợ giúp để xóa.");
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
