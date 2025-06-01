using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text.Json;

namespace JSON
{
    internal class Person
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("age")]
        public string Email { get; set; }
    
    }
    internal class Program
    {
        static void Main(string[]args)
        {
            string filePath = "C:/Users/chuyb/source/repos/JSON/bin/Debug";
            string jsonString = " ";

            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El archivo '{filePath}' no se encontró. ");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return;
            }
            try
            {
                Person person = JsonSerializer.Deserialize<Person>(jsonString);

                // 3. Imprimir los valores del objeto
                Console.WriteLine($"Nombre: {person.FirstName}");
                Console.WriteLine($"Apellido: {person.LastName}");
                Console.WriteLine($"Edad:  {person.Age}");
                Console.ReadKey();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error de deserialización: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
