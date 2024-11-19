using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using ConsoleApp.Models;
namespace ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "http://localhost:5011/";
        var endpoint_getGreeting = "api/greetings";
        
        var endpoint_getGreetingGreet = "api/greetings/greet";

        using(HttpClient client = new HttpClient())
        {
        
            HttpResponseMessage getResponse = await client.GetAsync(url + endpoint_getGreeting);
            string jsonStringResult = await getResponse.Content.ReadAsStringAsync();
            //System.Console.WriteLine(jsonStringResult);
            
            List<Greeting> greetings = JsonSerializer.Deserialize<List<Greeting>>(jsonStringResult);
            System.Console.WriteLine("Welcome! Here are your following options for times of day and language: ");
            foreach(var greeting in greetings){
                System.Console.WriteLine(greeting.timeOfDay + " " + greeting.language);
            }
            System.Console.WriteLine("**************************************************");
            System.Console.WriteLine("Please enter the time of day");
            var userTimeOfDay = Console.ReadLine();

            System.Console.WriteLine("Please enter the language");
            var userLanguage = Console.ReadLine();
            
            System.Console.WriteLine("Please enter the tone Casual / Formal (Default will be Formal)");
            var userTone = Console.ReadLine();

            var greetingRequest = new GreetingRequest {
                TimeOfDay = userTimeOfDay,
                Language = userLanguage,
                Tone = userTone
            };

            var response = await client.PostAsJsonAsync(url + endpoint_getGreetingGreet, greetingRequest);
            var greetMessage = await response.Content.ReadFromJsonAsync<GreetingResponse>();
            Console.WriteLine(greetMessage.GreetingMessage);            
        }
    }
}
