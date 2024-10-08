using Back.Data.Models;
using Back.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : Controller
    {

        private IServicioRepository _repository;
        public ServiciosController(IServicioRepository repository)
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
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repository.GetAll());
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
        public IActionResult Put([FromBody]TServicio servicio)
        {
            try
            {
                return Ok(_repository.Update(servicio));
            }
            catch (Exception)
            {

                return BadRequest("Error Interno");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]TServicio servicio)
        {
            try
            {
                return Ok(_repository.Create(servicio));
            }
            catch (Exception)
            {

                return BadRequest("Error Interno");
            }
        }
    }
}
