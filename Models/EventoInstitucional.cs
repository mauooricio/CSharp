// Models/EventoInstitucional.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShopCSharp.Models
{
  public class EventoInstitucional
  {
    [Key] public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string DescricaoDetalhada { get; set; }
    public string Tipo { get; set; }
    public DateTime Data { get; set; }
    public string Local { get; set; }
    public int VagasDisponiveis { get; set; }
    public bool InscricoesAbertas { get; set; }

    public int OrganizadorId { get; set; }
    public Instrutor Organizador { get; set; }

    public ICollection<InscricaoEvento> Inscricoes { get; set; }
    public ICollection<Atividade> Atividades { get; set; }
  }
}
