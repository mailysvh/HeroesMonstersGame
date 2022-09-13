using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonstersFINAL
{
    class Nain : Hero
    {
        public Nain(string _name) : base(_name)
        {
            this.Endurance += 2;
        }
    }
}
