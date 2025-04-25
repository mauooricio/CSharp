// Controllers/NotificacoesController.cs
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
  public class NotificacoesController : ControllerBase
  {
    private readonly AppDbContext _ctx;
    public NotificacoesController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Notificacao>>> GetAll() =>
      await _ctx.Notificacoes
                .Include(n => n.Destinatario)
                .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Notificacao>> Get(int id)
    {
      var n = await _ctx.Notificacoes.FindAsync(id);
      return n == null ? NotFound() : Ok(n);
    }

    [HttpPost]
    public async Task<ActionResult<Notificacao>> Create(Notificacao n)
    {
      _ctx.Notificacoes.Add(n);
      await _ctx.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = n.Id }, n);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Notificacao n)
    {
      if (id != n.Id) return BadRequest();
      _ctx.Entry(n).State = EntityState.Modified;
      await _ctx.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var n = await _ctx.Notificacoes.FindAsync(id);
      if (n == null) return NotFound();
      _ctx.Notificacoes.Remove(n);
      await _ctx.SaveChangesAsync();
      return NoContent();
    }
  }
}
