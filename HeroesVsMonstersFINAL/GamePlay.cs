using System;
using System.Collections.Generic;
using Figgle;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonstersFINAL
{
    class GamePlay
    {
        public static void Start(out List<Personnage> listePersonnages, out List<string> eventsLog, out List<Personnage> ennemisAbbatus)
        {
            Random rnd = new Random();
            listePersonnages = new(); 
            eventsLog = new();
            ennemisAbbatus = new();
            
            //Main menu
            listePersonnages.Add(Jeu.RunMainMenu());
            listePersonnages[0].IsMain = true;
            listePersonnages[0].Xp = 0;

            //Générer les autres personnages
            int choice = Jeu.ChoiceNPCInt(); //check min 1
            for (int i = 0; i < choice; i++) { listePersonnages.Add(Jeu.CreePersoRandom()); }

            //Commencer le jeu

            //afficher la liste des persos
            Console.Clear();
            Console.WriteLine(FiggleFonts.Ogre.Render("Characters   Stats"));
            Shorewood.AfficherTout(listePersonnages);
            Console.ReadKey();

            //COMBAT
            Console.Clear();
            Console.WriteLine("\n");
            int compteur = 1;

            Console.WriteLine(FiggleFonts.Ogre.Render("Now   Fight"));

            while (Jeu.IsMainAlive(listePersonnages) && !Jeu.DefeatedAllEnnemies(listePersonnages[0], listePersonnages)) 
            {
                //choisir l'adversaire
                int choixIntAdv = rnd.Next(1, listePersonnages.Count);
                //battle entre les 2
                Jeu.Battle(compteur, listePersonnages[0], listePersonnages[choixIntAdv], listePersonnages, ennemisAbbatus, eventsLog);
                compteur++;
            }
            Console.WriteLine("Fin du jeu!");
        }
    }
}
