// Models/Publicacao.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PetShopCSharp.Models
{
  public class Publicacao
  {
    [Key] public int Id { get; set; }
    public string Titulo { get; set; }
    public string Conteudo { get; set; }
    public DateTime DataPublicacao { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Autor { get; set; }
  }
}
