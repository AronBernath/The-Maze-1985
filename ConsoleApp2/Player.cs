using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Pastel;
using Figgle;

namespace ConsoleApp2
{
    internal class Player
    {

        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private string PlayerColor;
        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "O";
            PlayerColor = "F3FF00";
        }

        public void Draw() 
        {
            SetCursorPosition(X, Y);
            Write(PlayerMarker.Pastel(PlayerColor));
            ResetColor();
        }
    }
}
