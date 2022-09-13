using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonstersFINAL
{
    class Humain : Hero
    {
        public Humain(string _name) : base(_name)
        {
            this.Force += 1;
            this.Endurance += 1;
        }
    }
}
