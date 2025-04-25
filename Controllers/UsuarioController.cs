// Controllers/UsuariosController.cs
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
  public class UsuariosController : ControllerBase
  {
    private readonly AppDbContext _ctx;
    public UsuariosController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetAll() =>
      await _ctx.Usuarios.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> Get(int id)
    {
      var u = await _ctx.Usuarios.FindAsync(id);
      return u == null ? NotFound() : Ok(u);
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> Create(Usuario u)
    {
      _ctx.Usuarios.Add(u);
      await _ctx.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = u.Id }, u);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Usuario u)
    {
      if (id != u.Id) return BadRequest();
      _ctx.Entry(u).State = EntityState.Modified;
      await _ctx.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var u = await _ctx.Usuarios.FindAsync(id);
      if (u == null) return NotFound();
      _ctx.Usuarios.Remove(u);
      await _ctx.SaveChangesAsync();
      return NoContent();
    }
  }
}
