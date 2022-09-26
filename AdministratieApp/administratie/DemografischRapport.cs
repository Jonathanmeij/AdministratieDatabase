using Microsoft.EntityFrameworkCore;
namespace AdminstratieApp
{
    public class DemografischRapport : Rapport
    {
        private DatabaseContext context;
        public DemografischRapport(DatabaseContext context) => this.context = context;
        public override string Naam() => "Demografie";
        public override async Task<string> Genereer()
        {
            string ret = "Dit is een demografisch rapport: \n";
            ret += $"Er zijn in totaal {await AantalGebruikers()} gebruikers van dit platform (dat zijn gasten en medewerkers)\n";
            var dateTime = new DateTime(2000, 1, 1);
            ret += $"Er zijn {await AantalSinds(dateTime)} bezoekers sinds {dateTime}\n";
            if (await AlleGastenHebbenReservering())
                ret += "Alle gasten hebben een reservering\n";
            else
                ret += "Niet alle gasten hebben een reservering\n";
            ret += $"Het percentage bejaarden is {await PercentageBejaarden()}\n";

            ret += $"De oudste gast heeft een leeftijd van {await HoogsteLeeftijd()} \n";

            ret += "De verdeling van de gasten per dag is als volgt: \n";
            // var dagAantallen = await VerdelingPerDag();
            // var totaal = dagAantallen.Select(t => t.aantal).Max();
            // foreach (var dagAantal in dagAantallen)
            //     ret += $"{dagAantal.dag}: {new string('#', (int)(dagAantal.aantal / (double)totaal * 20))}\n";

            // ret += $"{await FavorietCorrect()} gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

            return ret;
        }
        private double berekenLeeftijd(DateTime d) => (DateTime.Now - d).TotalDays / 365.25;

        private async Task<int> AantalGebruikers() => context.Gebruikers.Count();
        private async Task<bool> AlleGastenHebbenReservering() => context.Gasten.All(gast => gast.Reserveringen.Count > 0);
        private async Task<int> AantalSinds(DateTime sinds) => context.Gasten.Where(gast => gast.EersteBezoek >= sinds).Count();
        private async Task<Gast>? GastBijEmail(string email) => context.Gasten.SingleOrDefault(gast => gast.Email == email);
        private async Task<Gast?> GastBijGeboorteDatum(DateTime d) => context.Gasten.Single(gast => gast.GeboorteDatum == d);
        private async Task<double> PercentageBejaarden() => (double)context.Gasten.Where(gast => (gast.GeboorteDatum < DateTime.Now.AddYears(-80))).Count() / await AantalGebruikers() * 100; // testen 
        private async Task<IEnumerable<Gast>> Blut() => context.Gasten.Where(gast => gast.Credits == 0);
        private async Task<int> HoogsteLeeftijd() => (int)berekenLeeftijd(context.Gasten.Select(gast => gast.GeboorteDatum).Min());
        // private async Task<(string dag, int aantal)[]> VerdelingPerDag() => context.Gasten.Where(gast => gast.EersteBezoek >= DateTime.Now.AddDays(-7)).ToList().GroupBy(gast => gast.EersteBezoek, (dagGroep, gasten) => (dag = dagGroep.DayOfWeek, aantal = gasten.Count()));
        // private async Task<int> FavorietCorrect() => /* ... */;
    }
}