using System;
using System.Collections;

namespace Proyecto_2
{
    class Fabrica
    {
        // los datos ingresados se crean una sola vez (por que son static) para minimizar el uso de memoria y la creacion de multiples generadores
        protected static GeneradorDeDatosAleatorios DatoAle = new GeneradorDeDatosAleatorios();
        public static Servicio FabricaDeServicioAleaotrio()
        {
            return new Servicio (DatoAle.stringAleatorio(10),DatoAle.stringAleatorio(10),DatoAle.numeroAleatorio(50),DatoAle.numeroAleatorio(999999999));
        }

        public static Servicio FabricaDeServicioIngresada()
        {
            Console.WriteLine("Ingrese el Nombre del Servicio: ");
			string Nombre= Console.ReadLine();
			Console.WriteLine("Ingrese la Descripcion del Servicio: ");
			string Descripcion= Console.ReadLine();
			Console.WriteLine("Ingrese La cantidad de personal necesario para Servicio: ");
			int cantP= int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el Costo Unitario del Servicio: ");
			float Costo= float.Parse(Console.ReadLine());
			return new Servicio(Nombre, Descripcion, cantP, Costo);
        }
        
        public static Empleado FabricaDeEmpleadoAleaotrio()
        {
            return new Empleado (DatoAle.stringAleatorio(10),DatoAle.stringAleatorio(10),DatoAle.numeroAleatorio(8),DatoAle.numeroAleatorio(10),DatoAle.numeroAleatorioFloat(999999999),DatoAle.stringAleatorio(10));
        }

        public static Empleado FabricaDeEmpleadoIngresada()
        {
            Console.WriteLine("Ingrese el Nombre del Empleado: ");
            string Nombre= Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido del Empleado: ");
			string Apellido= Console.ReadLine();
			Console.WriteLine("Ingrese el dni: ");
			int dni= int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el Numero de Legajo: ");
			int Legajo= int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el Sueldo del Empleado: ");
			float Sueldo= float.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Tarea del Empleado(Mozo,dj,cocinero,otro): ");
            String Tarea= Console.ReadLine();
            return new Empleado(Nombre,Apellido,dni,Legajo,Sueldo,Tarea);
        }

        public static Encargado FabricaDeEncargadoAlaotrio()
        {
            return new Encargado (DatoAle.stringAleatorio(10),DatoAle.stringAleatorio(10),DatoAle.numeroAleatorio(8),DatoAle.numeroAleatorio(10),DatoAle.numeroAleatorioFloat(999999999),DatoAle.stringAleatorio(10),DatoAle.numeroAleatorioFloat(100));
        }

        public static Encargado FabricaDeEncargdoIngresada()
        {
            Console.WriteLine("Ingrese el Nombre del Empleado: ");
            string Nombre= Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido del Empleado: ");
			string Apellido= Console.ReadLine();
			Console.WriteLine("Ingrese el dni: ");
			int dni= int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el Numero de Legajo: ");
			int Legajo= int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el Sueldo del Empleado: ");
			float Sueldo= float.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Tarea del Empleado(Mozo,dj,cocinero,otro): ");
            String Tarea= Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Ingrese el Plus del Encargado (El numero ingresado debe estar entre 1 y 100): ");
                float Plus = float.Parse(Console.ReadLine());
                if (Plus >= 1 && Plus <= 100)
                {
                    return new Encargado(Nombre, Apellido, dni, Legajo, Sueldo, Tarea, Plus);
                }
                else
                {
                    Console.WriteLine("El número debe estar entre 1 y 100. Intente nuevamente.");

                }
            }
        }

        public static Cliente FabricaDeClienteAlaotrio()
        {
            return new Cliente (DatoAle.stringAleatorio(10),DatoAle.numeroAleatorio(10));
        }
        public static Cliente FabricaDeClienteIngresado()
        {
            Console.WriteLine("Ingrese el Nombre del Cliente: ");
            string Nombre= Console.ReadLine();
			Console.WriteLine("Ingrese el dni: ");
			int dni= int.Parse(Console.ReadLine());
            return new Cliente(Nombre,dni);
        }
    
    }
}