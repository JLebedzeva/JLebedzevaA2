using Microsoft.EntityFrameworkCore;
namespace MyWebApi.Models{
    public class Greeting
    {
        public int Id {get;set;}
        public string? TimeOfDay{get;set;}
        public string? Language{get;set;}
        public string? GreetingMessage{get;set;}
        public string? Tone {get; set;} = "Formal";

    }
}
