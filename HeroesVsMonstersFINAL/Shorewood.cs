using System;
using System.Collections.Generic;
using Spectre.Console;
using Figgle;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonstersFINAL
{
    class Shorewood
    {
        public List<Personnage> Personnages { get; set; }

        public static void AfficherTout(List<Personnage> plist)
        {

            foreach (Personnage p in plist) //afficher la tête en fonction de la race?
            {
                Jeu.PrintImage(p);
                AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label($"[bold]{p.GetType().Name} '{p.Name}' [/]")
                .AddItem("Xp", p.Xp, Color.White)
                .AddItem("MaxHP", p.MaxHP, Color.DeepSkyBlue4_1)
                .AddItem("Endurance", p.Endurance, Color.CadetBlue_1)
                .AddItem("Force", p.Force, Color.Yellow1)
                .AddItem("Or", p.Or, Color.Gold1)
                .AddItem("Cuir", p.Cuir, Color.DarkOrange));
                Console.WriteLine();
            }
        }

        public static void AfficherTout(Personnage p)
        {
                Jeu.PrintImage(p);
                Console.WriteLine();
                AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label($"[bold]{p.GetType().Name} '{p.Name}' [/]")
                .AddItem("Xp", p.Xp, Color.White)
                .AddItem("MaxHP", p.MaxHP, Color.DeepSkyBlue4_1)
                .AddItem("Endurance", p.Endurance, Color.CadetBlue_1)
                .AddItem("Force", p.Force, Color.Yellow1)
                .AddItem("Or", p.Or, Color.Gold1)
                .AddItem("Cuir", p.Cuir, Color.DarkOrange));
                Console.WriteLine();
        }

        public static string AfficherNomsString(List<Personnage> survivants)
        {
            string survivorsString = "";
            for (int i = 0; i < survivants.Count; i++)
            {
                survivorsString += $"- {survivants[i].GetType().Name} '{survivants[i].Name}'\n";
            }
            return survivorsString;
        }

        public static string AfficherEventsString(List<string> events)
        {
            string eventsString = "";
            for (int i = 0; i < events.Count; i++)
            {
                eventsString += $"- {events[i]}'\n";
            }
            return eventsString;
        }

        public static void FinalReport(List<Personnage> survivants, List<Personnage> abbatus, List<string> events)
        { 
            Console.Clear();
            if (Jeu.IsMainAlive(survivants))
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(FiggleFonts.Ogre.Render("Victoire"));
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine($"{survivants[0].GetType().Name} '{survivants[0].Name}' a abbatu tous ses ennemis dans la forêt enchantée!!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine(FiggleFonts.Ogre.Render("Defaite"));
                Console.WriteLine("Votre corps devient à présent de la nourriture pour les insectes, alors que le Royaume s'affame...");
            }

            //afficher Main
                //add list of survivors to list of dead to check both
            List<Personnage> ps = new();
            ps = survivants.Concat(abbatus).ToList();
            AfficherTout(Jeu.GetMain(ps));

            //print table with survivors and killed
            PrintTableKS(survivants, abbatus);

            //print table events
            PrintTableEvents(events);

            Console.ReadKey();
            Console.Clear();

        }

        public static void PrintTableKS(List<Personnage> survivants, List<Personnage> abbatus)
        {
            // Create a table
            var table = new Table();

            // Add some columns
            table.AddColumn("[bold]Personnages Survivants[/]");
            table.AddColumn(new TableColumn("[bold]Personnages Abbatus[/]"));


            //put ennemis into string
            string abbatusS = AfficherNomsString(abbatus);

            //put survivors in a string
            string survivorsS = AfficherNomsString(survivants);

            // Add some rows
            table.AddRow($"[green]{survivorsS}[/]", $"[red]{abbatusS}[/]");
            //table.AddRow(new Markup("[blue]Corgi[/]"), new Panel("Waldo"));

            // Render the table to the console
            table.Border(TableBorder.Rounded);
            AnsiConsole.Write(table);
        }

        public static void PrintTableEvents(List<string> events)
        {
            // Create a table
            var table = new Table();

            // Add some columns
            table.AddColumn("[bold]Evènements[/]");

            //put events in a string
            string eventsString = AfficherEventsString(events);

            // Add some rows
            table.AddRow($"[turquoise2]{eventsString}[/]");
            //table.AddRow(new Markup("[blue]Corgi[/]"), new Panel("Waldo"));

            // Render the table to the console
            table.Border(TableBorder.Rounded);
            AnsiConsole.Write(table);
        }
    }
}
