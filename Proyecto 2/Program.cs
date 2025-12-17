
using System;
using System.Collections;

/*RESERVAR EVENTO .....El cliente puede incluir en su pedido un
solo servicio o varios. El salón toma una sola reserva para la misma fecha.
En caso de que ya tenga una reserva previa se levanta una excepción
indicando lo ocurrido. Al confirmar la reserva se le asigna un encargado al
evento.*/

/*CANCELAR EVENTO....En caso que el cliente solicite la cancelación con más de
un mes de anticipación a la fecha del servicio, no se le reintegra la seña.
En otro caso, el cliente debe abonar el servicio completo.
 */


namespace Proyecto_2
{
	class Program
	{
		public static void Main(string[] args)
		{
			Salon_de_Fiesta Aura_Real= new Salon_de_Fiesta("Aura_Real", 500000);
			
			
			
			
			/*string respuesta= "";
			
			do{
				Console.WriteLine(" ----------------------------------");
				Console.WriteLine("Bienvenido al menu de Aura Real... ");
				Console.WriteLine("A. Agregar un servicio");
				Console.WriteLine("B. Eliminar un servicio");
				Console.WriteLine("C. Dar de alta un empleado/encargado");
				Console.WriteLine("D. Dar de baja un empleado/encargado");
				Console.WriteLine("E. Reservar el salón para un evento."); // DOS CLAUSULAS 
				Console.WriteLine("F. Cancelar un evento.");
				Console.WriteLine("G. Submenú de impresión:"); // listado de eventos, de clientes, de empleados, listado de eventos de un mes determinado
				Console.WriteLine("X. Desea salir del Menu");
				Console.WriteLine("Elija a que opcion Deseada:  ");
				respuesta = Console.ReadLine().ToUpper();
				
				switch (respuesta) //MENU
				{
					
					case "E":
						// Reservar salón
						try
						{
							Console.WriteLine("Ingrese el Nombre del Cliente: ");
							string N= Console.ReadLine();
							Console.WriteLine("Ingrese el Dni del Cliente: ");
							int D= int.Parse(Console.ReadLine());
							Cliente ClienteEvento1= new Cliente(N,D);
							DateTime fecha= Evento.FechaEvento();
							
							foreach (Evento x in Aura_Real.LISTA_EVENTOS)
							{
								if(x.FECHAYHORA == fecha)
								{
									throw new FechaYaReservadaException("Ya existe un evento en esa fecha.");
								}
							}
							
							Console.WriteLine("Ingrese el Tipo de Evento: ");
							string tipE= Console.ReadLine();
							Encargado encar = null;
							if(Aura_Real.esVacio<Encargado>(Aura_Real.LISTA_ENCARGADO) && Aura_Real.verDisponibilidad(Aura_Real.LISTA_ENCARGADO) == false)
							{
								Console.WriteLine("No se encuentran Encargados Disponibles");
								Console.WriteLine("Se debe Acender a un empleado de la siguiente lista");
								foreach (Empleado x in Aura_Real.LISTA_EMPLEADOS)
								{
									if(x.ESTAOCUPADO == false)
									{
										x.ImprimirEmpleado();
									}
								}
								Console.WriteLine("Ingrese un DNI de la lista");
								int DNI_Empleado= int.Parse(Console.ReadLine());
								Empleado emp= Aura_Real.BuscarEmpleado(DNI_Empleado);
								float aumentoPlus =-1;
								while (true)
								{
									Console.WriteLine("Ingrese el Plus del Encargado (El numero ingresado debe estar entre 1 y 100): ");
									aumentoPlus= float.Parse(Console.ReadLine());
									if (aumentoPlus >= 1 && aumentoPlus <= 100)
									{
										break;
									}
									else
									{
										Console.WriteLine("El número debe estar entre 1 y 100. Intente nuevamente.");
										
									}
								}
								encar= Aura_Real.AscenderAEncargado(emp, aumentoPlus);
								}
								Evento E1= new Evento(ClienteEvento1,fecha,tipE,encar,0,0);
								float CostoServicios =0;
								string respux;
								int cuenta=0;
								do
								{
									Console.WriteLine("Tenemos estos Servicios para Ofrecerle: ");
									Aura_Real.ImprimirListaServicios();
									Console.WriteLine("Ingrese el Nombre del que le gustaria contratar: ");
									string nomm= Console.ReadLine();
									
									foreach (Servicio x in Aura_Real.LISTA_SERVICIOS)
									{
										if(x.NOMBRE == nomm)
										{
											Console.WriteLine("Ingrese la cantidad que desea solicitar: ");
											int cantS= int.Parse(Console.ReadLine());
											int cantEmpT=Aura_Real.CantEmpleadoXTarea(nomm); // CANTIDAD DE PERSONAL DE UNA TAREA
											cuenta= x.CANTIDAD_PERSONAL*cantS;
											if(cuenta <= cantEmpT)
											{
												Servicio_Contratado ser1= new Servicio_Contratado(x,cantS);
												CostoServicios =CostoServicios + ser1.CalcularSubtotal();
												E1.AgregarServicoContratado(ser1);
												Aura_Real.AgregarEmpleadosEvento(cuenta,nomm,E1);
												
												Console.WriteLine("-----Agregado con Exito-----");
												break;
											}
											else
											{
												Console.WriteLine("Lo sentimos no tenemos la cantidad de empleados para el servicio solicitado");
												break;
											}
										}
										
									}
									
									
									Console.WriteLine("Desea ingresar otro Servicio:  ");
									respux= Console.ReadLine().ToLower();
									
								}while (respux == "s");
								
								float Totak= Aura_Real.PRECIO_BASE+CostoServicios;
								float sena;
								do{
									
									Console.WriteLine("Debe Ingresar señar (Mayor a 0 y Menor al total del evento): "+ Totak);
									sena= float.Parse(Console.ReadLine());
								
								}while(sena <= 0 && sena > Totak);
								E1.COSTO_TOTAL= Totak;
								E1.SENA= sena;
								
								Aura_Real.AgregaEvento(E1);
								Aura_Real.AgregarClientes(ClienteEvento1);
								Console.WriteLine("-----Agregado con Exito-----");
								break;
							}
						}
			
						catch FechaYaReservadaException ex;
						{
							Console.WriteLine(ex.Message);
						}
						break;
					case "F":
						// Cancelar evento
						
						Console.Write("Ingrese el DNI del cliente: ");
						int dniCliente = int.Parse(Console.ReadLine());

						DateTime fechaBuscada;
						bool fechaValida = false;

						do
						{
							Console.Write("Ingrese la fecha del evento (formato dd/MM/yyyy): ");
							string fechaStr = Console.ReadLine();

							fechaValida = DateTime.TryParseExact(fechaStr,"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None, out fechaBuscada);

							if (!fechaValida)
							{
								Console.WriteLine("La fecha Ingresada es incorreta. Intente nuevamente Usando este formato (formato dd/MM/yyyy).");
							}

						} while (!fechaValida);
						

						if(Aura_Real.ExisteEvento(dniCliente,fechaBuscada))
						{
							foreach (Evento x in Aura_Real.LISTA_EVENTOS)
							{
								if(x.CLIENTEVENTO.DNI == dniCliente && x.FECHAYHORA.Date == fechaBuscada.Date)
								{
									TimeSpan diferencia = x.FECHAYHORA - DateTime.Now;

									if (diferencia.TotalDays >= 30)
									{
										Console.WriteLine("Usted esta Cancelando con más de un mes de anticipación. No se reintegra la seña.");
									}
									if (diferencia.TotalDays >= 0 && diferencia.TotalDays <30)
									{
										Console.WriteLine("Usted esta Cancelando con menos de un mes de anticipación.Se debe abonar el total del evento.");
										float totalPagar=  x.COSTO_TOTAL-x.SENA;
										Console.WriteLine("El total a pagar es: "+totalPagar);
										Console.WriteLine("¿Desea confirmar la cancelación y abonar el total? (s/n)");
										string Respu = Console.ReadLine().ToLower();
										if (Respu != "s")
										{
											Console.WriteLine("Cancelación abortada por el usuario.");
											break;
										}
									}
									else
									{
										Console.WriteLine("La fecha del evento ya pasó. No se puede cancelar.");
										break;
									}
									
									Aura_Real.DevolverEmpleados(x); // Los devuele a ESTAR DISPONIBLES
									Aura_Real.EliminarEvento(x);
									
									
									Console.WriteLine("-----Eliminado con Exito-----");
									break;
								}
							}
						}
						else
						{
							Console.WriteLine("El evento ingresado no exite o ya fue borrado...");
							break;
						}
						break;
					case "G":
						//Submenú de impresión:
						Console.WriteLine(" ----------------------------------");
						Console.WriteLine("Bienvenido al Submenu de Aura Real... ");
						Console.WriteLine("1. Lista de Eventos");
						Console.WriteLine("2. Lista de Clientes");
						Console.WriteLine("3. Lista de Empleados");
						Console.WriteLine("4. Listado de eventos dentro de un mes");
						Console.WriteLine("0. Desea salir del Menu");
						Console.WriteLine("Elija a que opcion Deseada:  ");
						int RESPUESTA = int.Parse(Console.ReadLine());
						switch (RESPUESTA)
						{
							case 1:
								// listado de eventos
								Aura_Real.ImprimirListaEvento();
								break;
							case 2:
								// listado de clientes
								Aura_Real.ImprimirListacClientes();
								break;
							case 3:
								// listado de empleados
								Aura_Real.ImprimirListaEmpleados();
								break;
							case 4:
								//listado de eventos de un mes determinado
								int mes;
								do{
									Console.Write("Ingrese el mes (1-12): ");
									mes= int.Parse(Console.ReadLine());
									if(mes < 0 && mes >12)
									{
										Console.WriteLine("Mes inválido. Debe estar entre 1 y 12....");
									}
									
								}while(mes > 0 && mes <12);
								
								foreach (Evento e in Aura_Real.LISTA_EVENTOS)
								{
									if (e.FECHAYHORA.Month == mes)
									{
										e.ImprimirEvento();
									}
								}
								break;
							case 0:
								Console.WriteLine("Saliendo...");
								break;
							default:
								Console.WriteLine("Opción no válida.");
								break;
						}
						break;
					case "X":
						Console.WriteLine("Saliendo...");
						break;
					default:
						Console.WriteLine("Opción no válida.");
						break;
				}
			}while (respuesta != "X");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		*/
		}
	}
}

