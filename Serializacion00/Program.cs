using System;
using System.Text.Json;

namespace JsonSerializationExample
{
    class Program
    {
        static void Main()
        {
            // Crear un objeto para serializar
            Person person = new Person
            {
                FirstName = "Margot",
                LastName = "Santana",
                Age = 63
            }; 


            // Serializar el objeto a una cadena JSON
            string json = JsonSerializer.Serialize(person);

            Console.WriteLine(json);
         
            var person2=JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(person2.FirstName); 
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
