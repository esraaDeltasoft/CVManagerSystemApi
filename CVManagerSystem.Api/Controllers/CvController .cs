using CVManagerSystem.Data.Models;
using CVManagerSystem.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CVManagerSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ICvRepository _cvRepository;

        public CvController(ICvRepository cvRepository)
        {
            _cvRepository = cvRepository;
        }

        [HttpGet("GetAllCVs")]
        public async Task<ActionResult<IEnumerable<CV>>> GetAllCVs()
        {
            var result = await _cvRepository.GetAllCVsAsync();
            if (!result.Successed)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return BadRequest(ModelState);
            }
            return Ok(result.Message);
        }

        [HttpGet("GetCVById/{id}")]
        public async Task<ActionResult<CV>> GetCVById([FromRoute]int id)
        {
            var result = await _cvRepository.GetCVByIdAsync(id);
            if (!result.Successed)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return BadRequest(ModelState);
            }
            return Ok(result.Message);
        }

        [HttpPost("CreateCV")]
        public async Task<ActionResult<CV>> CreateCV(CV cv)
        {
            var result = await _cvRepository.CreateCVAsync(cv);
            if (!result.Successed)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return BadRequest(ModelState);
            }
            return Ok(result.Message);
        }

        [HttpPut("UpdateCV/{id}")]
        public async Task<IActionResult> UpdateCV(int id, CV cv)
        {
            if (id != cv.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var result = await _cvRepository.UpdateCVAsync(cv);
            if (!result.Successed)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return BadRequest(ModelState);
            }
            return Ok(result.Message);
        }

        [HttpDelete("DeleteCV/{id}")]
        public async Task<IActionResult> DeleteCV(int id)
        {
            var result = await _cvRepository.DeleteCVAsync(id);
            if (!result.Successed)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return BadRequest(ModelState);
            }
            return Ok(result.Message);
        }
    }
}

