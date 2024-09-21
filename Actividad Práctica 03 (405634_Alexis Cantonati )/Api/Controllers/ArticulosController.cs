using Microsoft.AspNetCore.Mvc;
using Back.Implementacion;
using Back.Models;

namespace Actividad_Práctica_02__405634_Alexis_Cantonati_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : Controller
    {
        IAplication manager;
        public ArticulosController()
        {
            manager = new Aplication();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(manager.GetAll());
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(manager.Delete(id));
        }
        [HttpPost]
        public IActionResult Create( Article art)
        {
            return Ok(manager.Create(art));
        }
        [HttpPut]
        public IActionResult Update(Article art)
        {
            return Ok(manager.Update(art));
        }
    }
}
