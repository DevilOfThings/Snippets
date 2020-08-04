using System;
using System.Linq;


namespace Battleships
{
    public class LastGo {
        public RowCol LastRowCol {get;set;}
        public ShipType Hit {get;set;}
    }
    public class Player {

        LastGo lastGo = new LastGo();
        public BattleshipBoard FleetBoard;
        
        public void LayoutBoard4Player()
        {
            FleetBoard = new BattleshipBoard();
            FleetBoard.NewBoard();
        }

        int TotalEnemy() {
            return 0;
        }

        public bool FleetDestroyed => FleetBoard.Fleet.Cast<Ship>().All(x=>x.hasSunk);
        
        public ShipType TakeTurn(BattleshipBoard enemy)
        {            

            var random =new Random();
            int row = random.Next(10);
            int col = random.Next(10);
            var target = new RowCol(row, col);

            if(lastGo.Hit ==ShipType.Hit) {
                var temp = lastGo.LastRowCol.FindAdjacentEmptyCell(enemy);
                if(temp.IsValid()) {
                    target = temp;
                }
            }
            lastGo.Hit =ShipType.Miss;

           while(!enemy.findPossibleTarget(target))
           {
               row = random.Next(10);
               col = random.Next(10);
               target = new RowCol(row, col);
           }
            
            
            lastGo.Hit =enemy.FireMissile(target);
            lastGo.LastRowCol = target;
            
            switch(lastGo.Hit)
            {
                case ShipType.Battleship:
                case ShipType.Carrier:                
                case ShipType.Cruiser:                
                case ShipType.Destroyer:
                case ShipType.Submarine:
                    Console.WriteLine($"You hit my {lastGo.Hit.ToString()}");
                    lastGo.Hit = ShipType.Hit;
                    break;
                case ShipType.Water:
                    Console.WriteLine($"Miss!!!");
                    lastGo.Hit = ShipType.Miss;
                break;
            }

            
            return lastGo.Hit;
        }
    }
}