using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Dominio
{
    public class FormaPago
    {
        public int IdForma { get; set; }
        public string Descripcion { get; set; }

        public FormaPago(int id, string nombre)
        {
            IdForma = id;
            Descripcion = nombre;
        }
        public FormaPago()
        {
            IdForma = 0;
            Descripcion = "";
        }
    }
}
