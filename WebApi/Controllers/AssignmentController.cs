using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        UnitOfWork unitOfWork = new();

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignmentsByTenent(int id)
        {
            try
            {
                return Ok(await unitOfWork.AssignmentRepository.GetAssignmentsByTenent(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAssignment(Assignment assignment)
        {
            try
            {
                await unitOfWork.AssignmentRepository.Insert(assignment);
                await unitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssignment(Assignment assignment)
        {
            try
            {
                await unitOfWork.AssignmentRepository.Update(assignment);
                await unitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            try
            {
                await unitOfWork.AssignmentRepository.Delete(id);
                await unitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAssignment(Assignment assignment)
        {
            try
            {
                await unitOfWork.AssignmentRepository.Delete(assignment);
                await unitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
