// Models/Voluntario.cs
using System.Collections.Generic;
namespace PetShopCSharp.Models
{
  public class Voluntario : Usuario
  {
    public ICollection<EventoInstitucional> EventosAuxiliados { get; set; }
  }
}
