using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Linq.Expressions;

namespace pruebau
{
    public class MyClass
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
    public class Alumno
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }

    public class Cabecera
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<Detalle> Detalles { get; set; }

    }
    public class Detalle
    {
        public string Codigo { get; set; }
        public string CodigoDet { get; set; }
        public string Nombre { get; set; }
    }

    public class CabeceraDetalle
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string CodigoDet { get; set; }
        public string Nombre { get; set; }
    }
    public class Glosa
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Result
    {
        public List<Glosa> glosas { get; set; }
    }
    public class padre
    {
        public virtual string accion() { return "padre"; }
    }
    public class hijo : padre
    {
        public override string accion()
        {
            return "hijo";
        }
    }
    public class nieto : hijo
    {
        public override string accion()
        {
            return "nieto";
        }
    }
}
