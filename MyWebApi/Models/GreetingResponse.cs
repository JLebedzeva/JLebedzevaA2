namespace MyWebApi.Models{
    public class GreetingResponse
    {
        public string? GreetingMessage {get; set;}
        public string? Tone {get; set;} = "Formal";
    }
}