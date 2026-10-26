using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Program
    {
        static int max_estudiantes = 40;
        static int max_cursos = 4;
        static string[] nombres_cursos = { "Matemáticas", "Programación", "Física", "Base de datos" };
        static string[] estudiante = new string[max_estudiantes];
        static double[,] MatrixNotas = new double[max_estudiantes, max_cursos];
        static int total_estudiantes = 0;
        static string rutaArchivo = "LaNota.txt";
        public static void titulo() 
        {
            string titulo = "REGISTRO DE NOTAS";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo);

        }
        public static void RegistrarEstudiantes()
        {
            string titulo = "REGISTRO DE ESTUDIANTES";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo); 
            if (total_estudiantes >= max_estudiantes)
            {
                Console.WriteLine("Se alcanzo la capacidad máxima");
                return;
            }
            string nombre = Validador.LeerString("Ingresar nombres y apellidos");
            estudiante[total_estudiantes] = nombre;
            Console.WriteLine("Ingresar las notas de 0 a 20: ");
            for (int i = 0; i < max_cursos; i++)
            {
                MatrixNotas[total_estudiantes, i] = Validador.LeerDecimales($"Ingresar nota del curso:{nombres_cursos[i]} ");
            }
            total_estudiantes++;
            Console.WriteLine("Estudiante Registrado exitosamente");
        }
        public static void GuardarArchivo()
        {
            Console.WriteLine("Guarda registro en archivos");
            if (total_estudiantes == 0)
            {
                Console.WriteLine("No hay registro de estudiantes"); return;
            }
            using (StreamWriter escritor = new StreamWriter(rutaArchivo))
            {
                for (int i = 0; i < total_estudiantes; i++)
                {
                    string linea = estudiante[i];
                    for (int j = 0; j < max_cursos; j++)
                    {
                        linea += "," + MatrixNotas[i, j];
                        //linea += $",{MatrixNotas[i, j]}";
                    }
                    escritor.WriteLine(linea);
                }

            }
            Console.WriteLine("Registros guardados");
        }
        public static void CargarArchivo() 
        {
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("No hay archivos guardados");
                return;
            }
            total_estudiantes = 0;
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null && total_estudiantes < max_estudiantes)
                {
                    string[] partes = linea.Split(',');
                    if (partes.Length == max_cursos + 1) 
                    {
                        estudiante[total_estudiantes] = partes[0];
                        for (int i = 1; i < max_cursos; i++) 
                        {
                            MatrixNotas[total_estudiantes, i] = Convert.ToDouble(partes[i + 1]); 
                        }
                        total_estudiantes++;
                    }
                }
            }
            Console.WriteLine("Se cargaron los registros en el sistema"); 
        }
        public static void MostrarArchivo()
        {
            string titulo = "MOSTRAR ARCHIVO";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo);
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("\t\t\tREPORTE GENERAL DE NOTAS POR CURSO");

            Console.WriteLine(new string('=', 100));
            if (total_estudiantes == 0)
            {
                Console.WriteLine("No existe registros");
                return;
            }
            Console.Write($"{"ESTUDIANTE",-25}|");
            for (int i = 0; i < max_cursos; i++) {
                Console.Write($"{nombres_cursos[i],-14}|");

            }
            Console.WriteLine($"{"PROMEDIO",-12}");
            Console.WriteLine(new string('-', 100));
            for (int i = 0; i < total_estudiantes; i++)
            {
                Console.Write($"{estudiante[i],-25}|");
                double suma = 0;
                for (int j = 0; j < max_cursos; j++)
                {
                    Console.Write($"{MatrixNotas[i, j], -14 }|");
                    suma += MatrixNotas[i, j];
                }
                double promedio = suma/max_cursos;
                string estado = promedio >= 12 ? "Aprobado" : "Desaprobrado";
                Console.WriteLine($"{promedio:F2}({estado})");

            }


        }



        static void Main(string[] args)
        {
            int opcion = 0;
            while (opcion!=5)
            {
                Console.Clear();
                titulo();
                Console.WriteLine("1. Registrar estudiante");
                Console.WriteLine("2. Guardar datos");
                Console.WriteLine("3. Cargar datos");
                Console.WriteLine("4. Mostrar archivo");
                Console.WriteLine("5. salir");
                opcion = Validador.LeerEntero("Ingrese una opcion: ");
                switch (opcion) 
                {
                    case 1:
                        RegistrarEstudiantes(); break;
                    case 2:
                        GuardarArchivo(); break;
                    case 3:
                        CargarArchivo(); break;
                    case 4:
                        MostrarArchivo(); break ;
                    case 5:
                        Console.WriteLine("Saliendo..."); break;
                    
                }
                Console.ReadKey();
            }
        }
    }
}
