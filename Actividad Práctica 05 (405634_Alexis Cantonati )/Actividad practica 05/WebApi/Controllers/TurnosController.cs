using Back.Data.Models;
using Back.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : Controller
    {
        private ITurnosRepository _repository;
        public TurnosController(ITurnosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest("Error Interno");
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_repository.Delete(id));
            }
            catch (Exception)
            {
                return BadRequest("Error Interno");
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] TTurno turno)
        {
            try
            {
                return Ok(_repository.Update(turno));
            }
            catch (Exception)
            {

                return BadRequest("Error Interno");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] TTurno turno)
        {
            try
            {
                return Ok(_repository.Create(turno));
            }
            catch (Exception)
            {

                return BadRequest("Error Interno");
            }
        }
    }
}
