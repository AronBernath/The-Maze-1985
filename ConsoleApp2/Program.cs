﻿using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pastel;
using Figgle;

namespace ExplorableWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game currentGame = new Game(); 
            currentGame.Start();
        }
    }
}
