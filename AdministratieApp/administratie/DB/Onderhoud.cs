using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminstratieApp
{
    class Onderhoud
    {
        public int Id { get; set; }
        [InverseProperty("CoordinatorOnderhoud")]
        public List<Medewerker> Coordinatoren { get; set; }
        [InverseProperty("UitvoerderOnderhoud")]
        public List<Medewerker> Uitvoerders { get; set; }
        public string Probleem { get; set; }
        public DateTimeBereik DateTimeBereik { get; set; }
        [Required]
        public Attractie Attractie { get; set; }
    }
}