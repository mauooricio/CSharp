// Models/Relatorio.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PetShopCSharp.Models
{
  public class Relatorio
  {
    [Key] public int Id { get; set; }
    public string Titulo { get; set; }
    public string Conteudo { get; set; }
    public DateTime DataCriacao { get; set; }

    public int ProjetoId { get; set; }
    public Projeto Projeto { get; set; }

    public int AvaliadoPorId { get; set; }
    public Administrador AvaliadoPor { get; set; }
  }
}
