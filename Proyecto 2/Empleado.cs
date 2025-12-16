using System;

namespace Proyecto_2
{
	/*De cada empleado se registra su nombre y apellido, dni, nro de legajo, sueldo y tarea que
	desempeña */
	public class Empleado
	{
		protected string Nombre;
		protected string Apellido;
		protected int Dni;
		protected int Numero_Legajo;
		protected float Sueldo;
		protected string Tarea;
		protected bool EstaOcupado;
		
		public Empleado(string nom, string ape, int dni, int NumLe, float suel, string Tare)
		{
			this.Nombre=nom;
			this.Apellido=ape;
			this.Dni=dni;
			this.Numero_Legajo=NumLe;
			this.Sueldo=suel;
			this.Tarea=Tare;
			this.EstaOcupado= false;
		}
		
		public string NOMBRE
		{
			get{return Nombre;}
			set{Nombre = value;}
		}
		
		public string APELLIDO
		{
			get{return Apellido;}
			set{Apellido = value;}
		}
		
		public int DNI
		{
			get{return Dni;}
			set{Dni = value;}
		}
		
		public int NUMERO_LEGAJO
		{
			get{return Numero_Legajo;}
			set{Numero_Legajo = value;}
		}
		
		public float SUELDO
		{
			get{return Sueldo;}
			set{Sueldo = value;}
		}
		
		public string TAREA
		{
			get{return Tarea;}
			set{Tarea = value;}
		}
		
		public bool ESTAOCUPADO
		{
			get{return EstaOcupado;}
			set{EstaOcupado = value;}
		}
		
		public virtual void ImprimirEmpleado()
		{
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Nombre: "+Nombre);
			Console.WriteLine("Apellido: "+Apellido);
			Console.WriteLine("Dni: "+Dni);
			Console.WriteLine("Numero de Legajo: "+Numero_Legajo);
			Console.WriteLine("Sueldo: "+Sueldo);
			Console.WriteLine("Tarea: "+Tarea);
			Console.WriteLine("Esta ocupado: "+EstaOcupado);
			Console.WriteLine("-------------------------------------");
		}
		
	}
}

