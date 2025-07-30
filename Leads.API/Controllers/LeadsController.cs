using Leads.Core.Interfaces;
using Leads.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leads.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly IRepository<Lead> context;

        public LeadsController(IRepository<Lead> context)
        {
            this.context = context;
        }
        // GET: api/Leads
        [HttpGet]
        public ActionResult<IEnumerable<Lead>> Get()
        {
            var leads = context.Collection().ToList();
            return Ok(leads);
        }

        // GET api/Leads/5
        [HttpGet("{id}")]
        public ActionResult<Lead> Get(string id)
        {
            var lead = context.Find(id);
            if (lead == null)
            {
                return NotFound();
            }
            return Ok(lead);
        }

        // POST api/Leads
        [HttpPost]
        public ActionResult<Lead> Post([FromBody] Lead lead)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Insert(lead);
            context.Commit();
            return CreatedAtAction(nameof(Get), new { id = lead.Id }, lead);
        }

        // PUT api/Leads/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Lead lead)
        {
            var existing = context.Find(id);
            if (existing == null)
                return NotFound();

            context.Update(lead);
            context.Commit();
            return NoContent();
        }

        // DELETE api/Leads/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var lead = context.Find(id);
            if (lead == null)
                return NotFound();

            context.Delete(id);
            context.Commit();
            return NoContent();
        }
    }
}
