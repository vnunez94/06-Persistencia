 //uso de StreamReader para leer un archivo de texto
 //uso de StreamWriter para escribir un archivo de texto

using System;
using System.IO;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.Clear();
            Console.WriteLine("Programa para escribir y leer archivos de texto");  
              int opcion;
                do
                {
                    Console.WriteLine("1. Escribir archivo");
                    Console.WriteLine("2. Leer archivo");
                    Console.WriteLine("3. Salir");
                    Console.WriteLine("Seleccione una opcion");
                    opcion=int.Parse(Console.ReadLine());
                    switch(opcion)
                    {
                        case 1:
                            Console.WriteLine("Cuantas personas desea generar?");
                            int n=int.Parse(Console.ReadLine());
                            escribirArchivo(n);
                            break;
                        case 2:
                            leerArchivo();
                            break;
                        case 3:
                            Console.WriteLine("Adios");
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                        break;
                    }
                }while(opcion!=3);

 
        }
        public static void escribirArchivo(int n)
        {
            string[] nombres={"Juan","Pedro","Maria","Ana","Luis","Carlos","Jose","Luisa","Laura","Sofia"};
            string [] apellidos ={"Perez","Gomez","Lopez","Diaz","Rodriguez","Gonzalez","Fernandez","Martinez","Sanchez","Ramirez"};
           
            Random r=new Random();
            Person[] personas=new Person[n];
            for(int i=0;i<personas.Length;i++)
            {
                personas[i]=new Person();
                personas[i].Name=nombres[r.Next(0,nombres.Length)]+" "+apellidos[r.Next(0,apellidos.Length)];
                personas[i].Age=r.Next(1,100);
            }
            //escribir las personas en un archivo de texto
            using(StreamWriter sw=new StreamWriter("personas.txt"))
            {
                foreach(Person p in personas)
                {
                    sw.WriteLine("{0},{1}",p.Name,p.Age);
                }
            }         
    
        }//fin del metodo escribirArchivo
        public static void leerArchivo()
        {
            //leer las personas del archivo de texto
            using(StreamReader sr=new StreamReader("personas.txt"))
            {
                string linea;
                int n=0;
                while((linea=sr.ReadLine())!=null)
                {
                    string[] datos=linea.Split(',');
                    Person p=new Person();
                    p.Name=datos[0];
                    p.Age=int.Parse(datos[1]);
                    Console.WriteLine($"No. {++n} {p}");
                }
            }
        }//fin del metodo leerArchivo
        
    }//fin de la clase Program

    public class Person
{   
    private string _name;
    private int _age;
    public string Name 
    { 
      get{ return _name; } 

      set{
            if(value.Length>1)
            {
                _name=value.Trim();            
            }
            else
            {
                throw new Exception("El nombre debe tener al menos 2 caracteres");
            }
      } 
    }
    public int Age
     { 
        get{ return _age;   } 
        set{
            if(value>0)
            {
                _age=value;            
            }
            else
            {
                throw new Exception("La edad debe ser mayor a 0");
            }   
     
     }     
    }
    public override string ToString()
    {
        return $"Nombre: {Name}, Edad: {Age}";
    }
}//fin de la clase Person

}//fin del namespace Archivos

