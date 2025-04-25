// Models/InscricaoEvento.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PetShopCSharp.Models
{
  public class InscricaoEvento
  {
    [Key] public int Id { get; set; }
    public int EventoInstitucionalId { get; set; }
    public EventoInstitucional Evento { get; set; }
    public int ParticipanteId { get; set; }
    public Participante Participante { get; set; }
    public string Status { get; set; }
    public DateTime DataInscricao { get; set; }
  }
}
