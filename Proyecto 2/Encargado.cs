
using System;

namespace Proyecto_2
{
	/*El encargado de un evento es un empleado que organiza y controla el desarrollo del evento y
	cobra un plus sobre el sueldo. */
	
	public class Encargado: Empleado
	{
		private float Plus; // Cada Encargado recibe el un porcentaje de su sueldo, Dado por el USUARIO
		
		public Encargado(string nom, string ape, int dni, int NumLe, float suel, string Tare, float plu) :base(nom,ape,dni,NumLe,suel,Tare)
		{
			this.Plus=plu;

		}
		
		public float PLUS
		{
			get{return Plus;}
			set{Plus = value;}
		}
		
		public override void ImprimirEmpleado()
		{
			base.ImprimirEmpleado();
			Console.WriteLine("Plus de Encargado: "+Plus);
			Console.WriteLine("-------------------------------------");
		}
	}
}

