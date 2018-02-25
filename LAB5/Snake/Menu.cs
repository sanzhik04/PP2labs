﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    class Menu
    {
         
        string[] items = { "New Game", "Load Game", "Exit" };
        int selectedItemIndex = 0;

        void NewGame()
        {
            Console.Clear();

            Game game = new Game();
            game.SetupBoard();
            game.Start();
            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                game.Process(pressedButton);

            }
            
        }

        void LoadGame()
        {
            Console.Clear();
            FileStream fs = new FileStream("Game.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Game));
            Game game = xs.Deserialize(fs) as Game;
            fs.Close();
            
            game.SetupBoard();
            game.Start();
            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                game.Process(pressedButton);

            }
        }

       

       

        void Exit()
        {
            StatusBar.ShowInfo("Exit!");
        }

        public void Draw()
        {

            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < Game.boardH - 2; ++i)
            {
                for (int j = 0; j < Game.boardW; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        public void Draw1()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, (Game.boardH - 25) / 2);

            for (int i = 0; i < items.Length; ++i)
            {
                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(String.Format("           {1}", i, items[i]));
            }
        }
        

        public void Process()
        {
            Draw();
            while (true)
            {
                Draw1();
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                switch (pressedButton.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItemIndex--;
                        if (selectedItemIndex < 0)
                        {
                            selectedItemIndex = items.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedItemIndex++;
                        if (selectedItemIndex >= items.Length)
                        {
                            selectedItemIndex = 0;
                        }
                        break;
                    case ConsoleKey.Enter:

                        switch (selectedItemIndex)
                        {
                            case 0:
                                NewGame();
                                break;
                            case 1:
                                LoadGame();
                                break;
                            
                            
                                
                                
                            case 2:
                                return;
                                break;
                        }

                        break;
                }
            }

            
        }
    }
}