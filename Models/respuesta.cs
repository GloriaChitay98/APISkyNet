using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APISkyNet.Models
{
    public class respuesta
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string fecha { get; set; }
        public object datos { get; set; }
    }
}