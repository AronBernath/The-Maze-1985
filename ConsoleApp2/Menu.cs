using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Pastel;
using Figgle;
using System.Drawing;

namespace ConsoleApp2
{
    internal class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        private string Prompt2;

        public Menu(string prompt, string prompt2, string[] options)
        {
            Prompt = prompt;
            Prompt2 = prompt2;
            Options = options;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            WriteLine(FiggleFonts.Larry3d.Render(Prompt));
            WriteLine(FiggleFonts.Larry3d.Render(Prompt2));

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else 
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine($"{prefix}<<|{currentOption}|>>");
            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo KeyInfo = ReadKey(true);
                keyPressed = KeyInfo.Key;

                // Update SelectedIndex a nyilakkal
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                { 
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;  
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
