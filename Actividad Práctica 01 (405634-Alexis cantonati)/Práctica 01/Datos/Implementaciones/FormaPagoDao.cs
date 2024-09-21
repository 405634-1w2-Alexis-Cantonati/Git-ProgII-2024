using Práctica_01.Datos.Contratos;
using Práctica_01.Datos.Sql;
using Práctica_01.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Práctica_01.Datos.Implementaciones
{
    internal class FormaPagoDao : IFormaPago
    {
        public List<FormaPago> TraerTodos()
        {
            List<FormaPago> lst = new List<FormaPago>();
            DataTable dt = HelperDB.GetInstance().Consultar("SP_TRAER_FORMAS");
            foreach (DataRow dr in dt.Rows)
            {
                FormaPago f = new FormaPago();
                f.IdForma = (int)dr["id_form"];
                f.Descripcion = dr["descripcion"].ToString();
                lst.Add(f);
            }
            return lst;
        }
    }
}
