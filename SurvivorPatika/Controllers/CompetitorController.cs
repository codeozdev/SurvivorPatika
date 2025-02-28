using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurvivorPatika.DTO;
using SurvivorPatika.Models;

namespace SurvivorPatika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private static List<Competitors> _competitors =
        [
            new Competitors
            {
                Id = 1, CategoryId = 1, FirstName = "Acun", LastName = "Ilıcalı", IsDeleted = false,
                CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now
            },

            new Competitors
            {
                Id = 2, CategoryId = 1, FirstName = "Aleyna", LastName = "Avcı", IsDeleted = false,
                CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now
            },

            new Competitors
            {
                Id = 3, CategoryId = 2, FirstName = "Elif", LastName = "Demirtaş", IsDeleted = false,
                CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now
            },
        ];

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_competitors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var competitor = _competitors.FirstOrDefault(x => x.Id == id);
            if (competitor == null)
            {
                return NotFound();
            }

            return Ok(competitor);
        }


        [HttpPost]
        public IActionResult Post(CompetitorRequest competitorRequest)
        {
            var competitor = new Competitors
            {
                Id = _competitors.Max(c => c.Id) + 1,
                CategoryId = competitorRequest.CategoryId,
                FirstName = competitorRequest.FirstName,
                LastName = competitorRequest.LastName,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _competitors.Add(competitor);
            return CreatedAtAction(nameof(Get), new { id = competitor.Id }, competitor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CompetitorRequest competitorRequest)
        {
            var competitor = _competitors.FirstOrDefault(x => x.Id == id);
            if (competitor == null)
            {
                return NotFound();
            }

            competitor.CategoryId = competitorRequest.CategoryId;
            competitor.FirstName = competitorRequest.FirstName;
            competitor.LastName = competitorRequest.LastName;
            competitor.ModifiedDate = DateTime.Now;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var competitor = _competitors.FirstOrDefault(x => x.Id == id);
            if (competitor == null)
            {
                return NotFound();
            }

            _competitors.Remove(competitor);
            return NoContent();
        }
    }
}