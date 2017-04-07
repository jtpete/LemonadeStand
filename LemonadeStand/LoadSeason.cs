using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class LoadSeason : Season
    {
        public LoadSeason(int seasonLength) : base(seasonLength)
        {
            this.seasonLength = seasonLength;
        }
    }
}
