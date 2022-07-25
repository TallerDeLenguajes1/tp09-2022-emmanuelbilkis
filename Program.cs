using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tp9
{
    class Program
    {
        static void Main()
        {
          string ruta = @"C:\Users\user\Desktop";
          List <string> listaDirectorios = Directory.GetDirectories(ruta).ToList();
          
          Console.WriteLine("Lista de directorios de mi directorio elegido");
          foreach (string directorioX in listaDirectorios)
          {
            Console.WriteLine(directorioX);
          }
            
            var options = new JsonSerializerOptions
            {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    AllowTrailingCommas = true
            };

            FileStream miArchivo = new FileStream("directotios.json", FileMode.OpenOrCreate);
            string jsonString = JsonSerializer.Serialize(listaDirectorios, options);

            using (StreamWriter strwriter = new StreamWriter(miArchivo))
            {
                    strwriter.WriteLine(jsonString);
                    strwriter.Close();   
            }         

        }
    }


}