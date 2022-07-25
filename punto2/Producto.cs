using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace punto2
{
    class Producto
    {
        string nombre;
        DateTime fechavencimiento;
        float precio; //entre 1000 y 5000;
        string tamanio;

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fechavencimiento { get => fechavencimiento; set => fechavencimiento = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Tamanio { get => tamanio; set => tamanio = value; }

        public List<Producto>  cargarLista(List<Producto> miLista )
        {
            string salida = ""; // bandera para salir del ciclo
            int num=20; // para tener un numero q vaya variando para ciertos datos
            do
            {
                System.Console.WriteLine("Ingrese nombre producto");
                string nombre = Console.ReadLine()!;
                Producto NProducto = new Producto(); // por cada tarea reservo memoria 
                NProducto.nombre = nombre; // cargo los campos de la tarea q acabo de reservar
                NProducto.precio = 1000;
                NProducto.fechavencimiento = DateTime.Now.AddDays(num);
                NProducto.tamanio = "Grande";

                miLista.Add(NProducto);
        
                Console.WriteLine("Desea ingresar un nuevo producto ? (s/n)");
                salida = Console.ReadLine()!; 
                
            } while (salida!="n");
            
            return miLista;
        }


        public void generaJsonProductos(string nombre, string formato,List<Producto> miLista )
        {
            
                     
            var options = new JsonSerializerOptions
            {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    AllowTrailingCommas = true
            };


            FileStream miArchivo = new FileStream(nombre + formato, FileMode.OpenOrCreate);
            string jsonString = JsonSerializer.Serialize(miLista, options);

            using (StreamWriter strwriter = new StreamWriter(miArchivo))
            {
                    strwriter.WriteLine(jsonString);
                    strwriter.Close();   
            } // hasta aqui crep el archivo json 
        }

       

        }


    }
