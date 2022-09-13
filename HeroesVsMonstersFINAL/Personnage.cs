using System;
using System.Collections.Generic;
using Spectre.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonstersFINAL
{
    //abstract = intended only to be a base class of other classes, not instantiated on its own.
    
    abstract class Personnage
    {
        Random rnd = new();

        #region properties
        public string Name { get; set; }
        public int Xp { get; set; }
        public int EnduranceInitiale { get; private set; }
        public int Endurance { get; set; }
        public int ForceInitiale { get; private set; }
        public int Force { get; set; }
        public int MaxHP { get; private set; }
        public int HP { get; set; }

        public int Or { get; set; }
        public int Cuir { get; set; }

        public bool IsAlive { get; set; }

        public bool IsMain { get; set; }



        #endregion


        #region constructors
        public Personnage(string _name)
        {
            this.Name = _name;
            //xp random 0 à 4
            this.Xp = rnd.Next(0, 3);
            //Les bonus d’endurance et de force offerts par les classes (Humain, Nain, Orque et Dragonnet) ne doivent pas modifier la caractéristique de base du personnage
            this.ForceInitiale = CalculForceEnd(this);
            this.EnduranceInitiale = CalculForceEnd(this);
            //Les points de vie sont déterminés par l’endurance additionnée avec le modificateur1 basé sur l’endurance.
            this.MaxHP = AjustLevel(EnduranceInitiale); 
            this.HP = MaxHP; 
            this.IsAlive = true;
            this.Force = ForceInitiale;
            this.Endurance = EnduranceInitiale;
        }
        #endregion

        #region Methods

        //calcul force et endurance
        public static int CalculForceEnd(Personnage p)
        {
            //La force et l’endurance sont calculées à la création du personnage en lançant, pour chacune d’elles, quatre dé 6 faces et en n’en reprenant que les 3 meilleurs. + j'ai rajouté xp * 2
            List<int> ints = new();
            for (int i = 0; i < 4; i++)
            {
                int temp = De.Lance(1, 6);
                ints.Add(temp);
            }
            ints.Sort();
            return (ints[1] + ints[2] + ints[3]) + (p.Xp * 2);
        }

        //endurance OU force
        public static int AjustLevel(int baseLevel)
        {
            if (baseLevel < 5) {return baseLevel - 1;}
            else if (baseLevel < 10) {return baseLevel;}
            else if (baseLevel < 15) {return baseLevel + 1;}
            else {return baseLevel + 2;}
        }

        public string Frappe(Personnage perso)
        {
            // Lorsqu’un personnage frappe sur un autre, les dégâts sont déterminés par le jet d’un dé à 4 faces auquel on ajoute un modificateur1 basé sur la caractéristique de Force. Une fois calculé, les dégâts sont retirés des points de vies de la cible.

            //random entre 1 et 4
            int jetDe = De.Lance(1,4);
            int HPloss = jetDe + AjustLevel(Force);
            perso.HP -= HPloss;
            return $"{perso.GetType().Name} '{perso.Name}' est touché! Il perd {HPloss} points de vie.";
           
        }
        #endregion
    }
}
