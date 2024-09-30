using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Models
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int FormaPag { get; set; }
        public string Cliente { get; set; }
        //private List<DetalleFactura> detalles;
        public Factura(int id, DateTime fecha, int forma, string cliente)
        {
            IdFactura = id;
            Fecha = fecha;
            FormaPag = forma;
            Cliente = cliente;
            //detalles = new List<DetalleFactura>();
        }
        public Factura()
        {
            IdFactura = 0;
            Fecha = DateTime.Now;
            FormaPag = 0;
            Cliente = "";
            //detalles = new List<DetalleFactura>();
        }

       /* public List<DetalleFactura> TraerDetalles()
        {
            return detalles;
        }
        public void AgregarDetalle(DetalleFactura detalle)
        {
            if (detalle != null)
            {
                detalles.Add(detalle);
            }
        }
        public void removerDetalle(int index)
        {
            detalles.RemoveAt(index);
        }*/
        public override string ToString()
        {
            return IdFactura + Fecha.ToString() + FormaPag + Cliente;
        }
    }
}
