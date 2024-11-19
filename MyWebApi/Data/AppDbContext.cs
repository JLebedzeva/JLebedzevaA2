using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;

namespace MyWebApi.Data
{
    public class AppDbContext : DbContext{
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Greeting> Greetings {get;set;}

        public void SeedData()
        {
            if (!Greetings.Any()){
            Greetings.Add(new Greeting(){
                TimeOfDay = "Morning",
                Language = "English",
                GreetingMessage = "Good Morning!",
                Tone = "Formal"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Morning",
                Language = "English",
                GreetingMessage = "Morning!",
                Tone = "Casual"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Afternoon",
                Language = "English",
                GreetingMessage = "Good Afternoon!",
                Tone = "Formal"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Afternoon",
                Language = "English",
                GreetingMessage = "Afternoon!",
                Tone = "Casual"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Evening",
                Language = "English",
                GreetingMessage = "Good Evening!",
                Tone = "Formal"
            });
                Greetings.Add(new Greeting(){
                TimeOfDay = "Evening",
                Language = "English",
                GreetingMessage = "Evening!",
                Tone = "Casual"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Morning",
                Language = "French",
                GreetingMessage = "Bon Matin!",
                Tone = "Formal"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Morning",
                Language = "French",
                GreetingMessage = "Bonjour!",
                Tone = "Casual"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Afternoon",
                Language = "French",
                GreetingMessage = "Bon Après-midi!",
                Tone = "Formal"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Afternoon",
                Language = "French",
                GreetingMessage = "Après-midi mon ami!",
                Tone = "Casual"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Evening",
                Language = "French",
                GreetingMessage = "Bonne Nuit!",
                Tone = "Formal"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Evening",
                Language = "French",
                GreetingMessage = "Bonne Nuit mon ami!",
                Tone = "Casual"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Morning",
                Language = "Spanish",
                GreetingMessage = "Buenas Dias!",
                Tone = "Formal"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Morning",
                Language = "Spanish",
                GreetingMessage = "Hola amigo!",
                Tone = "Casual"
            });            
            
            Greetings.Add(new Greeting(){
                TimeOfDay = "Afternoon",
                Language = "Spanish",
                GreetingMessage = "Buenas Tardes!",
                Tone = "Formal"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Afternoon",
                Language = "Spanish",
                GreetingMessage = "Buenas Tardes mon amigo!",
                Tone = "Casual"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Evening",
                Language = "Spanish",
                GreetingMessage = "Buenas Noches!",
                Tone = "Formal"
            });
            Greetings.Add(new Greeting(){
                TimeOfDay = "Evening",
                Language = "Spanish",
                GreetingMessage = "Buenas Noches mon amigo!",
                Tone = "Casual"
            });

            SaveChanges();
            }

        }
    }
}