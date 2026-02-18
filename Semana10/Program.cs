using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VacunacionCOVID19
{
    // Clase que representa a un ciudadano (Nancy, aquí usamos Programación Orientada a Objetos)
    public class Ciudadano
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EstadoVacunacion { get; set; } // No vacunado, Pfizer, AstraZeneca, Ambas

        public Ciudadano(int id)
        {
            Id = id;
            Nombre = $"Ciudadano {id}";
            EstadoVacunacion = "No vacunado";
        }

        public override string ToString()
        {
            return $"{Id},{Nombre},{EstadoVacunacion}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Ciudadano otro)
                return this.Id == otro.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    class Program
    {
        // Carpeta donde guardaremos nuestros archivos
        static readonly string carpetaDatos = Path.Combine(Directory.GetCurrentDirectory(), "datos");
        static readonly string carpetaResultados = Path.Combine(carpetaDatos, "resultados");

        static void Main(string[] args)
        {
            // Hola Nancy! Este mensaje es especial para ti
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("==========================================");
            Console.WriteLine("💉 SISTEMA DE VACUNACIÓN COVID-19");
            Console.WriteLine($"👩 Desarrollado especialmente para: NANCY CAMPOS");
            Console.WriteLine($"📅 Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");
            Console.WriteLine("==========================================");
            Console.ResetColor();
            Console.WriteLine();

            try
            {
                // PASO 1: Creamos las carpetas necesarias
                CrearCarpetas();

                // PASO 2: Generamos los datos ficticios
                Console.WriteLine("📊 Generando datos ficticios...");
                var ciudadanosTotales = GenerarCiudadanos(500);
                var vacunadosPfizer = GenerarVacunados(75, "Pfizer", ciudadanosTotales);
                var vacunadosAstraZeneca = GenerarVacunados(75, "AstraZeneca", ciudadanosTotales);

                // PASO 3: Verificamos que no haya ciudadanos repetidos en los conjuntos de vacunados
                ValidarConjuntos(vacunadosPfizer, vacunadosAstraZeneca);

                // PASO 4: Guardamos los datos en archivos
                GuardarDatos(ciudadanosTotales, vacunadosPfizer, vacunadosAstraZeneca);

                // PASO 5: Aplicamos TEORÍA DE CONJUNTOS (lo que pidió el Ministerio)
                Console.WriteLine("\n🔍 Aplicando teoría de conjuntos...");
                ProcesarVacunacion(ciudadanosTotales, vacunadosPfizer, vacunadosAstraZeneca);

                // PASO 6: Mostramos un resumen interactivo
                MostrarResumen(ciudadanosTotales);

                // PASO 7: Bonus - Permitir consultar un ciudadano específico
                ConsultarCiudadano(ciudadanosTotales);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✨ ¡Proceso completado exitosamente! Revisa la carpeta 'datos' para ver los resultados.");
            Console.ResetColor();
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void CrearCarpetas()
        {
            if (!Directory.Exists(carpetaDatos))
                Directory.CreateDirectory(carpetaDatos);

            if (!Directory.Exists(carpetaResultados))
                Directory.CreateDirectory(carpetaResultados);

            Console.WriteLine($"📁 Carpeta de datos: {carpetaDatos}");
        }

        static List<Ciudadano> GenerarCiudadanos(int cantidad)
        {
            var ciudadanos = new List<Ciudadano>();
            for (int i = 1; i <= cantidad; i++)
            {
                ciudadanos.Add(new Ciudadano(i));
            }
            return ciudadanos;
        }

        static HashSet<Ciudadano> GenerarVacunados(int cantidad, string vacuna, List<Ciudadano> todosLosCiudadanos)
        {
            var random = new Random();
            var vacunados = new HashSet<Ciudadano>();
            var indicesUsados = new HashSet<int>();

            while (vacunados.Count < cantidad)
            {
                int indice = random.Next(0, todosLosCiudadanos.Count);
                if (!indicesUsados.Contains(indice))
                {
                    indicesUsados.Add(indice);
                    var ciudadano = todosLosCiudadanos[indice];
                    ciudadano.EstadoVacunacion = vacuna;
                    vacunados.Add(ciudadano);
                }
            }

            return vacunados;
        }

        static void ValidarConjuntos(HashSet<Ciudadano> pfizer, HashSet<Ciudadano> astrazeneca)
        {
            // Nancy: Aquí aplicamos teoría de conjuntos para encontrar la intersección
            var ciudadanosEnAmbas = pfizer.Intersect(astrazeneca).ToList();

            if (ciudadanosEnAmbas.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"⚠️  Atención: {ciudadanosEnAmbas.Count} ciudadanos están en ambos grupos de vacunados.");
                Console.WriteLine("✅ Esto significa que recibirán DOS DOSIS (una de cada vacuna)");
                Console.ResetColor();

                // Actualizamos el estado de estos ciudadanos
                foreach (var ciudadano in ciudadanosEnAmbas)
                {
                    ciudadano.EstadoVacunacion = "Ambas vacunas";
                }
            }
        }

        static void GuardarDatos(List<Ciudadano> todos, HashSet<Ciudadano> pfizer, HashSet<Ciudadano> astrazeneca)
        {
            // Guardamos todos los ciudadanos
            File.WriteAllLines(Path.Combine(carpetaDatos, "ciudadanos.txt"), 
                todos.Select(c => $"{c.Id},{c.Nombre}"));

            // Guardamos vacunados Pfizer
            File.WriteAllLines(Path.Combine(carpetaDatos, "vacunados_pfizer.txt"),
                pfizer.Select(c => c.ToString()));

            // Guardamos vacunados AstraZeneca
            File.WriteAllLines(Path.Combine(carpetaDatos, "vacunados_astrazeneca.txt"),
                astrazeneca.Select(c => c.ToString()));

            Console.WriteLine("✅ Datos guardados en archivos .txt");
        }

        static void ProcesarVacunacion(List<Ciudadano> todos, HashSet<Ciudadano> pfizer, HashSet<Ciudadano> astrazeneca)
        {
            // TEORÍA DE CONJUNTOS - Aquí viene la magia Nancy ✨

            // 1. Ciudadanos que NO se han vacunado (Conjunto Universal - (Pfizer ∪ AstraZeneca))
            var vacunadosTotales = new HashSet<Ciudadano>(pfizer);
            vacunadosTotales.UnionWith(astrazeneca);
            var noVacunados = todos.Where(c => !vacunadosTotales.Contains(c)).ToList();

            // 2. Ciudadanos con AMBAS DOSIS (Pfizer ∩ AstraZeneca)
            var ambasDosis = pfizer.Intersect(astrazeneca).ToList();

            // 3. Solo Pfizer (Pfizer - AstraZeneca)
            var soloPfizer = pfizer.Except(astrazeneca).ToList();

            // 4. Solo AstraZeneca (AstraZeneca - Pfizer)
            var soloAstraZeneca = astrazeneca.Except(pfizer).ToList();

            // Guardamos los resultados en archivos CSV
            var resultados = new Dictionary<string, List<Ciudadano>>
            {
                { "no_vacunados", noVacunados },
                { "dos_dosis", ambasDosis },
                { "solo_pfizer", soloPfizer },
                { "solo_astrazeneca", soloAstraZeneca }
            };

            foreach (var resultado in resultados)
            {
                string archivo = Path.Combine(carpetaResultados, $"{resultado.Key}.csv");
                var lineas = new List<string> { "ID,Nombre,Estado" };
                lineas.AddRange(resultado.Value.Select(c => c.ToString()));
                File.WriteAllLines(archivo, lineas, Encoding.UTF8);
            }

            // Mostramos resultados en consola
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n📋 LISTADOS SOLICITADOS POR EL MINISTERIO:");
            Console.ResetColor();
            Console.WriteLine($"   • No vacunados: {noVacunados.Count} ciudadanos");
            Console.WriteLine($"   • Ambas dosis: {ambasDosis.Count} ciudadanos");
            Console.WriteLine($"   • Solo Pfizer: {soloPfizer.Count} ciudadanos");
            Console.WriteLine($"   • Solo AstraZeneca: {soloAstraZeneca.Count} ciudadanos");
        }

        static void MostrarResumen(List<Ciudadano> todos)
        {
            var grupos = todos.GroupBy(c => c.EstadoVacunacion)
                              .Select(g => new { Estado = g.Key, Cantidad = g.Count() })
                              .OrderBy(g => g.Estado);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n📊 RESUMEN ESTADÍSTICO COMPLETO:");
            Console.ResetColor();

            Console.WriteLine("┌─────────────────────────┬─────────┬────────────┐");
            Console.WriteLine("│ Estado de Vacunación    │ Cantidad│ Porcentaje │");
            Console.WriteLine("├─────────────────────────┼─────────┼────────────┤");

            foreach (var grupo in grupos)
            {
                double porcentaje = (grupo.Cantidad * 100.0) / todos.Count;
                Console.WriteLine($"│ {grupo.Estado,-23} │ {grupo.Cantidad,7} │ {porcentaje,8:F2}%   │");
            }

            Console.WriteLine("└─────────────────────────┴─────────┴────────────┘");
        }

        static void ConsultarCiudadano(List<Ciudadano> todos)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n🔍 BONUS - CONSULTA INDIVIDUAL:");
            Console.ResetColor();
            Console.Write("¿Quieres consultar el estado de un ciudadano? (s/n): ");
            
            if (Console.ReadLine()?.ToLower() == "s")
            {
                Console.Write("Ingresa el número del ciudadano (1-500): ");
                if (int.TryParse(Console.ReadLine(), out int id) && id >= 1 && id <= 500)
                {
                    var ciudadano = todos.FirstOrDefault(c => c.Id == id);
                    if (ciudadano != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n✅ {ciudadano.Nombre} está en estado: {ciudadano.EstadoVacunacion}");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Número inválido. Debe ser del 1 al 500.");
                    Console.ResetColor();
                }
            }
        }
    }
}