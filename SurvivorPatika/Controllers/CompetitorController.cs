using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurvivorPatika.DTO;
using SurvivorPatika.MockData;
using SurvivorPatika.Models;

namespace SurvivorPatika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
 
        private readonly List<Competitors> _competitors = CompetitorService.Competitors;

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