using System;

namespace Proyecto_2
{
	
	public class Servicio_Contratado
	{
		private Servicio ServContratado;
		private int CantidadSolicitada;

		public Servicio_Contratado(Servicio serv, int CantS)
		{
			this.ServContratado = serv;
			this.CantidadSolicitada = CantS;
		}

		public Servicio SERVCONTRATADOO
		{
			get{return ServContratado;}
			set{ServContratado= value;}
		}
		
		public int SERVICIO_CONTRATADO
		{
			get{return CantidadSolicitada;}
			set{CantidadSolicitada= value;}
		}
		
		
		public float CalcularSubtotal()
		{
			return  ServContratado.COSTO_UNITARIO* CantidadSolicitada;
		}
		
		public void ImprimirServicioContratado()
		{
			ServContratado.ImprimirServicio();
			Console.WriteLine("Cantidad Solicitada: "+ CantidadSolicitada);
			Console.WriteLine("-------------------------------------");
		}
	}
}
