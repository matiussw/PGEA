using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGEA.API.Data;
using PGEA.shared.Entities;

namespace PGEA.API.Controllers
{
    [ApiController]
    [Route("/api/academicevent")]
    public class AcademicEventController:ControllerBase
	{
            private readonly DataContext _context;

            public AcademicEventController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetAsync()
            {

                return Ok(await _context.AcademicEvents.ToListAsync());
            }

            [HttpGet("{name:string}")]
            public async Task<IActionResult> GetAsync(string name)
            {
                var researcher = await _context.AcademicEvents.FirstOrDefaultAsync(x => x.Name == name);
                if (researcher == null)
                {
                    return NotFound();
                }
                return Ok(researcher);
            }

            [HttpPost("{name:string}")]
            public async Task<ActionResult> PostAsync(AcademicEvent academic)
            {
                try
                {
                    _context.Add(academic);
                    await _context.SaveChangesAsync();
                    return Ok(academic);
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
            public async Task<ActionResult> PutAsync(AcademicEvent academicEvent)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    _context.Update(academicEvent);
                    await _context.SaveChangesAsync();
                    return Ok(academicEvent);
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

            [HttpDelete("{name:string}")]
            public async Task<IActionResult> DeleteAsync(string name)
            {
                var academic = await _context.ProgramEvents.FirstOrDefaultAsync(x => x.Name == name);
                if (academic == null)
                {
                    return NotFound();
                }

                _context.Remove(academic);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }


