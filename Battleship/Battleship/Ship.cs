using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum ShipType
    {
        D1,
        D2,
        D3,
        D4
    }
    class Ship
    {
        public List<ShipPoint> body = new List<ShipPoint>();
        
        ShipType type;
        string Direction;

        public Ship(Point p, ShipType type, string Direction)
        {
            this.type = type;
            this.Direction = Direction;
            GenerateBody(p);
        }

        public void GenerateBody(Point p)
        {
            switch (type)
            {
                case ShipType.D1:
                     body.Add(new ShipPoint { X = p.X, Y = p.Y, PType = PartType.ShipPart });
                    break;
                case ShipType.D2:
                    if (Direction == "Horizontal")
                    {
                        for (int i = 0; i < 2; ++i)
                        {
                            body.Add(new ShipPoint { X = p.X + i, Y = p.Y, PType = PartType.ShipPart });
                        }
                    }
                    if(Direction == "Vertical")
                    {
                        for (int i = 0; i < 2; ++i)
                        {
                            body.Add(new ShipPoint { X = p.X, Y = p.Y+i, PType = PartType.ShipPart });
                        }
                    }
                    break;
                case ShipType.D3:
                    if (Direction == "Horizontal")
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            body.Add(new ShipPoint { X = p.X + i, Y = p.Y, PType = PartType.ShipPart });
                        }
                    }
                    if (Direction == "Vertical")
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            body.Add(new ShipPoint { X = p.X, Y = p.Y + i, PType = PartType.ShipPart });
                        }
                    }
                    break;
                case ShipType.D4:
                    if (Direction == "Horizontal")
                    {
                        for (int i = 0; i < 4; ++i)
                        {
                            body.Add(new ShipPoint { X = p.X + i, Y = p.Y, PType = PartType.ShipPart });
                        }
                    }
                    if (Direction == "Vertical")
                    {
                        for (int i = 0; i < 4; ++i)
                        {
                            body.Add(new ShipPoint { X = p.X, Y = p.Y + i, PType = PartType.ShipPart });
                        }
                    }
                   
                    
                  

                  
                    break;
                default:
                    break;
            }

        }
    }
}
