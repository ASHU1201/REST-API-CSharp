using CitizenData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitizenData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ControllerBase
    {
        private static List<Entity> _entities = new List<Entity>();

        // CRUD endpoints

        // GET: api/entity
        [HttpGet]
        public IActionResult GetAllEntities()
        {
            return Ok(_entities);
        }

        // GET: api/entity/{id}
        [HttpGet("{id}")]
        public IActionResult GetEntityById(string id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/entity
        [HttpPost]
        public IActionResult AddEntity(Entity entity)
        {
            entity.Id = Guid.NewGuid().ToString(); // Generate unique ID
            _entities.Add(entity);
            return CreatedAtAction(nameof(GetEntityById), new { id = entity.Id }, entity);
        }

        // PUT: api/entity/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEntity(string id, Entity entity)
        {
            var existingEntity = _entities.FirstOrDefault(e => e.Id == id);
            if (existingEntity == null)
                return NotFound();

            entity.Id = id; // Ensure ID is preserved
            int index = _entities.IndexOf(existingEntity);
            _entities[index] = entity;

            return NoContent();
        }

        // DELETE: api/entity/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEntity(string id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                return NotFound();

            _entities.Remove(entity);
            return NoContent();
        }

        // Additional functionality

        // GET: api/entity/search
        [HttpGet("search")]
        public IActionResult SearchEntities([FromQuery] string search)
        {
            var results = _entities.Where(e =>
                e.Addresses.Any(a => a.AddressLine?.Contains(search, StringComparison.OrdinalIgnoreCase) == true) ||
                e.Names.Any(n =>
                    n.FirstName?.Contains(search, StringComparison.OrdinalIgnoreCase) == true ||
                    n.MiddleName?.Contains(search, StringComparison.OrdinalIgnoreCase) == true ||
                    n.Surname?.Contains(search, StringComparison.OrdinalIgnoreCase) == true) ||
                e.Gender?.Contains(search, StringComparison.OrdinalIgnoreCase) == true
            ).ToList();

            return Ok(results);
        }

        // GET: api/entity/filter
        [HttpGet("filter")]
        public IActionResult FilterEntities([FromQuery] string gender, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] List<string> countries)
        {
            var results = _entities.Where(e =>
                (gender == null || e.Gender == gender) &&
                (startDate == null || e.Dates.Any(d => d.DateValue >= startDate)) &&
                (endDate == null || e.Dates.Any(d => d.DateValue <= endDate)) &&
                (countries == null || countries.Count == 0 || e.Addresses.Any(a => countries.Contains(a.Country)))
            ).ToList();

            return Ok(results);
        }
    }

}
