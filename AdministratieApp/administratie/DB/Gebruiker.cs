namespace AdminstratieApp
{
    class Gebruiker
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public Gebruiker(string Email)
        {
            this.Email = Email;
        }
    }
}