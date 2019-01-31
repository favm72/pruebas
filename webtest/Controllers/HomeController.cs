using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Custom3DevProviders;
using webtest.Models;
using System.Xml;

namespace webtest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Index(string id)
        {
            //string ruta = "\\\\CHPROV177-034\\sanciones/test.txt";
            //System.IO.File.Create(ruta);
            return Login(new Login()
            {
                AUTOPOST = true,
                CUSUARIO = "HOLA",
                WCOD_LINEA_NEGOCIO = "U",
                WCOD_TIPO_PERSONA = "P"
            });
        }
        public ActionResult Consultar()
        {
            int a = 0;
            int c = 0;
            Parallel.Invoke(
                () => accion1(ref a),
                () => accion2(ref c));
            //System.Threading.Tasks.Task.Run(() => { accion1(ref a); });
            //System.Threading.Tasks.Task.Run(() => { accion2(ref c); });
            return Content($"{a} + {c}");
        }

        public void accion1(ref int a)
        {
            System.Threading.Thread.Sleep(1000);
            a = 1;
        }
        public void accion2(ref int c)
        {
            System.Threading.Thread.Sleep(3000);
            c = 3;
        }
        [HttpGet]
        public ActionResult Login(string CUSUARIO)
        { 
            var vm = new Login();
            vm.CUSUARIO = CUSUARIO ?? "ERA NULL";
            return View("Login", vm);
        }
        [HttpPost]
        public ActionResult Login(Login vm)
        {
            if (vm == null) vm = new Login();             
            return View("Login", vm);
        }
    }
}