using Microsoft.EntityFrameworkCore;

namespace AdminstratieApp
{
    [Owned]
    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}