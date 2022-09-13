using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonstersFINAL
{
    class Orque : Monstre
    {
        public Orque(string _name) : base(_name)
        {
            //L’or et le cuir sont calculé à la création du monstre en sachant que l’or est calculé sur base d’un dé 6 faces tandis que le cuir est calculé sur base d’un dé 4 face.

            //ont de l'or, aléatoire 
            this.Or = De.Lance(1, 6);
            //dépecer
            this.Cuir = 0;
            this.Force += 1;
        }
    }
}
