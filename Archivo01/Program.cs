//uso de clase File para grabar y leer archivos
//https://learn.microsoft.com/es-es/dotnet/api/system.io.file?view=net-8.0
using System;
using System.IO;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "archivo.txt";
            string texto = "Hola mundo, OK, Bani";
            //creamos el archivo
            File.WriteAllText(path, texto);
            //leemos el archivo
            string textoLeido = File.ReadAllText(path);
            Console.WriteLine(textoLeido);
        }
    }
}