namespace AdminstratieApp
{
    class Reservering
    {
        public int Id { get; set; }
        public DateTimeBereik DateTimeBereik { get; set; }
        public Gast? Gast;
        public List<Attractie> Attracties { get; set; }
    }
}