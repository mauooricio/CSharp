// Controllers/ProjetosController.cs
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
  public class ProjetosController : ControllerBase
  {
    private readonly AppDbContext _ctx;
    public ProjetosController(AppDbContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<IEnumerable<Projeto>> GetAll() =>
      await _ctx.Projetos.Include(p=>p.Atividades).ToListAsync();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var p = await _ctx.Projetos.FindAsync(id);
      return p == null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Projeto p)
    {
      _ctx.Projetos.Add(p);
      await _ctx.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Projeto p)
    {
      if (id != p.Id) return BadRequest();
      _ctx.Entry(p).State = EntityState.Modified;
      await _ctx.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var p = await _ctx.Projetos.FindAsync(id);
      if (p == null) return NotFound();
      _ctx.Projetos.Remove(p);
      await _ctx.SaveChangesAsync();
      return NoContent();
    }
  }
}
