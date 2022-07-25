using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace punto2
{
    class Program
    {

        static void Main()
        {
              List<Producto> misProductos = new List<Producto>();
              var producto = new Producto();

              //misProductos = producto.cargarLista(misProductos);
              //producto.generaJsonProductos("productosJSON",".json",misProductos);

               
              List<Producto> milista = leerJson(@"C:\Users\user\Desktop\tallerteoriastp\Taller\tp9\tp09-2022-emmanuelbilkis\punto2\productosJSON.json");

              foreach (var elemento in milista)
              {
                Console.WriteLine(elemento.Nombre);
              }

        }

        public static List<Producto> leerJson(string ruta)
       {
             
            List<Producto> miLista;
         
            string JsonString = File.ReadAllText(ruta);
            miLista = JsonSerializer.Deserialize<List<Producto>>(JsonString)!;
            return miLista;

       }
    }
    
}
