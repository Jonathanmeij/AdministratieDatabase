namespace AdminstratieApp
{
    class GastInfo
    {
        public int Id { get; set; }
        public string? LaatstBezochteURL { get; set; }
        public Coordinate Coordinate { get; set; }



        public int GastId { get; set; }
        public Gast Gast { get; set; }
    }
}