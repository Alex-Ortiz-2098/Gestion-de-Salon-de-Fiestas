using System;
using System.Collections.Generic;

namespace Proyecto_2
{
    public class GeneradorDeDatosAleatorios
    {
        private static Random random = new Random();
        public int numeroAleatorio(int max) //Devuelve un número aleatorio entre 0 y ‘max’
        {
            Random random = new Random();
            return random.Next(0, max);
        }

        public float numeroAleatorioFloat(int max) //Devuelve un número aleatorio entre 0 y ‘max’
        {
            Random random = new Random();
            return random.Next(0, max);
        }
        public string stringAleatorio(int cant) //Devuelve un string aleatorio de ‘cant’ caracteres
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            char[] result = new char[cant];
            for (int i = 0; i < cant; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            return new string(result);
        }
    }
}