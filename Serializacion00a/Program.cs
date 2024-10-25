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
            {  FirstName = "Margot",
                LastName = "Santana",
                Age = 63
            }; 
              
            var properties = typeof(Person).GetProperties();
            foreach (var property in properties)
            {
                //Console.WriteLine(property.Name);
                Console.WriteLine($"{property.Name}: {property.GetValue(person)}({property.PropertyType})");
 
            }


 


        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
