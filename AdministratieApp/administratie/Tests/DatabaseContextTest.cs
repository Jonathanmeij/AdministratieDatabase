using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AdminstratieApp;

public class DatabasecontextTest
{
    private string DatabaseName;
    private DatabaseContext GetInMemoryDBMetData()
    {
        DatabaseContext c = GetNewInMemoryDB(true);

        var nieuweGast = new Gast($"gast@mail.com") { GeboorteDatum = new DateTime(2000, 3, 4), EersteBezoek = new DateTime(2004, 5, 4), Credits = 3 };
        c.Gasten.Add(nieuweGast);
        var nieuweAttractie = new Attractie("draaimolen");
        c.Attracties.Add(nieuweAttractie);
        c.SaveChanges();

        return GetNewInMemoryDB(false);
    }

    private DatabaseContext GetNewInMemoryDB(bool NewDB)
    {
        if (NewDB)
        {
            this.DatabaseName = Guid.NewGuid().ToString();
        }
        var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(this.DatabaseName).Options;
        DatabaseContext c = new DatabaseContext(options);
        return c;
    }

    [Fact]
    public void BoekMaaktEenNieuweReserveringAan()
    {
        //arrange
        var c = GetInMemoryDBMetData();

        //act
        var gast = c.Gasten.First();
        var attractie = c.Attracties.First();
        var bereik = new DateTimeBereik() { Begin = new DateTime(2022, 3, 3), Eind = new DateTime(2022, 3, 5) };
        c.Boek(gast, attractie, bereik);
        var expected = new Reservering() { Id = 1, DateTimeBereik = bereik, Gast = gast, Attractie = attractie };

        //assert
        Assert.Equal(c.Reserveringen.First(), expected);
    }

}

