/*
    Julia Lebedzeva
    8658087
    A2
    11/18/2024
*/
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using ConsoleApp.Models;
namespace ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "http://localhost:8080/";
        //var endpoint_getGreeting = "api/greetings";
        //var endpoint_getGreetingGreet = "api/greetings/greet";
        var endpoint_getGreet = "api/greet";
        var endpoint_getTimesOfDay = "api/getAllTimesOfDay";
        var endpoint_getLanguages = "api/getSupportedLanguages";

        using(HttpClient client = new HttpClient())
        {
        
            HttpResponseMessage getResponse = await client.GetAsync(url + endpoint_getTimesOfDay);
            string jsonStringResult = await getResponse.Content.ReadAsStringAsync();
            //System.Console.WriteLine(jsonStringResult)
            List<string> timesOfDay = JsonSerializer.Deserialize<List<string>>(jsonStringResult);

            System.Console.WriteLine("Welcome! Here are your following options for times of day: ");
            foreach(var time in timesOfDay){
                System.Console.WriteLine(time);
            }

            HttpResponseMessage getResponseLanguage = await client.GetAsync(url + endpoint_getLanguages);
            string jsonStringResultLanguages = await getResponseLanguage.Content.ReadAsStringAsync();
            //System.Console.WriteLine(jsonStringResult)
            List<string> languages = JsonSerializer.Deserialize<List<string>>(jsonStringResultLanguages);

            System.Console.WriteLine("Welcome! Here are your following options for languages: ");
            foreach(var language in languages){
                System.Console.WriteLine(language);
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

            var response = await client.PostAsJsonAsync(url + endpoint_getGreet, greetingRequest);

            if (response.IsSuccessStatusCode){
                var greetMessage = await response.Content.ReadFromJsonAsync<GreetingResponse>();
                Console.WriteLine(greetMessage.GreetingMessage);           
            }
            else {
                string errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}   {errorMessage}");
            }
        }
    }
}
