using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APISkyNet.Models
{
    public class peticion
    {
        public string modulo { get; set; }
        public string idtransaccion { get; set; }
        public object datos { get; set; }
    }

    public class apisrequeste
    {
        public string idtransaccion { get; set; }
        public object datos { get; set; }
    }
}