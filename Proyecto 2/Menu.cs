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
                            Salon.EleccionDePersonalAgregar(res);
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
    }
}
