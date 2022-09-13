using System;
using System.Collections.Generic;
using Spectre.Console;
using static System.Console;

namespace HeroesVsMonstersFINAL
{
    class Program
    {
        static void Main(string[] args)
        {

            //créer la liste de personnages
            List<Personnage> listeP;


            //créer la liste d'events
            List<string> eventsL;

            //créer une liste pour les persos morts
            List<Personnage> ennemisDead;



            while (Jeu.PlayAgain("Voulez-vous jouer une partie? o/n"))
            {
                GamePlay.Start(out listeP, out eventsL, out ennemisDead);
                Console.ReadKey();
                Shorewood.FinalReport(listeP, ennemisDead, eventsL);
            }

            Console.Clear();
            Console.WriteLine("Merci d'avoir joué à Shorewood! Aurevoir!");
        }
    }
}
