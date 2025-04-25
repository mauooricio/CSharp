// Controllers/PublicacoesController.cs
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
  public class PublicacoesController : ControllerBase
  {
    private readonly AppDbContext _ctx;
    public PublicacoesController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Publicacao>>> GetAll() =>
      await _ctx.Publicacoes
                .Include(p => p.Autor)
                .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Publicacao>> Get(int id)
    {
      var p = await _ctx.Publicacoes.FindAsync(id);
      return p == null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public async Task<ActionResult<Publicacao>> Create(Publicacao p)
    {
      _ctx.Publicacoes.Add(p);
      await _ctx.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Publicacao p)
    {
      if (id != p.Id) return BadRequest();
      _ctx.Entry(p).State = EntityState.Modified;
      await _ctx.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var p = await _ctx.Publicacoes.FindAsync(id);
      if (p == null) return NotFound();
      _ctx.Publicacoes.Remove(p);
      await _ctx.SaveChangesAsync();
      return NoContent();
    }
  }
}
