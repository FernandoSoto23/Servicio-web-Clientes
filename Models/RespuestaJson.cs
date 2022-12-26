using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class RespuestaJson<Type>
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
        public Type Dato { get; set; }

    }
}