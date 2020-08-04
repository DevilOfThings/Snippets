using System;

namespace Battleships
{


    public class Scores {
        int Player1Wins;
        int Player2Wins;
    }

    public class Game {

        public Player  Player1;
        public Player Player2;

        public Game() {
            
        }

        public void NewGame()
        {
            Player1 = new Player();
            Player1.LayoutBoard4Player();
            Player2 = new Player();
            Player2.LayoutBoard4Player();
        }
        
        public enum GameWinner {
            None,
            Player1,
            Player2
        }
        public bool IsGameOver() => Player1.FleetDestroyed || Player1.FleetDestroyed;

        public void MainGame() {

            NewGame();

            do {
                var missile = Player1.TakeTurn(Player2.FleetBoard);
                
                if(Player2.FleetDestroyed)
                {
                    Console.WriteLine($"Player 1 wins");
                    break;
                }

                Player2.TakeTurn(Player1.FleetBoard);
                if(Player1.FleetDestroyed)
                {
                    Console.WriteLine($"Player 2 wins");
                    break;
                }
            } while(!IsGameOver());

        }
    }
}