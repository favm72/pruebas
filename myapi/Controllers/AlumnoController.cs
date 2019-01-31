using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace myapi.Controllers
{
    public class AlumnoController : ApiController
    {
        // GET: api/Alumno
        public IEnumerable<Alumno> Get()
        {
            using (Entities c = new Entities())
            {
                return c.Alumno.ToList();
            }            
        }

        // GET: api/Alumno/5
        public Alumno Get(int id)
        {
            using (Entities c = new Entities())
            {
                return c.Alumno.Find(id);
            }
        }

        // POST: api/Alumno
        public void Post([FromBody]Alumno value)
        {
            using (Entities c = new Entities())
            {
                c.Alumno.Add(value);
                c.SaveChanges();
            }
        }

        // PUT: api/Alumno/5
        public void Put(int id, [FromBody]Alumno value)
        {
            using (Entities c = new Entities())
            {
                var upd = c.Alumno.Find(id);
                upd.Edad = value.Edad;
                upd.Nombre = value.Nombre;
                c.SaveChanges();
            }
        }

        // DELETE: api/Alumno/5
        public void Delete(int id)
        {
            using (Entities c = new Entities())
            {
                c.Alumno.Remove(c.Alumno.Find(id));
                c.SaveChanges();
            }
        }
    }
}
