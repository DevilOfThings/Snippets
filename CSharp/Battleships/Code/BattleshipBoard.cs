using System;
using System.Collections.Generic;
using Battleships.CodeExtensions;
using System.Linq;

namespace Battleships
{
    public class BattleshipBoard {

        
        const int MaxShips = 5;
        
        public Array Board = Array.CreateInstance(typeof(ShipType), RowCol.MaxRow, RowCol.MaxCol);
        public List<Ship> Fleet = new List<Ship>();
        
        enum fleet {
            battleship,
            carrier,
            cruiser,
            destroyer,
            submarine
        }
        Random seed = new Random();

        public BattleshipBoard() {

            Fleet.Clear();
            Fleet.Add(ShipFactory.CreateShip(ShipType.Battleship));
            Fleet.Add(ShipFactory.CreateShip(ShipType.Carrier));
            Fleet.Add(ShipFactory.CreateShip(ShipType.Cruiser));
            Fleet.Add(ShipFactory.CreateShip(ShipType.Destroyer));
            Fleet.Add(ShipFactory.CreateShip(ShipType.Submarine));
            
        }

        public void NewBoard()
        {
            Fleet.ForEach(x=>FindSpaceOnBoard(x));
        }

        public void FindSpaceOnBoard(IShip ship) {
            
            while (!Place(ship));
        }

        public bool isWater(RowCol pos) => 
            pos.Row > -1 && pos.Row < RowCol.MaxRow && 
            pos.Col > -1 &&pos.Col < RowCol.MaxCol && 
            ((ShipType)Board.GetValue(pos.Row, pos.Col)) == ShipType.Water;

        public bool isBoat(RowCol pos) =>
            pos.Row > -1 && pos.Row < RowCol.MaxRow && 
            pos.Col > -1 &&pos.Col < RowCol.MaxCol && (
                ((ShipType)Board.GetValue(pos.Row, pos.Col)) == ShipType.Battleship ||
                ((ShipType)Board.GetValue(pos.Row, pos.Col)) == ShipType.Cruiser ||
                ((ShipType)Board.GetValue(pos.Row, pos.Col)) == ShipType.Carrier ||
                ((ShipType)Board.GetValue(pos.Row, pos.Col)) == ShipType.Destroyer ||
                ((ShipType)Board.GetValue(pos.Row, pos.Col)) == ShipType.Submarine );

        public bool findPossibleTarget(RowCol pos) => 
            ((ShipType)Board.GetValue(pos.Row, pos.Col)) != ShipType.Hit &&
            ((ShipType)Board.GetValue(pos.Row, pos.Col)) != ShipType.Miss;
            
        public ShipType FireMissile(RowCol pos)
        {
                Console.WriteLine($"Fire: {pos.Row}{pos.Col}");

                var square = (ShipType)Board.GetValue(pos.Row, pos.Col);
                if(isBoat(pos))
                {
                    Board.SetValue(ShipType.Hit, pos.Row, pos.Col);
                    Fleet.First(x=>x.ShipType == square).Hits++;                    
                }
                else {
                    Board.SetValue(ShipType.Miss, pos.Row, pos.Col);
                }

                return square;
        }

        public bool boatFitsInSpace(RowCol startPos, RowCol endPos)
        {
            var positions = AllocateGridPositions(startPos, endPos);
            bool valid = true;

            foreach(var position in positions) {
                if(!isWater(position))
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }

        public List<RowCol> AllocateGridPositions(RowCol start, RowCol end)
        {
            var positions = new List<RowCol>();
            var cols = Enumerable.Range(Math.Min(start.Col, end.Col),  Math.Abs(end.Col-start.Col)+1).Select(x=>x);

            var rows = Enumerable.Range(Math.Min(start.Row, end.Row), Math.Abs(end.Row-start.Row)+1).Select(x=>x);

                // set middle placements
            foreach(var col in cols)
            {
                foreach(var row in rows)
                {
                    positions.Add(new RowCol(row, col));
                }
            }

            return positions;
        }

        
        public void PrintBoard()
        {
            int rows = Board.GetLength(0);
            int columns = Board.GetLength(1);
            
            Enumerable.Range(0,10).ToList().ForEach(x=> Console.Write("{0,10}", $"{x}"));
            Console.WriteLine();
            for(var row = 0; row < rows; ++row) {
                Console.Write($"{row}   ");
                for(var column = 0; column < columns; ++column) {
                
                    Console.Write("{0, 10}", $" {Board.GetValue(row, column)}");
                }
                Console.WriteLine();
            }
        }
        
        public bool Place(IShip ship)
        {     
            int size = ship.Size;    
            var startPos = new RowCol(seed.NextRow(), seed.NextColumn());
            var endPos = new RowCol((size + startPos.Row)-1, startPos.Col);

            bool canBePlacedHere() {
                if(boatFitsInSpace(startPos, endPos))
                {
                    ship.Position = new Position {
                        Start = startPos,
                        End = endPos,
                        Occupies = AllocateGridPositions(startPos, endPos)
                    };
                    foreach(var space in ship.Position.Occupies) {
                        Board.SetValue(ship.ShipType, space.Row, space.Col);
                    }
                    return true;
                }
                return false;
            }
            
            if(canBePlacedHere())
            {
                return true;
            }

            endPos = new RowCol(startPos.Row, (startPos.Col + size)-1);
            if(canBePlacedHere())
            {
                return true;
            }
            
            endPos = new RowCol(startPos.Row, (startPos.Col -size)+1);
            if(canBePlacedHere())
            {
                return true;
            }

            endPos = new RowCol((startPos.Row -size)+1, startPos.Col);
            if(canBePlacedHere())
            {
                return true;
            }

            return false;
        }
    }
}