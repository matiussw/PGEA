
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGEA.API.Data;
using PGEA.shared.Entities;

namespace PGEA.API.Controllers
{
    [ApiController]
    [Route("/api/programevent")]
    public class ProgramEventController: ControllerBase
    {
        private readonly DataContext _context;

        public ProgramEventController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            return Ok(await _context.ProgramEvents.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var researcher = await _context.ProgramEvents.FirstOrDefaultAsync(x => x.Id == id);
            if (researcher == null)
            {
                return NotFound();
            }
            return Ok(researcher);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(ProgramEvent programEvent)
        {
            try
            {
                _context.Add(programEvent);
                await _context.SaveChangesAsync();
                return Ok(programEvent);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un un evento con el mismo Nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(ProgramEvent programEvent)
        {
            try
            {
                _context.Update(programEvent);
                await _context.SaveChangesAsync();
                return Ok(programEvent);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un evento con el mismo Nombre.");
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
            var categories = await _context.ProgramEvents.FirstOrDefaultAsync(x => x.Id == id);
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


