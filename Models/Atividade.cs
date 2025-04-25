// Models/Atividade.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PetShopCSharp.Models
{
  public class Atividade
  {
    [Key] public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public string Status { get; set; }
    public int Progresso { get; set; }

    public int ProjetoId { get; set; }
    public Projeto Projeto { get; set; }

    public int? EventoInstitucionalId { get; set; }
    public EventoInstitucional EventoInstitucional { get; set; }
  }
}
