using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Validador
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(),out valor ))
                {
                    if (valor < 1 || valor > 5) 
                    {
                        Console.WriteLine("ERROR: El valor debe ser entre 1 y 5");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error: El valor debe ser numérico entero");
                
                
            }
        }
        public static double LeerDecimales(string mensaje) 
        { 
            double valor;
            while (true)
            {
                Console.WriteLine(mensaje);
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 0 || valor > 20)
                    {
                        Console.WriteLine("Error:El valor debe ser entre 0 y 20"); continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error: el valor debe ser numérico decimal");
            }

        }
        public static string LeerString(string mensaje)
        {
            Console.WriteLine(mensaje);
            while (true)
            {
                
                string texto = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(texto))
                    return texto;
                Console.WriteLine("ERROR: Este campo no puede estar vacío");             
            }
        }
    }
}
