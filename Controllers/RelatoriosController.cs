// Controllers/RelatoriosController.cs
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
  public class RelatoriosController : ControllerBase
  {
    private readonly AppDbContext _ctx;
    public RelatoriosController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Relatorio>>> GetAll() =>
      await _ctx.Relatorios
                .Include(r => r.Projeto)
                .Include(r => r.AvaliadoPor)
                .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Relatorio>> Get(int id)
    {
      var r = await _ctx.Relatorios.FindAsync(id);
      return r == null ? NotFound() : Ok(r);
    }

    [HttpPost]
    public async Task<ActionResult<Relatorio>> Create(Relatorio r)
    {
      _ctx.Relatorios.Add(r);
      await _ctx.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = r.Id }, r);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Relatorio r)
    {
      if (id != r.Id) return BadRequest();
      _ctx.Entry(r).State = EntityState.Modified;
      await _ctx.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var r = await _ctx.Relatorios.FindAsync(id);
      if (r == null) return NotFound();
      _ctx.Relatorios.Remove(r);
      await _ctx.SaveChangesAsync();
      return NoContent();
    }
  }
}
