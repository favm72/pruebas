using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webtest.Models
{
    public class Login
    {
        public string CUSUARIO { get; set; }
        public string WCOD_LINEA_NEGOCIO { get; set; }
        public string WCOD_TIPO_PERSONA { get; set; }
        public bool AUTOPOST { get; set; }
    }
}