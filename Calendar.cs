using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CalculadoraHorasLaborables
{
    class Program
    {
        static Dictionary<DateTime, string> registros = new Dictionary<DateTime, string>();

        static void Main(string[] args)
        {
            CargarRegistrosDesdeArchivo("registros.txt");

            while (true)
            {
                Console.WriteLine("1. Registrar horas trabajadas");
                Console.WriteLine("2. Mostrar calendario de registros");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarHoras();
                            break;
                        case 2:
                            MostrarCalendarioDeRegistros();
                            break;
                        case 3:
                            GuardarRegistrosEnArchivo("registros.txt");
                            return;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
            }
        }

        static void RegistrarHoras()
        {
            Console.Write("Fecha (yyyy-MM-dd): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                Console.Write("Horas trabajadas: ");
                if (int.TryParse(Console.ReadLine(), out int horasTrabajadas))
                {
                    registros[fecha] = $"Horas trabajadas: {horasTrabajadas}";
                    Console.WriteLine("Registro guardado con éxito.");
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido para las horas trabajadas.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa una fecha válida en el formato yyyy-MM-dd.");
            }
        }

        static void MostrarCalendarioDeRegistros()
        {
            Console.WriteLine("Calendario de Registros:");
            foreach (var registro in registros)
            {
                Console.WriteLine($"{registro.Key:yyyy-MM-dd}: {registro.Value}");
            }
        }

        static void CargarRegistrosDesdeArchivo(string archivo)
        {
            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(':');
                    if (partes.Length == 2 && DateTime.TryParseExact(partes[0].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                    {
                        registros[fecha] = partes[1].Trim();
                    }
                }
            }
        }

        static void GuardarRegistrosEnArchivo(string archivo)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    foreach (var registro in registros)
                    {
                        sw.WriteLine($"{registro.Key:yyyy-MM-dd}: {registro.Value}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar los registros en el archivo: {e.Message}");
            }
        }
    }
}