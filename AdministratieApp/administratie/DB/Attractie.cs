namespace AdminstratieApp
{
    class Attractie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        //one to many relation with Onderhoud
        public List<Onderhoud> OnderhoudsBeurten { get; set; }
        public List<Gast> Gasten { get; set; }
        public Reservering? Reservering { get; set; }

        public Attractie(string Naam)
        {
            this.Naam = Naam;
        }
        // public Task<bool> OnderhoudBezig(DatabaseContext c)
        // {
        //     return new Task<bool>();
        // }

        // public Task<bool> Vrij(DatabaseContext c, DateTimeBereik d)
        // {

        // }
    }
}