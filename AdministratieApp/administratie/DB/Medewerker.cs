using System.ComponentModel.DataAnnotations.Schema;

namespace AdminstratieApp
{
    class Medewerker : Gebruiker
    {
        [InverseProperty("Coordinatoren")]
        public List<Onderhoud> CoordinatorOnderhoud { get; set; }
        [InverseProperty("Uitvoerders")]
        public List<Onderhoud> UitvoerderOnderhoud { get; set; }
        public Medewerker(string Email) : base(Email)
        {
        }
    }
}