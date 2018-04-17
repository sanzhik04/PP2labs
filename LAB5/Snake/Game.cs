using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    public enum GameLevel
    {
        First,
        Second,
        Bonus
    }





    
    public class Game
    {
        public static int interval = 300;
        public static int boardW = 35;
        public static int boardH = 35;
        [XmlElement]
        public int score = 0;
        [XmlElement]
        public int lvlcnt = 1;

        bool[,] field = new bool[10, 10];
        [XmlElement]
        public Worm worm;
        [XmlElement]
        public Food food;
        [XmlElement]
        public Wall wall;
        [XmlElement]
        public bool isAlive;


        ThreadStart ts = null;
        Thread t = null;


        


        public GameLevel gameLevel;

        public List<GameObject> g_objects = new List<GameObject>();

        public void SetupBoard()
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;
        }
        
        

       



        public Game()
        {
            isAlive = true;
            gameLevel = GameLevel.First;

            worm = new Worm(new Point { X = 10, Y = 10 },
                            ConsoleColor.Blue, '*');
            food = new Food(new Point { X = 20, Y = 10},
                           ConsoleColor.White, '+');
            wall = new Wall(null, ConsoleColor.White, '#');

            wall.LoadLevel(GameLevel.First);
            
            

            g_objects.Add(worm);
            g_objects.Add(food);
            g_objects.Add(wall);
        }

        
       

       
        
        public void Start()
        {
            ts = new ThreadStart(Draw);
            t = new Thread(ts);
            t.Start();
        }
        
        public void Stop()
        {
            t.Abort();
        }

        public void Draw()
        {
            
            
            food.Draw();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(15, 24);

            Console.WriteLine("SCORE:{0}", score);

            
            wall.Draw();
            


            while (true)
            {
               
                
                worm.Move();
                
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(15, 24);
                Console.WriteLine("        ", score);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(15, 24);
                Console.WriteLine("SCORE:{0}", score);




                if (worm.body[0].Equals(food.body[0]))
                {
                    worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                    
                    food.body[0] = food.CreateFood(wall.body, worm.body);
                    food.Draw();

                    score++;
                    

                    
                }
                
                else
                {
                    foreach (Point p in wall.body)
                    {
                        if (p.Equals(worm.body[0]))
                        {
                            Console.Clear();
                            Console.WriteLine("GAME OVER!!!");
                            Console.WriteLine("Your Score is {0}", score);
                            isAlive = false;
                            Console.ForegroundColor = ConsoleColor.Black;  
                            
                           
                            
                           
                            Stop();

                        }
                    }
                }
                
               

                
                

               

                


                

                if (score == 5)
                {
                    
                    wall.CleanBody();
                    
                    
                        interval = 200;
                        gameLevel = GameLevel.Second;
                        wall.LoadLevel(GameLevel.Second);
                        
                        Console.Clear();
                        wall.Draw();
                        
                        food.body[0] = food.CreateFood(wall.body, worm.body);
                    food.Draw(); 
                        worm.body.Clear();
                        worm.body.Add(new Point { X = 24, Y = 16 });
                    score++;
                    continue;
                    
                    
                    

                }




                
                worm.Draw();
               
                
                Thread.Sleep(Game.interval);
                
            }

            


        }

        

        public void Save()
        {

            
            StreamWriter sw = new StreamWriter("Game.xml", false);
            XmlSerializer xs = new XmlSerializer(typeof(Game));
            xs.Serialize(sw, this);
            sw.Close();

        }



        

        public void Exit()
        {

        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    if(worm.DX == 0 && worm.DY == 1)
                    {
                        break;
                    }
                    worm.DX = 0;
                    worm.DY = -1;
                    
                    break;
                case ConsoleKey.DownArrow:
                    if (worm.DX == 0 && worm.DY == -1)
                    {
                        break;
                    }
                    worm.DX = 0;
                    worm.DY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (worm.DX == 1 && worm.DY == 0)
                    {
                        break;
                    }
                    worm.DX = -1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    if (worm.DX == -1 && worm.DY == 0)
                    {
                        break;
                    }
                    worm.DX = 1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.Escape:
                    
                    Console.Clear();
                    
                    return;
                    break;
                case ConsoleKey.Spacebar:

                   Save();
                    
                
                    break;
                

                

            }


        }
    }
}