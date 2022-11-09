using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenentController : ControllerBase
    {
        UnitOfWork unitOfWork = new();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenent>>> GetTenents()
        {
            try
            {
                return Ok(await unitOfWork.TenentRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTenent(Tenent tenent)
        {
            try
            {
                await unitOfWork.TenentRepository.Insert(tenent);
                await unitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTenent(Tenent tenent)
        {
            try
            {
                await unitOfWork.TenentRepository.Update(tenent);
                await unitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenent(int id)
        {
            try
            {
                await unitOfWork.TenentRepository.Delete(id);
                await unitOfWork.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTenent(Tenent tenent)
        {
            try
            {
                await unitOfWork.TenentRepository.Delete(tenent);
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
