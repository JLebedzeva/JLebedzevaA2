namespace ConsoleApp.Models{
    public class Greeting
    {
        public int Id {get;set;}
        public string? timeOfDay{get;set;}
        public string? language{get;set;}
        public string? greetingMessage{get;set;}
        public string? Tone {get; set;} = "Formal";

    }
}
