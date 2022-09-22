using Microsoft.EntityFrameworkCore;

namespace AdminstratieApp
{
    [Owned]
    class DateTimeBereik
    {
        public DateTime Begin { get; set; }
        public DateTime? Eind { get; set; }

        public bool Eindigt() { return true; }
        public bool Overlapt(DateTimeBereik that)
        {
            if ((this.Begin <= that.Eind) && (that.Begin <= this.Eind))
            {
                return true;
            }
            return false;
        }
    }
}