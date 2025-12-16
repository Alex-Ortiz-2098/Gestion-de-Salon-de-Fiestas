
using System;

namespace Proyecto_2
{

	public class Cliente
	{
		private string Nombre ;
		private int Dni ;

		public Cliente(string nombre, int dni)
		{
			this.Nombre = nombre;
			this.Dni = dni;
		}
		
		public string NOMBRE
		{
			get{return Nombre;}
			set{Nombre= value;}
		}
		
		public int DNI
		{
			get{return Dni;}
			set{Dni= value;}
		}
		
		public void ImprimirCliente()
		{
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Nombre del Cliente: "+ Nombre);
			Console.WriteLine("Dni del Cliente"+ Dni);
			Console.WriteLine("-------------------------------------");
		}
	}

}
