// Models/Notificacao.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PetShopCSharp.Models
{
  public class Notificacao
  {
    [Key] public int Id { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataEnvio { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Destinatario { get; set; }
  }
}
