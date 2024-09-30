using Back.Implementacion;
using Back.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad_Práctica_02__405634_Alexis_Cantonati_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        IAplication manager;
        public FacturaController()
        {
            manager = new Aplication();
        }

        [HttpGet]
        public IActionResult Get(DateTime? fecha,int? formaPago)
        {
            return Ok(manager.GetFactura(fecha,formaPago));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(manager.DeleteFactura(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody ]Factura oFactura)
        {
            return Ok(manager.CreateFactura(oFactura));
        }
        [HttpPut]
        public IActionResult Update(Factura oFactura)
        {
            return Ok(manager.UpdateFactura(oFactura));
        }
    }
}
