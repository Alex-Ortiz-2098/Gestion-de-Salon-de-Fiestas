using System;
using System.Collections;


namespace Proyecto_2
{
    class Menu
    {
        protected Salon_de_Fiesta Salon;
        
        public Menu(Salon_de_Fiesta s)
        {
            Salon= s;
        }
        public void MenuDeOpciones()
        {
            string respuesta = "";
            do
            {
				Console.WriteLine(" ----------------------------------");
				Console.WriteLine("Bienvenido al menu de Aura Real... ");
				Console.WriteLine("A. Agregar un servicio");
				Console.WriteLine("B. Eliminar un servicio");
				Console.WriteLine("C. Dar de alta un empleado/encargado");
				Console.WriteLine("D. Dar de baja un empleado/encargado");
				Console.WriteLine("E. Reservar el salón para un evento."); /* DOS CLAUSULAS */
				Console.WriteLine("F. Cancelar un evento.");
				Console.WriteLine("G. Submenú de impresión:"); /* listado de eventos, de clientes, de empleados, listado de eventos de un mes determinado*/
				Console.WriteLine("X. Desea salir del Menu");
				Console.WriteLine("Elija a que opcion Deseada:  ");
				respuesta = Console.ReadLine().ToUpper();
                switch(respuesta)
                {
                    case "A": //Agregar un servicio
                        {
                            Fabrica.FabricaDeServicioIngresada();
                            break;
                        }
                    case "B": //Eliminar un servicio
                        {
                            Console.WriteLine("Para eliminar un servicio ingrese el Nombre del Servicio: ");
                            string nombreServ= Console.ReadLine();
                            if(Salon.ExisteServicio(nombreServ))
                            {
                                Salon.EliminarServicio(nombreServ);
                                Console.WriteLine("-----Eliminado con Exito-----");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("-----El Servicio que desea eliminar no Existe o ya fue Borrado-----");
                                break;
                            }
                        }
                    case "C": // Dar de ALTA un empleado/encargado
                        {
                            Console.WriteLine("Desea ingresar un empleado o un encargado: ");
                            string res= Console.ReadLine().ToLower();
                            EleccionDePersonalAgregar(res);
                            break;
                            
                            
                        }
                    case "D": // Dar de BAJA un empleado/encargado
                        {

                            Console.WriteLine("Para eliminar un Empleado/Encargdo ingrese el DNI: ");
                            int Dni = int.Parse(Console.ReadLine());
                            if (Salon.ExisteEmpleado(Dni))
                            {
                                Salon.EliminarEmpleado(Dni);
                                Console.WriteLine("-----Eliminado con Exito-----");
                                break;
                            }
                            if(Salon.ExisteEncargado(Dni))
                            {
                                Salon.EliminarEncargado(Dni);
                                Console.WriteLine("-----Eliminado con Exito-----");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("-----El Empleado/Encargado que desea eliminar no Existe o ya fue Borrado-----");
                                break;
                            }
                        }
                    case "E": // Reservar el salón para un evento.
                        {
                            Evento evento= Fabrica.FabricaDeEventoIngresado();
                            
                            Salon.ExisteEvento(cliente1.DNI, )
                            break;
                        }
                    case "F": // Cancelar un evento
                        {
                            break;
                        }
                    case "G": //Submenú de impresión:
                        {
                            break;
                        }

                    case "X":
						Console.WriteLine("Saliendo...");
						break;
					default:
						Console.WriteLine("Opción no válida.");
						break;
                }
            }while(respuesta != "X");
				
        }

        public void EleccionDePersonalAgregar(string OpcionPersonal)
		{
			Console.WriteLine("Ingrese el DNI para verificar si existe en la Lista: ");
			int dni = int.Parse(Console.ReadLine());
			if (Salon.ExisteEmpleado(dni) || Salon.ExisteEncargado(dni))
			{
				Console.WriteLine("El DNI que desea ingresar ya esta en el sistema.....");
			}
			else
			{
				if (OpcionPersonal == "empleado")
				{
					Salon.AgregarEmpleado(Fabrica.FabricaDeEmpleadoIngresada());
					Console.WriteLine("-----Agregado con Exito-----");
				}
				if (OpcionPersonal == "encargado")
				{
					Salon.AgregarEncargado(Fabrica.FabricaDeEncargdoIngresada());
					Console.WriteLine("-----Agregado con Exito-----");
				}
			}
		}


