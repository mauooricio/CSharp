// Controllers/InscricoesEventoController.cs
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
  public class InscricoesEventoController : ControllerBase
  {
    private readonly AppDbContext _ctx;
    public InscricoesEventoController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InscricaoEvento>>> GetAll() =>
      await _ctx.InscricoesEvento
                .Include(i => i.Participante)
                .Include(i => i.Evento)
                .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<InscricaoEvento>> Get(int id)
    {
      var i = await _ctx.InscricoesEvento.FindAsync(id);
      return i == null ? NotFound() : Ok(i);
    }

    [HttpPost]
    public async Task<ActionResult<InscricaoEvento>> Create(InscricaoEvento i)
    {
      _ctx.InscricoesEvento.Add(i);
      await _ctx.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = i.Id }, i);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, InscricaoEvento i)
    {
      if (id != i.Id) return BadRequest();
      _ctx.Entry(i).State = EntityState.Modified;
      await _ctx.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var i = await _ctx.InscricoesEvento.FindAsync(id);
      if (i == null) return NotFound();
      _ctx.InscricoesEvento.Remove(i);
      await _ctx.SaveChangesAsync();
      return NoContent();
    }
  }
}
