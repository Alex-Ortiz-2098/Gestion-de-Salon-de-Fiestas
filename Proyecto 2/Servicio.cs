using System;

namespace Proyecto_2
{
	/*De cada servicio ofrecido se almacena nombre del servicio (catering,
		bebida, mozos, DJ, inflables, cama elástica, etc), descripción (detalle de lo que
		incluye el servicio), cantidad solicitada, costo unitario del servicio.*/
	public class Servicio
	{
		private string Nombre; //(catering, bebida, mozos, DJ, inflables, cama elástica, etc)
		private string Descripcion; //(detalle de lo que incluye el servicio)
		private int CantPersonal;
		private float Costo_Unitario;
		
		public Servicio(string nom, string desc,int CantP, float CostU)
		{
			this.Nombre= nom;
			this.Descripcion=desc;
			this.CantPersonal=CantP;
			this.Costo_Unitario=CostU;
		}
		
		public string NOMBRE
		{
			get{return Nombre;}
			set{Nombre = value;}
		}
		
		public string DESCRIPCION
		{
			get{return Descripcion;}
			set{Descripcion = value;}
		}
		
		public int CANTIDAD_PERSONAL
		{
			get{return CantPersonal;}
			set{CantPersonal = value;}
		}
		
		
		public float COSTO_UNITARIO
		{
			get{return Costo_Unitario;}
			set{Costo_Unitario = value;}
		}
		
		
		public void ImprimirServicio()
		{
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("Nombre del Servicio: "+ Nombre);
			Console.WriteLine("Descripcion del Servico"+ Descripcion);
			Console.WriteLine("Costo Unitario del Servicio"+ Costo_Unitario);
			Console.WriteLine("-------------------------------------");
		}
	}
}
