// Controllers/EventosInstitucionaisController.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopCSharp.Data;
using PetShopCSharp.Models;

namespace PetShopCSharp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosInstitucionaisController : ControllerBase
  {
    private readonly AppDbContext _ctx;
    public EventosInstitucionaisController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventoInstitucional>>> GetAll() =>
      await _ctx.EventosInstitucionais
                .Include(e => e.Inscricoes)
                .Include(e => e.Atividades)
                .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<EventoInstitucional>> Get(int id)
    {
      var e = await _ctx.EventosInstitucionais.FindAsync(id);
      return e == null ? NotFound() : Ok(e);
    }

    [HttpPost]
    public async Task<ActionResult<EventoInstitucional>> Create(EventoInstitucional e)
    {
      _ctx.EventosInstitucionais.Add(e);
      await _ctx.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = e.Id }, e);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EventoInstitucional e)
    {
      if (id != e.Id) return BadRequest();
      _ctx.Entry(e).State = EntityState.Modified;
      await _ctx.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var e = await _ctx.EventosInstitucionais.FindAsync(id);
      if (e == null) return NotFound();
      _ctx.EventosInstitucionais.Remove(e);
      await _ctx.SaveChangesAsync();
      return NoContent();
    }
  }
}
