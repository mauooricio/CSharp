// Controllers/AtividadesController.cs
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
  public class AtividadesController : ControllerBase
  {
    private readonly AppDbContext _ctx;
    public AtividadesController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Atividade>>> GetAll() =>
      await _ctx.Atividades
                .Include(a => a.Projeto)
                .Include(a => a.EventoInstitucional)
                .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Atividade>> Get(int id)
    {
      var a = await _ctx.Atividades.FindAsync(id);
      return a == null ? NotFound() : Ok(a);
    }

    [HttpPost]
    public async Task<ActionResult<Atividade>> Create(Atividade a)
    {
      _ctx.Atividades.Add(a);
      await _ctx.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = a.Id }, a);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Atividade a)
    {
      if (id != a.Id) return BadRequest();
      _ctx.Entry(a).State = EntityState.Modified;
      await _ctx.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var a = await _ctx.Atividades.FindAsync(id);
      if (a == null) return NotFound();
      _ctx.Atividades.Remove(a);
      await _ctx.SaveChangesAsync();
      return NoContent();
    }
  }
}
