using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonstersFINAL
{
    
    public class De
    {
        //méthode qui retourne un entier aléatoire
        public static int Lance(int Minimum, int Maximum) //???
        {
            Random rnd = new();
            return rnd.Next(Minimum,Maximum+1);
        }
    }
}
