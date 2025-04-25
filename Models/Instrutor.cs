// Models/Instrutor.cs
using System.Collections.Generic;
namespace PetShopCSharp.Models
{
  public class Instrutor : Usuario
  {
    public ICollection<EventoInstitucional> EventosOrganizados { get; set; }
  }
}
