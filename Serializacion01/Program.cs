/*
Serialización y deserialización de objetos en C# con System.Text.Json
https://www.youtube.com/watch?v=hGPUc49TrC8
*/
using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Serialización y deserialización de objetos en C# con System.Text.Json");
        Person person = new Person { Name = "Ramon Gonzalez", Age = 30 };
        string filePath = "person.json";

       // Serialización en un archivo person.json
       Console.WriteLine("Serialización en un archivo person.json");
        SerializeObjectToFile(person, filePath);
 
        // Deserialización del archivo person.json
        Console.WriteLine("Deserialización del archivo person.json");
        Person objPerson = DeserializeObjectFromFile<Person>(filePath);
        Console.WriteLine(objPerson);

        string path = "personas.json";
        List<Person> lista = new List<Person>() { new Person() {Age=21, Name="Solenny"}, new Person() {Age=21, Name="Alquimedes"}, new Person() {Age=24, Name="Yeison"}, new Person() {Age=23, Name="Carlos"}};
        
        Console.WriteLine("Serialización de una lista de objetos en un archivo personas.json");
        SerializeObjectToFile(lista, path);

        Console.WriteLine("Deserialización de una lista de objetos en un archivo personas.json");
        List<Person> lista2 = DeserializeObjectFromFile<List<Person>>(path);
        
        foreach (var item in lista2)
        {
            Console.WriteLine(item);
        }
    }

    public static void SerializeObjectToFile(object obj, string filePath)
    {
        string jsonString = JsonSerializer.Serialize(obj);
        File.WriteAllText(filePath, jsonString);
    }

    //uso de generics
    //T es un tipo de dato que se define en tiempo de ejecución
    //referencia: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-methods
    public static T DeserializeObjectFromFile<T>(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
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