// Models/Participante.cs
using System.Collections.Generic;
namespace PetShopCSharp.Models
{
  public class Participante : Usuario
  {
    public ICollection<InscricaoEvento> Inscricoes { get; set; }
  }
}
