using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGEA.API.Data;

namespace PGEA.API.Controllers
{ 
    [ApiController]
	[Route("/api/attenders")]
	public class AttendeController: ControllerBase
    {
        private readonly DataContext _context;

        public AttendeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            return Ok(await _context.Attendees.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var researcher = await _context.Attendees.FirstOrDefaultAsync(x => x.Cedula == id);
            if (researcher == null)
            {
                return NotFound();
            }
            return Ok(researcher);
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult> PostAsync(Attendee researcher)
        {
            try
            {
                _context.Add(researcher);
                await _context.SaveChangesAsync();
                return Ok(researcher);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Investigador con el mismo Numero de cedula.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Researcher researcher)
        {
            try
            {
                _context.Update(researcher);
                await _context.SaveChangesAsync();
                return Ok(researcher);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Investigador con el mismo Numero de cedula.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var categories = await _context.Researchers.FirstOrDefaultAsync(x => x.Cedula == id);
            if (categories == null)
            {
                return NotFound();
            }

            _context.Remove(categories);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}


