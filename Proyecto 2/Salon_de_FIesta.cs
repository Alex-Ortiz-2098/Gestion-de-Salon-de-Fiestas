
using System;
using System.Collections.Generic;

namespace Proyecto_2
{
	
	public class Salon_de_Fiesta
	{
		private string Nombre;
		private List<Evento> Lista_Eventos;
		private List<Empleado> Lista_Empleados;
		private List<Encargado> Lista_Encargados;
		private List<Cliente> Lista_Clientes;
		private List<Servicio> Lista_Servicios;
		private float Precio_Base; // Es el precio que vale el salon sin sus servicios.
		
		public Salon_de_Fiesta()
		{}
		
		public Salon_de_Fiesta(string nom, float preB)
		{
			this.Nombre= nom;
			this.Lista_Eventos= new List<Evento> ();
			this.Lista_Clientes= new List<Cliente> ();
			this.Lista_Empleados= new List<Empleado> ();
			this.Lista_Encargados= new List<Encargado> ();
			this.Lista_Servicios= new List<Servicio> ();
			this.Precio_Base= preB;
		}
		
		public string NOMBRE
		{
			get{return Nombre;}
			set{Nombre = value;}
		}
		
		public List<Cliente> LISTA_CLIENTES
		{
			get{return Lista_Clientes;}
			set{Lista_Clientes = value;}
		}
		
		public List<Evento> LISTA_EVENTOS
		{
			get{return Lista_Eventos;}
			set{Lista_Eventos = value;}
		}
		
		public  List<Empleado> LISTA_EMPLEADOS
		{
			get{return Lista_Empleados;}
			set{Lista_Empleados = value;}
		}

		public  List<Encargado> LISTA_ENCARGADO
		{
			get{return Lista_Encargados;}
			set{Lista_Encargados = value;}
		}
		
		public  List<Servicio> LISTA_SERVICIOS
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
		public bool ExisteEncargado(int dni)
		{
			foreach (Encargado x in Lista_Encargados)
			{
				
				if(x.DNI == dni)
				{
					return true;
				}
			}
			return false;
		}

		public Empleado BuscarEmpleado(int dni)
		{
			foreach (Empleado x in Lista_Empleados)
			{
				if(x.DNI == dni)
				{
					return x;
				}
			}
			
			return null;
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

		public void EliminarEncargado(int d)
		{
			for(int i= Lista_Encargados.Count -1; i >= 0; i--)
			{
				Encargado e = Lista_Encargados[i];
				
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

		public void AgregarEncargado(Encargado x)
		{
			Lista_Encargados.Add(x);
		}
		
		public void AgregarClientes(Cliente x)
		{
			Lista_Clientes.Add(x);
		}
		
		
		public void ImprimirListaServicios()
		{
			foreach (Servicio x in Lista_Servicios)
			{
				x.ImprimirServicio();
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
		
		public void AgregarEmpleadosEvento(int cuenta, string nom,Evento ser1)
		{
			
			for (int i = Lista_Empleados.Count - 1; i >= 0 && cuenta > 0; i--)
			{
				Empleado x = (Empleado)Lista_Empleados[i];

				if (x.TAREA == nom && !x.ESTAOCUPADO)
				{
					x.ESTAOCUPADO = true;
					ser1.LISTA_EMPLEADOS_CONTRATADOS.Add(x);
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

		public Encargado AscenderAEncargado(Empleado e, float plus)
		{

			return new Encargado(e.NOMBRE,e.APELLIDO,e.DNI,e.NUMERO_LEGAJO,e.SUELDO,e.TAREA, plus);
		}
		
		public void ImprimirListaEvento()
		{
			foreach (Evento x in Lista_Eventos)
			{
				x.ImprimirEvento();
			}
		}
		
		public bool esVacio<T>(List<T> lista)
		{
			if(lista.Count == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool verDisponibilidad(List<Encargado> lista)
		{
			foreach(Encargado x in lista)
			{
				if(x.ESTAOCUPADO == true)
				{
					return true;
				}
			}
			return false;
		
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
	
		public float CalcularAumento(Encargado encargado)
        {
			float aumento= (100+encargado.PLUS);
            float calculo= (aumento*encargado.SUELDO)/100;
			return calculo;
        }

		public void EleccionDePersonalAgregar(string OpcionPersonal)
		{
			Console.WriteLine("Ingrese el DNI para verificar si existe en la Lista: ");
			int dni = int.Parse(Console.ReadLine());
			if (ExisteEmpleado(dni) || ExisteEncargado(dni))
			{
				Console.WriteLine("El DNI que desea ingresar ya esta en el sistema.....");
			}
			else
			{
				if (OpcionPersonal == "empleado")
				{
					AgregarEmpleado(Fabrica.FabricaDeEmpleadoIngresada());
					Console.WriteLine("-----Agregado con Exito-----");
				}
				if (OpcionPersonal == "encargado")
				{
					AgregarEncargado(Fabrica.FabricaDeEncargdoIngresada());
					Console.WriteLine("-----Agregado con Exito-----");
				}
			}
		}
	
	}
}
