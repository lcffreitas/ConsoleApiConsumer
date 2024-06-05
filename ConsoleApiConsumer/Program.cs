using ConsoleApiConsumer.Content;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

internal class Program
{
    private static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
        var response = await client.GetAsync("users");
        var content = await response.Content.ReadAsStringAsync();

        var users = JsonConvert.DeserializeObject<User[]>(content);

        foreach (var item in users)
        {
            Console.WriteLine("Name: " + item.Name);

            Console.WriteLine("Email: " + item.Email);

            Console.WriteLine("Phone: " + item.Phone);

            Console.WriteLine($"Company: \n Name = {item.Company.Name} \n Catch Phrase = {item.Company.CatchPhrase}");

            Console.WriteLine($"Address: \n City = {item.Address.City} \n Street = {item.Address.Street} \n Suite = {item.Address.Suite} \n Zipcode = {item.Address.Zipcode}");

            Console.WriteLine($"Geo: \n Lat = {item.Address.Geo.Lat} \n Lng = {item.Address.Geo.Lng}");

            Console.WriteLine("");
        }
    }
}