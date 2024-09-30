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
            return Ok(manager.GetAllArticle());
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(manager.DeleteArticle(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody] Article art)
        {
            return Ok(manager.CreateArticle(art));
        }
        [HttpPut]
        public IActionResult Update(Article art)
        {
            return Ok(manager.UpdateArticle(art));
        }
    }
}
