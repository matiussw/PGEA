using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGEA.API.Data;
using PGEA.shared.Entities;

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
        public async Task<IActionResult> GetAsync(String id)
        {
            var researcher = await _context.Attendees.FirstOrDefaultAsync(x => x.Cedula == id);
            if (researcher == null)
            {
                return NotFound();
            }
            return Ok(researcher);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Attendee attendee)
        {
         
            try
            {
                _context.Add(attendee);
                await _context.SaveChangesAsync();
                return Ok(attendee);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Registro con el mismo Numero de cedula.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Attendee attendee)
        {
            try
            {
                _context.Update(attendee);
                await _context.SaveChangesAsync();
                return Ok(attendee);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un parcipante con el mismo Numero de cedula.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(String id)
        {
            var categories = await _context.Attendees.FirstOrDefaultAsync(x => x.Cedula == id);
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


