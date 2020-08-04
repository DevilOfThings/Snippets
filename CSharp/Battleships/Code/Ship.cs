using System;

namespace Battleships
{
    public enum ShipType {
        Water,
        Carrier,
        Battleship,
        Cruiser,
        Submarine,
        Destroyer,        
        Miss,
        Hit,

    }

    public class ShipBuildingException : Exception
    {

    }
    

    public class ShipFactory {
        public static Ship CreateShip(ShipType shipType)
        {
            switch(shipType)
            {
                case ShipType.Battleship:
                    return new Battleship();
                case ShipType.Carrier:
                    return new Carrier();
                case ShipType.Destroyer:
                    return new Destroyer();
                case ShipType.Cruiser:
                    return new Cruiser();
                case ShipType.Submarine:
                    return new Submarine();
                default:
                    throw new ShipBuildingException();
            }
        }
    }

    public interface IShip {
        int Size {get; set;}
        int Hits {get;set;}
        Position Position{get;set;}
        bool hasSunk {get;}
        ShipType ShipType {get; set;}
    }
    public abstract class Ship : IShip{
        protected Ship(int size) {
            Size = size;
        }
        public int Size {get;set;}
        public int Hits {get;set;}
        public Position Position {get;set;}

        public bool hasSunk => Size - Hits ==0;

        public ShipType ShipType {get; set;}
                
    }

    public class Carrier : Ship {
        public Carrier() : base(5) {
            ShipType = ShipType.Carrier;
        }

        
    }

    public class Battleship : Ship {

        public Battleship() : base(4) {
            ShipType = ShipType.Battleship;
        }

        
    }

    public class Cruiser : Ship {
        public Cruiser() : base(4) {
            ShipType = ShipType.Cruiser;
        }

        
    }

    public class Submarine : Ship {
        public Submarine() : base(5) {
            ShipType = ShipType.Submarine;
        }

        
    }

    public class Destroyer : Ship {
        public Destroyer() : base(6) {
            ShipType = ShipType.Destroyer;
        }

        
    }
}