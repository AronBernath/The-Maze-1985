using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Timers;
using static System.Console;

namespace ConsoleApp2
{
    internal class Game

    {
        private World MyWorld;
        private Player CurrentPlayer;
        public string Etime = "";
        public string playerTime = "";
        public DateTime? startTime = null;
        public string playerName = "";
        string[,] top5 = null;
        public string[,] grid0 = new string[0,0];
        public string[,] grid1 = new string[0,0];
        public string[,] grid2 = new string[0, 0];
        public string[,] grid3 = new string[0, 0];
        public string[,] grid4 = new string[0, 0];
        public string[,] board0 = new string[0, 0];
        public string[,] board1 = new string[0, 0];
        public string[,] board2 = new string[0, 0];
        public string[,] board3 = new string[0, 0];
        public string[,] board4 = new string[0, 0];
        public void Start()
        {
            Title = "Maze 1985";
            CursorVisible = false;
            RunMainMenu();
            for (int i = 0; i < 5; i++)
            {
                string palyak = "palya_" + (i + 1) + ".txt";
                string[,] grid = LevelParser.ParseFileToArray(palyak);
                MyWorld = new World(grid);
                CurrentPlayer = new Player(0, 1);
                RunGameLoop();
            }
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = "Welcome";
            string prompt2 = "To Maze 1985";
            string[] options = { "Start", "Select level", "Leaderboard", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, prompt2, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    DummyStart();
                    break;
                case 1:
                    SelectLevel();
                    break;
                case 2:
                    Leaderboard();
                    break;
                case 3:
                    About();
                    break;
                case 4:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        private void ExitGame()
        {
            Environment.Exit(0);
        }

        private void SelectLevel()
        {
            string prompt = "The Maze 1985";
            string prompt2 = "Select Level";
            string[] options = { "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Back to Main Menu" };
            Menu levelMenu = new Menu(prompt, prompt2, options);
            int selectedIndex = levelMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    string[,] grid0 = LevelParser.ParseFileToArray("palya_1.txt");
                    MyWorld = new World(grid0);
                    CurrentPlayer = new Player(0, 1);
                    RunGameLoop();
                    break;
                case 1:
                    string[,] grid1 = LevelParser.ParseFileToArray("palya_2.txt");
                    MyWorld = new World(grid1);
                    CurrentPlayer = new Player(0, 1);
                    RunGameLoop();
                    break;
                case 2:
                    string[,] grid2 = LevelParser.ParseFileToArray("palya_3.txt");
                    MyWorld = new World(grid2);
                    CurrentPlayer = new Player(0, 1);
                    RunGameLoop();
                    break;
                case 3:
                    string[,] grid3 = LevelParser.ParseFileToArray("palya_4.txt");
                    MyWorld = new World(grid3);
                    CurrentPlayer = new Player(0, 1);
                    RunGameLoop();
                    break;
                case 4:
                    string[,] grid4 = LevelParser.ParseFileToArray("palya_5.txt");
                    MyWorld = new World(grid4);
                    CurrentPlayer = new Player(0, 1);
                    RunGameLoop();
                    break;
                case 5:
                    RunMainMenu();
                    break;
            }
        }

        private void Leaderboard()
        {
            string prompt = "The Maze 1985";
            string prompt2 = "Select Level";
            string[] options = { "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Back to Main Menu" };
            Menu boardMenu = new Menu(prompt, prompt2, options);
            int selectedIndex = boardMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    RunMainMenu();
                    break;
            }

        }

        private void About()
        {
            Clear();
            WriteLine("Game was made for Software development project by Bernáth Áron - XCWWKL");
            ReadKey(true);
            RunMainMenu();
        }

        private void DummyStart()
        {

        }
        public void DisplayOutro(TimeSpan time)
        {
            Clear();
            WriteLine("Success!");
            WriteLine("Your time is: {0} seconds", time.Seconds);
            playerTime = time.ToString("T");
            if (String.IsNullOrEmpty(playerName) == true)
            {
                WriteLine("Type in your name: (4 characters)");
                playerName = ReadLine();
            }
            if (grid0 == LevelParser.ParseFileToArray("palya_1.txt"))
            {
                 board0[1,0] += playerName;
                 board0[0,1] += playerTime;
            }
            else DisplayNextOutro();
        }


        public void DisplayNextOutro()
        {
            WriteLine("\n\nPress any key to continue to the next level");
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;
            } while (KeyAvailable);
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.Walkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.Walkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.Walkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.Walkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        RunMainMenu();
                    }
                    break;
                default:
                    break;
            }

        }

        public void RunGameLoop()
        {
            DateTime startTime = DateTime.Now;
            while (true)
            {
                DrawFrame();

                HandlePlayerInput();

                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    
                    break;
                }

                System.Threading.Thread.Sleep(20);
            }
            TimeSpan timerValue = DateTime.Now - startTime;
            DisplayOutro(timerValue);
        }


    }
}
