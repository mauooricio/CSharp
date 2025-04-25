// Models/Usuario.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShopCSharp.Models
{
  public abstract class Usuario
  {
    [Key] public int Id { get; set; }
    [Required] public string Nome { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Senha { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    public bool Ativo { get; set; } = true;

    public ICollection<Publicacao> Publicacoes { get; set; }
    public ICollection<Notificacao> Notificacoes { get; set; }
  }
}
