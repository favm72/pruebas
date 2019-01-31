﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;
using System.Web.Script.Serialization;

namespace pruebau
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = @"A\g/BC+*12.5as-/das";
            string nueva = Regex.Replace(input, "[^0-9.]+", "");
            Assert.AreEqual((double)12.5, Convert.ToDouble(nueva));
        }

        [TestMethod]
        public void TestMethod2()
        {
            MyClass obj = new MyClass();
            Assert.AreEqual(0, obj.Nombre.Length);
        }
        [TestMethod]
        public void TestMethod3()
        {
            int compara = string.Compare("2016", "2015");
            Assert.AreEqual(1, compara);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string conceros = ("00000000" + "625");
            string formato = conceros.Substring(conceros.Length - 8, 8);
            Assert.AreEqual("00000625", formato);
        }
        //Model.descripcion == null ? 0 : 
        [TestMethod]
        public void TestMethod5()
        {
            string text = null;
            int num = text?.Length ?? 0;
            Assert.AreEqual(0, num);
        }
        [TestMethod]
        public void TestMethod6()
        {
            var lista = new List<MyClass>();
            var obj = lista.FirstOrDefault();            
            Assert.AreEqual(null, obj);
        }

        [TestMethod]
        public void TestMethod8()
        {
            string cadena = "102030";
            var array = cadena.Split('|');
            
            string dato = array[3].ToString();
            
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var lista = new List<CabeceraDetalle>();
            lista.Add(new CabeceraDetalle() { Codigo = "A", CodigoDet = "A1", Descripcion = "categA", Nombre = "item1" });
            lista.Add(new CabeceraDetalle() { Codigo = "A", CodigoDet = "A2", Descripcion = "categA", Nombre = "item2" });
            lista.Add(new CabeceraDetalle() { Codigo = "B", CodigoDet = "B1", Descripcion = "categB", Nombre = "item1" });
            lista.Add(new CabeceraDetalle() { Codigo = "B", CodigoDet = "B2", Descripcion = "categB", Nombre = "item2" });
            lista.Add(new CabeceraDetalle() { Codigo = "B", CodigoDet = "B3", Descripcion = "categB", Nombre = "item3" });
            lista.Add(new CabeceraDetalle() { Codigo = "C", CodigoDet = "C1", Descripcion = "categC", Nombre = "item1" });
            lista.Add(new CabeceraDetalle() { Codigo = "C", CodigoDet = "C2", Descripcion = "categC", Nombre = "item2" });
            lista.Add(new CabeceraDetalle() { Codigo = "D", CodigoDet = "D1", Descripcion = "categD", Nombre = "item1" });

            var q = lista.GroupBy(x => new { x.Codigo, x.Descripcion })
                        .Select(x => new Cabecera()
                        {
                            Codigo = x.Key.Codigo,
                            Descripcion = x.Key.Descripcion,
                            Detalles = x.Select(y => new Detalle()
                            {
                                Nombre = y.Nombre,
                                CodigoDet = y.CodigoDet
                            }).ToList()
                        }).ToList();

            var r = (from c in lista
                     group c by new { c.Codigo, c.Descripcion } into g
                     select g).ToList();

            var s = (from c in lista
                     group c by new { c.Codigo, c.Descripcion } into g
                     select new Cabecera()
                     {
                         Codigo = g.Key.Codigo,
                         Descripcion = g.Key.Descripcion,
                         Detalles = (from d in g                                    
                                     select new Detalle()
                                     {
                                         Nombre = d.Nombre,
                                         CodigoDet = d.CodigoDet
                                     }).ToList()
                     }).ToList();

            Assert.AreEqual(null, null);
        }
        [TestMethod]
        public void TestMethod9()
        {
            var lista = new List<CabeceraDetalle>();
            var obj = lista.FirstOrDefault();
            Assert.AreEqual(obj, null);
        }
        [TestMethod]
        public void TestMethod10()
        {            
            string path = System.IO.Directory.GetCurrentDirectory();
            path = System.IO.Directory.GetParent(path).FullName;
            path = System.IO.Directory.GetParent(path).FullName;
            string json = System.IO.File.ReadAllText(path + "\\data.txt");
            var js = new JavaScriptSerializer();
            Result obj = js.Deserialize<Result>(json);
            
            Assert.AreEqual(null, null);
        }
       

    }
}
