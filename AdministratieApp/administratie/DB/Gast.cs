namespace AdminstratieApp
{
    class Gast : Gebruiker
    {
        public int Credits { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime EersteBezoek { get; set; }

        public GastInfo? GastInfo { get; set; }
        public Gast? Begeleider { get; set; }
        public Attractie? Favoriet { get; set; }
        public List<Reservering>? Reserveringen { get; set; }
        public Gast(string Email) : base(Email)
        {
        }
    }
}