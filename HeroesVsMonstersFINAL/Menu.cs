using System;
using static System.Console;
using Figgle;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace HeroesVsMonstersFINAL
{
    class Menu
    {
        public int SelectedIndex;
        public string[] Options;
        public string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string optionSelectionnee = Options[i];
                string prefix;
                if (i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.DarkBlue;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} - {optionSelectionnee} -");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                //update selected index based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }

        public static string RaceChoice()
        {
            var race = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Quelle est votre race?\n")
            .PageSize(10)
            .MoreChoicesText("[grey](Arrows + 'Enter')[/]")
            .AddChoices(new[] {
                            "Humain", "Nain", "Loup",
                            "Orque", "Dragonnet",
            }));

            // Echo the fruit back to the terminal
            return race;
        }
    }
}
