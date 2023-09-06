using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Pastel;
using Figgle;


namespace ConsoleApp2
{
    internal class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    SetCursorPosition(x, y);


                    string fgColorHex = element == "X" ? "FF0000" : "FED0FF";

                    Write(element.Pastel(fgColorHex));
                }
            }
        }

        public string GetElementAt(int x, int y)
         {
             return Grid[y,x];
         }
        public bool Walkable(int x, int y)
        {
             if (x<0 || y<0 || x >= Cols || y >= Rows)
                 {
                    return false;
                 }
            return Grid[y, x] == " " || Grid[y, x] == "X";
                                                      
        }
    }
}
