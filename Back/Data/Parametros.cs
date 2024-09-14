using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data
{
    public class Parametros
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public Parametros(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
