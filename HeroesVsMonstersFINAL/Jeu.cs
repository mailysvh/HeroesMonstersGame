using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Figgle;
using Spectre.Console;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonstersFINAL
{
    class Jeu
    {
        static Random rnd = new Random();

        public static bool DefeatedAllEnnemies(Personnage main, List<Personnage> persos)    //attention, prend la liste en entier pour éviter les exceptions si elle est vide
        {
            if (persos.Count > 1)
            {
                if (main.GetType().BaseType.Name == "Hero")
                {
                    foreach (Personnage p in persos)
                    {
                        if ((p.Name != main.Name) && p.GetType().BaseType.Name == "Monstre") //&& sinon le nom sera différent chaque tour sauf le 1, et il retournera false
                        { return false; }
                    }
                    return true;
                }
                else { return false; }
            }
            return true;
        }

        public static bool IsMainAlive(List<Personnage> listep)
        {
            foreach (Personnage p in listep)
            {
                if (p.IsMain) {return p.IsAlive;}
            }
            return false;
        }

        public static Personnage GetMain(List<Personnage> listep)
        {
            foreach (Personnage p in listep)
            {
                if (p.IsMain) { return p; }
            }
            return null;
        }

        #region PrintImage
        public static void PrintImage(Personnage p)
        {
            switch (p)
            {
                case Humain:
                    // Load an image
                    var image = new CanvasImage("C:\\Users\\Student\\source\\repos\\HeroesVsMonstersFINAL\\HeroesVsMonstersFINAL\\imgs\\humain.png").MaxWidth(18);
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Panel(image));
                    break;
                case Nain:
                    // Load an image
                    var image1 = new CanvasImage("C:\\Users\\Student\\source\\repos\\HeroesVsMonstersFINAL\\HeroesVsMonstersFINAL\\imgs\\nain.png").MaxWidth(18);
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Panel(image1));
                    break;
                case Loup:
                    // Load an image
                    var image2 = new CanvasImage("C:\\Users\\Student\\source\\repos\\HeroesVsMonstersFINAL\\HeroesVsMonstersFINAL\\imgs\\wolf.png").MaxWidth(21);
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Panel(image2));
                    break;
                case Orque:
                    // Load an image
                    var image3 = new CanvasImage("C:\\Users\\Student\\source\\repos\\HeroesVsMonstersFINAL\\HeroesVsMonstersFINAL\\imgs\\ork.png").MaxWidth(18);
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Panel(image3));
                    break;
                case Dragonnet:
                    // Load an image
                    var image4 = new CanvasImage("C:\\Users\\Student\\source\\repos\\HeroesVsMonstersFINAL\\HeroesVsMonstersFINAL\\imgs\\dragon.png").MaxWidth(21);
                    AnsiConsole.WriteLine();
                    AnsiConsole.Write(new Panel(image4));
                    break;
                default:
                    break;
            }
        }

        #endregion

        public static Personnage Create(ClassesPerso classesPerso, string nom)
        {
            //REFLECTION?
            // recupérer tous les types de l'assembly
            List<Type> types = Assembly.GetExecutingAssembly().GetTypes().ToList();
            // chercher  celui qui correspond à l'enum
            Type type = types.FirstOrDefault(t => t.Name == classesPerso.ToString());
            // création de l'instance
            object p = type.GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { nom });
            return (Personnage)p;
        }

        #region CreationPerso
        public static Personnage CreePersoRandom()
        {
            //listes noms
            List<string> rndNameMonster = new List<string> { "Jeff Bezos", "Beyonce", "La Boulangère", "Benedict Cumberbatch", "Channing Tatum", "Kim Kardashian", "McDonald", "Onion", "Big Mac", "Tacos", "Beef", "Salad", "Fricadelle", "Meghan Markle", "Madonna", "Frite Leroy", "Xanax André", "Bubonic Plague", "Nalu Deprivation", "Macron", "SNCB", "Black Death", "Ebola", "ChickenPox", "Kim Jong Un", "Monsanto", "Cuberdon", "Dracula", "Walmart", "Rollmops", "Waterzooi", "Shadow", "Fengshui", "Khabib" };
            List<string> rndFirstNameHero = new List<string> { "Greg", "Benja", "Maïlys", "Albin", "Bertrand", "Sylvain", "Antonio", "Nathalie", "Ryan", "Bryan", "Denis", "Paulin", "Nabil", "Khun", "Ling", "Samuel", "Mélanie", "Quentin", "Olivier", "Technobel", "Trakk" };
            List<string> rndTitleNameMonster = new List<string> { "Sultan", "President", "Professor", "Monarch", "King", "Queen", "Killer", "Chinese", "Doctor", "CEO", "Chef", "Cardinal", "Chairman", "Minister", "Master", "Wizard", "Princess", "Rabbi", "Enchantress", "Pope", "Agent", "Supreme" };
            List<string> rndLastNameHero = new List<string> { "Lannister", "Targaryen", "Tyrell", "Stark", "Baratheon", "Snow", "Eisenberg", "Baraki", "Salamanca", "Simpson", "Liberté", "Justice", "Danger", "Saumon", "Truite", "Moule", "Langoustine", "Crevette", "Crabe", "Plancton", "Daurade", "Maquereau", "Magnifique", "Calamar", "Méduse", "Octopus", "Anonyme", "Colérique", "Diabétique", "L'Energique", "Remarquable", "L'Intrépide", "L'Orthodoxe", "Nuncha-Cric" };

            string name;
            int typec;
            Personnage p;
            //ClassesPerso c0;

            //choix Hero ou monstre, 2/3 chance monstre
            int n = rnd.Next(0, 3);

            if (n == 0) //Hero
            {
                name = rndTitleNameMonster[rnd.Next(0, rndTitleNameMonster.Count)] + " " + rndFirstNameHero[rnd.Next(0, rndFirstNameHero.Count)] + " " + rndLastNameHero[rnd.Next(0, rndLastNameHero.Count)];
                //choix type Hero
                typec = rnd.Next(0, 2);
                //humain
                if (typec == 0) {p = Create((ClassesPerso)0, name);}
                //nain
                else {p = Create((ClassesPerso)1, name);}
            }
            else    //Monstre
            {
                name = rndTitleNameMonster[rnd.Next(0, rndTitleNameMonster.Count)] + " " + rndNameMonster[rnd.Next(0, rndNameMonster.Count)];
                //choix type Monstre
                typec = rnd.Next(0, 3);
                //loup
                if (typec == 0){ p = Create((ClassesPerso)2, name);}
                //orque
                else if (typec == 1) {p = Create((ClassesPerso)3, name);}
                //dragonnet
                else {p = Create((ClassesPerso)4, name);}
            }
            return p;
        }
        #endregion


        #region Battle
        public static void Battle(int combatnum, Personnage a, Personnage b, List<Personnage> listePersonnages, List<Personnage> ennemisAbbatus, List<string> events)
        {
            // Create a table
            var table = new Table();

            // Add some columns
            table.AddColumn($"[bold]COMBAT n°{combatnum}[/]");
            table.AddColumn($"HP");
            table.Columns[0].Padding(4, 0);
            table.Columns[1].Width(40);

            //if 2 heroes
            if (a.GetType().BaseType.Name == "Hero" && b.GetType().BaseType.Name == "Hero")
            {
                // Add some rows
                table.AddRow($"- Les joueurs {a.GetType().Name} '{a.Name}' et {b.GetType().Name} '{b.Name}' font partie de la classe Hero. Ils ne s'attaqueront pas.\n", $"HP {a.GetType().Name} {a.Name}: {a.HP}\nHP {b.GetType().Name} {b.Name}: {b.HP}");
            }
            else {

                // Add some rows
                table.AddRow($"- Le personnage '{a.Name}' de type {a.GetType().Name} défie '{b.Name}' de type {b.GetType().Name}!!", $"HP {a.GetType().Name} {a.Name}: {a.HP}\nHP {b.GetType().Name} {b.Name}: {b.HP}\n----------");

                do
                {
                    //décider qui va frapper
                    int First = rnd.Next(0, 3);   //2/3 chances de frapper sinon je perds tout le temps lol
                    if (First != 0) {
                        table.AddRow($"[red]{a.Frappe(b)}[/]", $"HP {a.GetType().Name} {a.Name}: {a.HP}\nHP {b.GetType().Name} {b.Name}: {b.HP}\n----------");
                    }
                    else {
                        table.AddRow($"[red]{b.Frappe(a)}[/]", $"HP {a.GetType().Name} {a.Name}: {a.HP}\nHP {b.GetType().Name} {b.Name}: {b.HP}\n----------");
                    }

                } while (a.HP > 0 && b.HP > 0);

                //winner/loser + transferloot
                string winner ="";
                string loser="";
                string msg = "";
                if (a.HP > b.HP)
                {
                    DoEndBattle(a, b, table, listePersonnages, ennemisAbbatus, out winner, out loser, out msg, events);
                }
                else
                {
                    DoEndBattle(b, a, table, listePersonnages, ennemisAbbatus, out winner, out loser, out msg, events);
                }
                string messageEndBattle = $"{winner} a massacré {loser}!!";
                events.Add(messageEndBattle);   //ajouter l'event dans le log
                events.Add(msg);
                table.AddRow($"[turquoise2]{messageEndBattle}[/]");
            }

            // print table
            table.Border(TableBorder.HeavyEdge);
            AnsiConsole.Write(table);
        }

        #endregion

        //change stat if win or lose
        public static void DoEndBattle(Personnage w, Personnage l, Table table, List<Personnage> persos, List<Personnage> ennemisdead, out string winners, out string losers, out string xp, List<string> events)
        {
            TransferLoot(w, l, events, table);
            ennemisdead.Add(l);
            persos.Remove(l);
            w.Xp += 1;  //gagne 1xp
            xp = $"{w.GetType().Name} {w.Name} gagne 1 Xp";
            table.AddRow(xp);
            w.HP = w.MaxHP; //restore HP
            winners = w.GetType().Name + " " + w.Name;
            losers = l.GetType().Name + " " + l.Name;
        }

        public static void TransferLoot(Personnage winner, Personnage loser, List<string> events, Table table)
        {
            //si nain ou humain, loot (les autres loot pas)
            string loot = "";
            if (winner.GetType().Name == "Humain" || winner.GetType().Name == "Nain")
            {
                loot = $"{winner.GetType().Name} {winner.Name} récolte {loser.Or} Or et {loser.Cuir} Cuir.";
                events.Add(loot);
                table.AddRow(loot);
                winner.Or += loser.Or;
                winner.Cuir += loser.Cuir;
            }
            loser.IsAlive = false;
            loser.Or = 0;
            loser.Cuir = 0;
        }

        public static int ChoiceNPCInt()
        {
            //Générer les autres personnages (min 1)
                //choix nombre
            Console.WriteLine("Combien d'autres joueurs veux-tu générer? (les NPC sont générées aléatoirement)");
            int.TryParse(Console.ReadLine(), out int choice);
            while (choice < 1)
            {
                Console.WriteLine("Il vous faut au moins un adversaire.");
                Console.WriteLine("Combien d'autres joueurs voulez-vous générer? (les NPC sont générées aléatoirement)");
                int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }

        #region RunMenu
        public static Personnage RunMainMenu()
        {
            string optionprompt = FiggleFonts.Epic.Render("Shorewood") + "\n\"Personne ne se rappelait de l'origine de la décadence qu'avait connu l'empire de 'StormWall', mais tous étaient sûr d'une chose: la source du mal se trouvait dans la forêt enchantée de Shorewood, débordante de monstres et de créatures de la nuit: 'Loups', 'Orques' et 'Dragonnets' empêchaient quiconque d'accéder au Royaume. Seuls les Nains opportunistes et quelques Humains arrogants osaient encore s'y aventurer...\"\n\n-------------------------------------------------------------------------\n\nVous qui vous risquez à entrer dans cette forêt maudite, qui êtes-vous? (Touches flechées + 'Enter')\nLes Humains et Nains se tolèrent et ne s'attaqueront pas, le but pour eux sera de tuer tous les Monstres. Si vous choisissez un Monstre, le but sera de tuer tout le monde... (Attention, seuls les Humains et Nains peuvent récolter de l'Or ou du Cuir. Si vous choisissez un monstre, aucun loot n'est possible, ils ne sont pas assez intelligents pour cela)\n\n";
            string[] options = { "Humain", "Nain", "Loup", "Orque", "Dragonnet" };
            Menu mainMenu = new Menu(optionprompt, options);
            int selectedIndex = mainMenu.Run();

            ClassesPerso.TryParse(selectedIndex.ToString(), out ClassesPerso c);

            Console.WriteLine();
            Console.WriteLine($"Quel nom voulez-vous choisir pour votre {options[selectedIndex]}?");
            string name = Console.ReadLine();
            Console.WriteLine($"{name} de la classe {options[selectedIndex]} a été créé.");

            Console.WriteLine();

            Personnage p = Create(c, name);
            return p;
        }

        public static bool PlayAgain(string askuser)
        {
            Console.WriteLine(askuser);
            if (Console.ReadLine().ToLower().StartsWith('o'))
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
