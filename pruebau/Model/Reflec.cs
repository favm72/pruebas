using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.Model
{
	public class Reflec : Mixed
	{
		public string Campo1 { get ; set; }
		public string Campo2 { get; set; }
		string Animal.Nombre { get => Campo1; set => Campo1 = value; }
		string Animal.Raza { get => Campo2; set => Campo2 = value; }
		string Vehiculo.Modelo { get => Campo1; set => Campo1 = value; }
		string Vehiculo.Precio { get => Campo2; set => Campo2 = value; }

		public void Accion()
		{

		}

		void Vehiculo.Arrancar()
		{
			Accion();
		}

		void Animal.Correr()
		{
			Accion();
		}
	}

	public interface Mixed : Animal, Vehiculo
	{

	}


	public interface Animal
	{
		string Nombre { get; set; }
		string Raza { get; set; }
		void Correr();
	}
	public interface Vehiculo
	{
		string Modelo { get; set; }
		string Precio { get; set; }
		void Arrancar();
	}
}
