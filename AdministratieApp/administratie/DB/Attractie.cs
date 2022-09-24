namespace AdminstratieApp
{
    class Attractie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        //one to many relation with Onderhoud
        public List<Onderhoud> OnderhoudsBeurten { get; set; }
        public List<Gast> Gasten { get; set; }
        public List<Reservering> Reserveringen { get; set; }

        public Attractie(string Naam)
        {
            this.Naam = Naam;
        }
        public bool OnderhoudBezig(DatabaseContext c)
        {
            var nu = new DateTimeBereik() { Begin = DateTime.Now.AddMilliseconds(-1), Eind = DateTime.Now };
            foreach (var o in c.Onderhoud)
            {
                if (o.Attractie.Naam == this.Naam && o.DateTimeBereik.Overlapt(nu))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Vrij(DatabaseContext c, DateTimeBereik d)
        {
            //explicit loading
            foreach (var r in c.Reserveringen)
            {
                if (r.Attractie.Naam == this.Naam && d.Overlapt(r.DateTimeBereik))
                {
                    return false;
                }
            }
            if (OnderhoudBezig(c))
            {
                return false;
            }
            return true;
        }
    }
}