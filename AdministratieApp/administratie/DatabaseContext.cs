using Microsoft.EntityFrameworkCore;

namespace AdminstratieApp
{
    class DatabaseContext : DbContext
    {
        public DbSet<GastInfo> GastInfos { get; set; }
        public DbSet<Gast> Gasten { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Onderhoud> Onderhoud { get; set; }
        public DbSet<Attractie> Attracties { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder b)
        {
            b.UseSqlite("Data Source=database.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruikers");
            modelBuilder.Entity<Gast>().ToTable("Gasten");
            modelBuilder.Entity<Medewerker>().ToTable("Medewerkers");
        }
        public async Task<bool> Boek(Gast g, Attractie a, DateTimeBereik d)
        {
            Reservering r = new Reservering() { Gast = g, Attracties = new List<Attractie>() { a }, DateTimeBereik = d };

            var gast = Gasten.FirstOrDefault(item => item.Id == g.Id);

            if (gast != null)
            {
                if (gast.Reserveringen == null)
                {
                    Console.WriteLine("leeg");
                    gast.Reserveringen = new List<Reservering> { r };
                }
                else
                {
                    Console.WriteLine("Vol");
                    gast.Reserveringen.Add(r);
                }

            }
            return (await SaveChangesAsync() > 0);
        }

    }
}