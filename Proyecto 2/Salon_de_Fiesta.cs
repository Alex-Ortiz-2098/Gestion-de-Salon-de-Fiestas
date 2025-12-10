
using System;
using System.Collections;

namespace Proyecto_2
{
	
	public class Salon_de_Fiesta
	{
		private string Nombre;
		private ArrayList Lista_Eventos;
		private ArrayList Lista_Empleados;
		private ArrayList Lista_Servicios;
		private ArrayList Lista_Clientes;
		private float Precio_Base; // Es el precio que vale el salon sin sus servicios.
		
		public Salon_de_Fiesta()
		{}
		
		public Salon_de_Fiesta(string nom, float preB)
		{
			this.Nombre= nom;
			this.Lista_Eventos= new ArrayList();
			this.Lista_Clientes= new ArrayList();
			this.Lista_Empleados= new ArrayList();
			this.Lista_Servicios= new ArrayList();
			this.Precio_Base= preB;
		}
		
		public string NOMBRE
		{
			get{return Nombre;}
			set{Nombre = value;}
		}
		
		public ArrayList LISTA_CLIENTES
		{
			get{return Lista_Clientes;}
			set{Lista_Clientes = value;}
		}
		
		public ArrayList LISTA_EVENTOS
		{
			get{return Lista_Eventos;}
			set{Lista_Eventos = value;}
		}
		
		public ArrayList LISTA_EMPLEADOS
		{
			get{return Lista_Empleados;}
			set{Lista_Empleados = value;}
		}
		
		public ArrayList LISTA_SERVICIOS
		{
			get{return Lista_Servicios;}
			set{Lista_Servicios = value;}
		}
		
		public float PRECIO_BASE
		{
			get{return Precio_Base;}
			set{Precio_Base = value;}
		}
		
		public bool ExisteServicio(string ser)
		{
			foreach (Servicio x in Lista_Servicios)
			{
				
				if(x.NOMBRE == ser)
				{
					return true;
				}
			}
			return false;
		}
		
		public bool ExisteEmpleado(int dni)
		{
			foreach (Empleado x in Lista_Empleados)
			{
				
				if(x.DNI == dni)
				{
					return true;
				}
			}
			return false;
		}
		
		public void EliminarServicio(string nom)
		{
			for(int i= Lista_Servicios.Count -1; i >= 0; i--)
			{
				Servicio s = (Servicio)Lista_Servicios[i];
				
				if (s.NOMBRE == nom)
				{
					Lista_Servicios.RemoveAt(i);
					return;
					
				}
			}
		}
		
		public void EliminarEmpleado(int d)
		{
			for(int i= Lista_Empleados.Count -1; i >= 0; i--)
			{
				Empleado e = (Empleado)Lista_Empleados[i];
				
				if (e.DNI == d)
				{
					Lista_Empleados.RemoveAt(i);
					return;
					
				}
			}
		}
		
		public void AgregarServico(Servicio x)
		{
			Lista_Servicios.Add(x);
		}
		
		public void AgregarEmpleado(Empleado x)
		{
			Lista_Empleados.Add(x);
		}
		
		public void AgregarClientes(Cliente x)
		{
			Lista_Clientes.Add(x);
		}
		
		
		public void ImprimirListaServicios()
		{
			foreach (Servicio x in Lista_Servicios)
			{
				x.ImprimirServico();
			}
		}
		
		public int CantEmpleadoXTarea(string nom)
		{
			int cont=0;
			foreach (Empleado x in Lista_Empleados)
			{
				if(x.TAREA == nom && x.ESTAOCUPADO != true)
				{
					cont= cont+1;
				}
				
			}
			
			return cont;
			
		}
		
		public void AgregarEmpleadosEvento(int cuenta, string nomm,Evento ser1)
		{
			
			for (int i = Lista_Empleados.Count - 1; i >= 0 && cuenta > 0; i--)
			{
				Empleado x = (Empleado)Lista_Empleados[i];

				if (x.TAREA == nomm && !x.ESTAOCUPADO)
				{
					x.ESTAOCUPADO = true;
					ser1.LISTA_EMPLEADOS_CONTRATADOS.Add(x);
					Lista_Empleados.RemoveAt(i);
					cuenta--;
				}
			}
		}
		
		public void DevolverEmpleados(Evento evento)
		{
			for (int i = evento.LISTA_EMPLEADOS_CONTRATADOS.Count - 1; i >= 0; i--)
			{
				Empleado empleado =(Empleado) evento.LISTA_EMPLEADOS_CONTRATADOS[i];

				empleado.ESTAOCUPADO = false;
				
				Lista_Empleados.Add(empleado);
				
				evento.LISTA_EMPLEADOS_CONTRATADOS.RemoveAt(i);
			}
		}


		
		public void AgregaEvento(Evento E1)
		{
			Lista_Eventos.Add(E1);
		}
		
		public bool ExisteEvento(int dni, DateTime fecha)
		{
			foreach (Evento ev in Lista_Eventos)
			{
				if (ev.CLIENTEVENTO.DNI == dni && ev.FECHAYHORA.Date == fecha.Date)
				{
					return true;
				}
			}
			return false;
		}
		
		public void EliminarEvento(Evento ev)
		{
			for(int i= Lista_Eventos.Count -1; i >= 0; i--)
			{
				Evento e = (Evento)Lista_Eventos[i];
				
				if (e.CLIENTEVENTO.DNI == ev.CLIENTEVENTO.DNI && e.FECHAYHORA.Date == ev.FECHAYHORA.Date && e.TIPO_EVENTO == ev.TIPO_EVENTO)
				{
					Lista_Eventos.RemoveAt(i);
					return;
					
				}
			}
		}
		
		public void ImprimirListaEvento()
		{
			foreach (Evento x in Lista_Eventos)
			{
				x.ImprimirEvento();
			}
		}
		
		public void ImprimirListaEmpleados()
		{
			foreach (Empleado x in Lista_Empleados)
			{
				x.ImprimirEmpleado();
			}
		}
		
		public void ImprimirListacClientes()
		{
			foreach(Cliente x in Lista_Clientes)
			{
				x.ImprimirCliente();
			}
		}
	}
}
