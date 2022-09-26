using Microsoft.EntityFrameworkCore;


namespace AdminstratieApp
{
    public class DatabaseContext : DbContext
    {
        public DbSet<GastInfo> GastInfos { get; set; }
        public DbSet<Gast> Gasten { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Onderhoud> Onderhoud { get; set; }
        public DbSet<Attractie> Attracties { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder b)
        // {
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruikers");
            modelBuilder.Entity<Gast>().ToTable("Gasten");
            modelBuilder.Entity<Medewerker>().ToTable("Medewerkers");
        }
        public async Task<bool> Boek(Gast g, Attractie a, DateTimeBereik d)
        {
            Reservering r = new Reservering() { Gast = g, Attractie = a, DateTimeBereik = d };

            var gast = Gasten.FirstOrDefault(item => item.Id == g.Id);

            if (!Attracties.Contains(a))
            {
                return false;
            }
            if (!Gasten.Contains(g))
            {
                return false;
            }
            if (!await a.Vrij(this, d))
            {
                return false;
            }

            await a.Semaphore.WaitAsync();
            try
            {
                if (gast != null)
                {
                    if (gast.Reserveringen == null)
                    {
                        gast.Reserveringen = new List<Reservering> { r };
                    }
                    else
                    {
                        gast.Reserveringen.Add(r);
                    }
                }
                Gasten.First(gast => gast.Id == g.Id).Credits -= 1;
            }
            finally { a.Semaphore.Release(); }

            SaveChanges();

            return true;
        }

    }
}