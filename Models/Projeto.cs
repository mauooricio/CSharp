// Models/Projeto.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShopCSharp.Models
{
  public class Projeto
  {
    [Key] public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Status { get; set; }

    public int ResponsavelId { get; set; }
    public Usuario Responsavel { get; set; }

    public ICollection<Atividade> Atividades { get; set; }
    public ICollection<Relatorio> Relatorios { get; set; }
  }
}
