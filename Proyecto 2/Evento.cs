
using System;
using System.Collections.Generic;

namespace Proyecto_2
{
	/*nombre y dni del cliente, fecha y hora del evento, tipo de evento (cumpleaños de 15,
casamientos, bautismos, etc.. ), encargado, lista de servicios contratados, costo total
(se calcula en base al precio de los servicios contratados y la cantidad) y monto de
la seña. */
	public class Evento
	{
		private Cliente ClienteEvento;
		private DateTime FechaHoraEvento;
		private string Tipo_Evento;
		private Encargado encargado; // Se tiene en cuenta recien cuando se Reserva un evento
		private List<Servicio_Contratado> Lista_Servicios_Contrado;
		private List<Empleado> Lista_Empleados_Contrado;
		private float Costo_Total; //(se calcula en base al precio de los servicios contratados y la cantidad)
		private float Sena;
		
		public Evento(Cliente cli, DateTime FHE, string tipoE,Encargado en,float CostoT, float Sen)
		{
			this.ClienteEvento=cli;
			this.FechaHoraEvento= FHE;
			this.Tipo_Evento =tipoE;
			this.encargado= en;
			this.Lista_Servicios_Contrado= new List<Servicio_Contratado>();
			this.Lista_Empleados_Contrado=new List<Empleado>();
			this.Costo_Total= CostoT;
			this.Sena= Sen;
		}
		
		public Cliente CLIENTEVENTO
		{
			get{return ClienteEvento;}
			set{ClienteEvento= value;}
		}
		
		
		public DateTime FECHAYHORA
		{
			get{return FechaHoraEvento;}
			set{FechaHoraEvento= value;}
		}
		
		public string TIPO_EVENTO
		{
			get{return Tipo_Evento;}
			set{Tipo_Evento= value;}
		}
		
		public Encargado ENCARGADO
		{
			get{return encargado;}
			set{encargado= value;}
		}
		
		public List<Servicio_Contratado> LISTA_SERVICIOS_CONTRATADOS
		{
			get{return Lista_Servicios_Contrado;}
			set{Lista_Servicios_Contrado= value;}
		}
		
		public List<Empleado> LISTA_EMPLEADOS_CONTRATADOS
		{
			get{return Lista_Empleados_Contrado;}
			set{Lista_Empleados_Contrado= value;}
		}
		
		public float COSTO_TOTAL
		{
			get{return Costo_Total;}
			set{Costo_Total= value;}
		}
		
		public float SENA
		{
			get{return Sena;}
			set{Sena= value;}
		}
		
		public void AgregarServicoContratado(Servicio_Contratado x)
		{
			Lista_Servicios_Contrado.Add(x);
		}
		
		public static DateTime FechaEvento()
		{
			while (true)
			{
				Console.Write("Ingrese la fecha y hora del evento (formato: dd/MM/yyyy HH:mm): ");
				string entrada = Console.ReadLine();

				try
				{
					DateTime fecha = DateTime.ParseExact(entrada, "dd/MM/yyyy HH:mm", null);

					if (fecha < DateTime.Now)
					{
						Console.WriteLine("La fecha Corresponde a una fecha antigua, ingrese nuevamente la fecha...");
						continue;
					}

					if (fecha.Month > 12)
					{
						Console.WriteLine("El mes ingresado no es válido, ingrese nuevamente la fecha...");
						continue;
					}

					return fecha;
				}
				catch (FormatException)
				{
					Console.WriteLine("Formato inválido. Use el formato exacto: dd/MM/yyyy HH:mm");
				}
			}
			
		}

		public void ImprimirEvento()
		{
			Console.WriteLine("-------------------------------------");
			ClienteEvento.ImprimirCliente();
			Console.WriteLine("Fecha del Evento"+ FechaHoraEvento);
			Console.WriteLine("Tipo de Evento"+ Tipo_Evento);
			Console.WriteLine("Seña del Evento"+ Sena);
			Console.WriteLine("Costo Total del Evento"+ Costo_Total);
			encargado.ImprimirEmpleado();
			Console.WriteLine("-------------------------------------");
			foreach(Servicio_Contratado x in Lista_Servicios_Contrado)
			{
				x.ImprimirServicioContratado();
			}
			foreach(Empleado x in Lista_Empleados_Contrado)
			{
				x.ImprimirEmpleado();
			}
		}
		
	}
}
