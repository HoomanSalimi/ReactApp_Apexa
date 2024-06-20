using Application.Service;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ReactApexa.Server.Controllers
{
    [Route("api/Advisor")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        private readonly IAdvisorService _advisor;

        public AdvisorController(IAdvisorService advisor)
        {
            _advisor = advisor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdvisor()
        {
            var x = await _advisor.GetAllAdvisor();
            if (x != null)
            {
                return Ok(x.ToList());
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdvisorById(int id)
        {
            var x = await _advisor.GetAdvisorById(id);
            if (x != null)
            {
                return Ok(x);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvisor(Advisor advisor)
        {
            var x = await _advisor.CreateAdvisor(advisor);
            if (x==null)
            {
                return NoContent();
            }
            return CreatedAtAction(nameof(GetAllAdvisor), new { id = x.AdvisorId }, x);

        }


        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateAdvior(int id, Advisor advisor)
        {
            int x = await _advisor.UpdateAdvisor(id, advisor);
            if (x==0)
            {
                return NoContent();
            }
            return Ok();
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteAdvisor(int id)
        {
            int x = await _advisor.DeleteAdvisor(id);
            if (x==0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
