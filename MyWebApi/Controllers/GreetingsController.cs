using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GreetingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Greetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Greeting>>> GetGreetings()
        {
            return await _context.Greetings.ToListAsync();
        }

        // GET: api/Greetings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Greeting>> GetGreeting(int id)
        {
            var greeting = await _context.Greetings.FindAsync(id);

            if (greeting == null)
            {
                return NotFound();
            }

            return greeting;
        }


        // PUT: api/Greetings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreeting(int id, Greeting greeting)
        {
            if (id != greeting.Id)
            {
                return BadRequest();
            }

            _context.Entry(greeting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreetingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Greetings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Greeting>> PostGreeting(Greeting greeting)
        {
            _context.Greetings.Add(greeting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreeting", new { id = greeting.Id }, greeting);
        }

        // DELETE: api/Greetings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGreeting(int id)
        {
            var greeting = await _context.Greetings.FindAsync(id);
            if (greeting == null)
            {
                return NotFound();
            }

            _context.Greetings.Remove(greeting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GreetingExists(int id)
        {
            return _context.Greetings.Any(e => e.Id == id);
        }


        [HttpPost("Greet")]
        public async Task<ActionResult<GreetingResponse>> Greet(GreetingRequest greetRequest)
        {
            var greetings = await _context.Greetings.ToListAsync();
            Greeting greetingMessage = null;

            foreach (var greeting in greetings){
                if (greeting.TimeOfDay == greetRequest.TimeOfDay && greeting.Language == greetRequest.Language && greeting.Tone == greetRequest.Tone)
                {
                    greetingMessage = greeting;
                    break;
                }
            }

            GreetingResponse greetingResponse;
            if (greetingMessage == null){
                greetingResponse = new GreetingResponse {
                    GreetingMessage = "Sorry but there is no greeting for this time of day or language combination."
                };
            }
            else {
                greetingResponse = new GreetingResponse { GreetingMessage = greetingMessage.GreetingMessage};
            }

            return greetingResponse;
        }


        [HttpGet("TimesOfDay")]
        public async Task<ActionResult<List<string>>> GetAllTimesOfDay()
        {
            List<string> timesOfDay = new List<string>();
            var greetings = await _context.Greetings.ToListAsync();

            foreach (var greeting in greetings){
                if (!timesOfDay.Contains(greeting.TimeOfDay)){
                    timesOfDay.Add(greeting.TimeOfDay);
                }
            }

            return timesOfDay;
        }

        [HttpGet("Languages")]
        public async Task<ActionResult<List<string>>> GetSupportedLanguages()
        {
            List<string> languages = new List<string>();
            var greetings = await _context.Greetings.ToListAsync();
            foreach (var greeting in greetings)
            {
                if(!languages.Contains(greeting.Language))
                {
                    languages.Add(greeting.Language);
                }
            }

            return languages;

        }
    }
}