        public void UI_CrearEvento()
        {
            // 1. Instanciamos el Builder
            EventoBuilder builder = new EventoBuilder(Salon);

            try
            {
                // PASO 1: CLIENTE Y FECHA
                Cliente cliente = Fabrica.FabricaDeClienteIngresado(); // Tu fábrica de cliente simple está bien
                DateTime fecha = PedirFechaEvento(); // Método auxiliar para limpiar

                builder.IniciarNuevoEvento(cliente, fecha);

                // PASO 2: ENCARGADO (La lógica compleja que tenías)
                Encargado encargadoFinal = null;

                // Usamos métodos del salón para preguntar disponibilidad (Lógica pura)
                if (!Salon.verDisponibilidadEncargado())
                {
                    Console.WriteLine("No hay encargados. Debe ascender a alguien.");
                    Encargado EncargdoDesignado=UI_AscenderEmpleado();
                    builder.AsignarEncargado(EncargdoDesignado);
                }
                else
                {
                    // Lógica para seleccionar uno disponible...
                    encargadoFinal = Salon.ObtenerEncargadoDisponible();
                }
                builder.AsignarEncargado(encargadoFinal);

                // PASO 3: SERVICIOS (El Bucle)
                string respuesta = "";
                do
                {
                    Console.WriteLine("--- AGREGAR SERVICIOS ---");
                    Salon.ImprimirListaServicios();

                    // Recolección de datos
                    Console.Write("Nombre del servicio: ");
                    string nombreServ = Console.ReadLine();
                    Console.Write("Cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());

                    // Validaciones de UI antes de llamar al Builder
                    Servicio serv = Salon.BuscarServicio(nombreServ);
                    if (serv != null && Salon.AlcanzanEmpleados(serv, cantidad)) //ARREGLAR ACAAAAAA
                    {
                        builder.AgregarServicio(serv, cantidad); // <--- El Builder guarda
                        Aura_Real.OcuparEmpleados(serv, cantidad); // <--- El Salón marca ocupados
                        Console.WriteLine("Servicio agregado.");
                    }
                    else
                    {
                        Console.WriteLine("No se puede agregar ese servicio (Stock/Inexistente).");
                    }

                    Console.Write("¿Agregar otro? (S/N): ");
                    respuesta = Console.ReadLine().ToUpper();

                } while (respuesta == "S");

                // PASO 4: SEÑA
                Console.WriteLine($"Total a pagar: {builder.ObtenerEvento().CostoTotal}");
                Console.Write("Ingrese Seña: ");
                float sena = float.Parse(Console.ReadLine());

                builder.ConfirmarSena(sena);

                // FINAL: GUARDAR
                Evento eventoListo = builder.ObtenerEvento();
                Aura_Real.AgregaEvento(eventoListo);

                Console.WriteLine("¡Evento Creado con Éxito!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear evento: " + ex.Message);
            }
        }

        public Encargado UI_AscenderEmpleado()
        {
            Console.WriteLine("Se debe Acender a un empleado de la siguiente lista");
            foreach (Empleado x in Salon.LISTA_EMPLEADOS)
            {
                if (x.ESTAOCUPADO == false)
                {
                    x.ImprimirEmpleado();
                }
            }
            Console.WriteLine("Ingrese un DNI de la lista");
            int DNI_Empleado = int.Parse(Console.ReadLine());
            Empleado emp = Salon.BuscarEmpleado(DNI_Empleado);
            float aumento= DarlePlusEmpelado();
            return Salon.AscenderAEncargado(emp,aumento);
        }

        public float DarlePlusEmpelado()
        {

            while (true)
            {
                Console.WriteLine("Ingrese el Plus del Encargado (El numero ingresado debe estar entre 1 y 100): ");
                float aumentoPlus = float.Parse(Console.ReadLine());
                if (aumentoPlus >= 1 && aumentoPlus <= 100)
                {
                    return aumentoPlus;
                }
                else
                {
                    Console.WriteLine("El número debe estar entre 1 y 100. Intente nuevamente.");
                }
            }
        }
        public static DateTime PedirFechaEvento()
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
































    }
}
