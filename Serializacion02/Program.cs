//https://learn.microsoft.com/es-es/dotnet/standard/serialization/system-text-json/overview
//https://jsonplaceholder.typicode.com
using System.Net.Http.Json;

namespace HttpClientExtensionMethods
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
    }

    public class Program
    {
        public static async Task Main()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };
            // Get the user information.
            User? user = await client.GetFromJsonAsync<User>("users/9");
            Console.WriteLine($"Id: {user?.Id}");
            Console.WriteLine($"Name: {user?.Name}");
            Console.WriteLine($"Username: {user?.Username}");
            Console.WriteLine($"Email: {user?.Email}");
            Console.WriteLine($"Phone: {user?.Phone}");
            Console.WriteLine($"Website: {user?.Website}");

            // Post a new user.
            HttpResponseMessage response = await client.PostAsJsonAsync("users", user);
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");


            Console.WriteLine("\nPresione una tecla para listar todos");
            Console.ReadLine();
            System.Console.WriteLine("Listar todos los usuarios");
         
            List<User>? users = await client.GetFromJsonAsync<List<User>>("users");
            foreach (User? u in users)
            {
                Console.WriteLine($"Id: {u.Id}");
                Console.WriteLine($"Name: {u.Name}");
                Console.WriteLine($"Username: {u.Username}");
                Console.WriteLine($"Email: {u.Email}");
                Console.WriteLine($"Phone: {u.Phone}");
                Console.WriteLine($"Website: {u.Website}");
            }

        }

        
        
    

  
    }
} 

 
// Produces output like the following example but with different names:
//
//Id: 1
//Name: Tyler King
//Username: Tyler
//Email: Tyler @contoso.com
//Success - Created